using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dating_app.api.DTOs;
using dating_app.api.Data;
using System.Security.Cryptography;
using dating_app.api.Data.Entity;
using System.Text;
using dating_app.api.Service;
using Microsoft.AspNetCore.Authorization;

namespace dating_app.api.Controllers
{
    [Route("api/auth")]
    public class AuthController : BaseController
    {
        private readonly DataContext dataContext;
        private readonly ITokenService tokenService;
        public AuthController(DataContext dataContext, ITokenService tokenService)
        {
            this.dataContext = dataContext;
            this.tokenService = tokenService;
        }
        [HttpPost("register")]
        public IActionResult Register([FromBody] AuthUserDto authUserDto)
        {
            authUserDto.username = authUserDto.username.ToLower();
            if (dataContext.users.Any(u => u.username == authUserDto.username))
            {
                return BadRequest("username exists");
            }
            else
            {
                using var hmac = new HMACSHA512();
                var passwordByte = Encoding.UTF8.GetBytes(authUserDto.password);
                var newUser = new UserEntity
                {
                    username = authUserDto.username,
                    passwordSalt = hmac.Key,
                    passwordHash = hmac.ComputeHash(passwordByte)
                };
                dataContext.users.Add(newUser);
                dataContext.SaveChanges();
                var token = tokenService.createToken(authUserDto.username);
                return Ok(token);
            }
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthUserDto authUserDto)
        {
            authUserDto.username = authUserDto.username.ToLower();
            var currentUser = dataContext.users.FirstOrDefault(u => u.username == authUserDto.username);
            if (currentUser == null)
            {
                return Unauthorized("Username is invalid!");
            }
            using var hmac = new HMACSHA512(currentUser.passwordSalt);
            var passwordByte = hmac.ComputeHash(Encoding.UTF8.GetBytes(authUserDto.password));
            for (int i = 0; i < currentUser.passwordHash.Length; i++)
            {
                if (currentUser.passwordHash[i] != passwordByte[i])
                {
                    return Unauthorized("Password is invalid!");
                }
            }
            var token = tokenService.createToken(authUserDto.username);
            return Ok(token);
        }
        [HttpGet("get")]
        public IActionResult Get()
        {
            return Ok(dataContext.users.ToList());
        }
    }
}