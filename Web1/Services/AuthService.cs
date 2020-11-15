using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Web1.Contracts.V1.Requests;
using Web1.Contracts.V1.Responses;
using Web1.Data.Repositories;
using Web1.Domain;
using Web1.Helpers;
using Web1.Options;

namespace Web1.Services
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _map;
        private readonly IAuthRepository _repo;
        private readonly JwtSettings _JwtSettings;
        private readonly Hash _hash;
        private readonly TokenValidationParameters _tokenValidationParameters;

        public AuthService(IAuthRepository repo,IMapper mapper,JwtSettings jwtSettings,Hash hash,TokenValidationParameters tokenValidationParameters)
        {
            _map = mapper;
            _repo = repo;
            _JwtSettings = jwtSettings;
            _hash = hash;
            _tokenValidationParameters = tokenValidationParameters;
        }

        public async Task<AuthResult> Login_Async(LoginRequest registerRq)
        {
            var emp = await _repo.GetEmployeeByUserNameOrEmail_Async(registerRq.UserName);
            if (emp != null)
            {
                if (_hash.Validate(registerRq.Password, emp.PasswordHash))
                {
                    emp.RefreshTokens = new List<RefreshToken> { };

                    return await GenerateToken_Async(emp,false);
                }
                return null;
            }
            return null;
        }

        public async Task<AuthResult> RefreshToken_Async(RefreshTokenRequest refreshTokenRequest)
        {
            var validatedToken = GetPrincipalFromToken(refreshTokenRequest.Token);
            if (validatedToken == null)
            {
                return new AuthResult
                {
                    Errors = new[] { "Invalid token" }
                };
            }
            var expiryDateunix = long.Parse(validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Exp).Value);
            var expiryDateTimeUtc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                                                       .AddSeconds(expiryDateunix);

            if (expiryDateTimeUtc > DateTime.UtcNow)
            {
                return new AuthResult { Errors = new[] { "This token hasn't expired yet" } };
            }
            var jti = validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Jti).Value;

            var storedRefreshToken = await  _repo.GetRefreshTokenByToken_Async(refreshTokenRequest.RefreshToken);
            if (storedRefreshToken == null)
            {
                return new AuthResult { Errors = new[] { "This Refreshtoken not exist" } };
            }
            if (DateTime.UtcNow > storedRefreshToken.ExpiryDate)
            {
                return new AuthResult { Errors = new[] { "This refresh token has expired" } };
            }
            if (storedRefreshToken.Invalidated)
            {
                return new AuthResult { Errors = new[] { "This refresh token has been invalidated" } };
            }
            if (storedRefreshToken.Used)
            {
                return new AuthResult { Errors = new[] { "This refresh token has been Used" } };
            }
            if (storedRefreshToken.JwtId != jti)
            {
                return new AuthResult { Errors = new[] { "This refresh token dose  not match JWT" } };
            }
            storedRefreshToken.Used = true;
            _repo.UpdateRefreshToken(storedRefreshToken);
            return await GenerateToken_Async(storedRefreshToken.Employee);
        }

        public async Task<AuthResult> Register_Async(RegisterRequest registerRq)
        {
            var emp = _map.Map<Employee>(registerRq);
            emp.PasswordHash = _hash.Create(registerRq.Password);
            emp.RefreshTokens =new List<RefreshToken> { };
        
          
            return await GenerateToken_Async(emp);


        }
        
        
        
        private async Task<AuthResult> GenerateToken_Async(Employee emp,bool registerCheck=true)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_JwtSettings.Secret);
            var claims = new List<Claim> {
                        new Claim(Constant.CustomClaims.EMAIL, emp.Email),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(Constant.CustomClaims.USERNAME, emp.Username),
                        new Claim(Constant.CustomClaims.ROLE,emp.RoleID.ToString())
                    };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(_JwtSettings.TokenLifeTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            var refreshToken = new RefreshToken
            {
                JwtId = token.Id,
                EmployeeId = emp.EmployeeId,
                CreationDate = DateTime.UtcNow,
                ExpiryDate = DateTime.UtcNow.AddMonths(6),
                Token = Guid.NewGuid().ToString()
            };
            if (registerCheck)
            {
                emp.RefreshTokens.Add(refreshToken);
                await _repo.AddEmployee_Async(emp);

            }
            else
            {
                await _repo.AddRefreshToken_Async(refreshToken);
            }


      
            return await _repo.SaveChange_Async()>0 ? new AuthResult {
                AccessToken = tokenHandler.WriteToken(token),
                Email = emp.Email,
                Username = emp.Username,
                RefreshToken=refreshToken.Token

            }: null;
     
        }
        private ClaimsPrincipal GetPrincipalFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                var principal = tokenHandler.ValidateToken(token, _tokenValidationParameters, out var validatedToken);
                if (!IsJwtWithValidSecurityAlgorithm(validatedToken))
                {
                    return null;

                }
                return principal;
            }
            catch
            {
                return null;
            }
        }
        private bool IsJwtWithValidSecurityAlgorithm(SecurityToken validatedToken)
        {
            return (validatedToken is JwtSecurityToken jwtSecurityToken) &&
                    jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);
        }

    }
}
