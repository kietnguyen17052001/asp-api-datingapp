using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dating_app.api.DTOs;
using dating_app.api.Service;
using Microsoft.AspNetCore.Authorization;

namespace dating_app.api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        public AuthController(IAuthService _authService)
        {
            authService = _authService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterUserDto registerUserDto)
        {
            try
            {
                return Ok(authService.register(registerUserDto));
            }
            catch (BadHttpRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthUserDto authUserDto)
        {
            try
            {
                return Ok(authService.login(authUserDto));
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}