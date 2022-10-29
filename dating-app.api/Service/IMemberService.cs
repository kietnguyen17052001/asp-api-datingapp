using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dating_app.api.DTOs;

namespace dating_app.api.Service
{
    public interface IMemberService
    {
        List<MemberDto> getMembers();
        MemberDto getMember(string username);
    }
}