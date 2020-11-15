using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web1.Contracts.V1;
using Web1.Contracts.V1.Requests;
using Web1.Contracts.V1.Responses;
using Web1.Services;

namespace Web1.Controllers.V1
{
    public class AuthController:Controller
    {
        private readonly IAuthService _service;
        private readonly IMapper _map;
        public AuthController(IAuthService service, IMapper mapper)
        {
            _service = service;
            _map = mapper;

        }
        [HttpPost(ApiRoutes.Auth.Register)]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            var rs = await _service.Register_Async(registerRequest);
            if (rs == null)
            {
                return BadRequest();
            }
            if (rs.Errors != null && rs.Errors.Length > 0)
            {
                return BadRequest(rs.Errors);
            }

            return Ok( _map.Map<AuthResponseSuccess>(rs));
        }
        [HttpPost(ApiRoutes.Auth.Login)]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var rs = await _service.Login_Async(loginRequest);
            if (rs == null)
            {
               return BadRequest();
            }
            if (rs.Errors != null && rs.Errors.Length > 0)
            {
               return  BadRequest(rs.Errors);
            }

            return Ok(_map.Map<AuthResponseSuccess>(rs));
        }
        [HttpPost(ApiRoutes.Auth.RefreshToken)]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest refreshTokenRequest)
        {
            var rs = await _service.RefreshToken_Async(refreshTokenRequest);
            if (rs == null)
            {
                return BadRequest();
            }
            if (rs.Errors != null && rs.Errors.Length > 0)
            {
                return BadRequest(rs.Errors);
            }

            return Ok(_map.Map<AuthResponseSuccess>(rs));
        }
    }

}
