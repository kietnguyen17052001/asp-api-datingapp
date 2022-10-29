using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dating_app.api.Controllers;
using dating_app.api.DTOs;
using dating_app.api.Service;
using Microsoft.AspNetCore.Mvc;

namespace Namespace
{
    [Route("api/members")]
    public class MemberController : BaseController
    {
        private readonly IMemberService service;
        public MemberController(IMemberService _service)
        {
            service = _service;
        }
        [HttpGet]
        public ActionResult<List<MemberDto>> Get()
        {
            return Ok(service.getMembers());
        }

        [HttpGet("{username}")]
        public ActionResult<MemberDto> Get(string username)
        {
            return Ok(service.getMember(username));
        }
    }
}