using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dating_app.api.Controllers
{
    [ApiController]
    [Authorize]
    public class BaseController : ControllerBase
    {
    }
}