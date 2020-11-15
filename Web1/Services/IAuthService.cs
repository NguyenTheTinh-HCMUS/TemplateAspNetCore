using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web1.Contracts.V1.Requests;
using Web1.Contracts.V1.Responses;

namespace Web1.Services
{
    public interface IAuthService
    {
        Task<AuthResult> Register_Async(RegisterRequest registerRq);
        Task<AuthResult> Login_Async(LoginRequest registerRq);
        Task<AuthResult> RefreshToken_Async(RefreshTokenRequest refreshTokenRequest);


    }
}
