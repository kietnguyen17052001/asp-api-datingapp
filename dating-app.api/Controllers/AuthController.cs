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

namespace dating_app.api.Controllers
{
    public class AuthController : BaseController
    {
        private readonly DataContext dataContext;
        public AuthController(DataContext dataContext)
        {
            this.dataContext = dataContext;

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
                return Ok(newUser.username);
            }
        }
        [HttpPost("login")]
        public void Login([FromBody] string value)
        {
        }
    }
}