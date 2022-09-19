using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace dating_app.api.Controllers
{
    public class AuthController : BaseController
    {
        [HttpPost("register")]
        public void Register([FromBody] string value)
        {
        }
        [HttpPost("login")]
        public void Login([FromBody] string value)
        {
        }
    }
}