using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using dating_app.api.Data;
using dating_app.api.Data.Entity;
using dating_app.api.DTOs;

namespace dating_app.api.Service
{
    public class MemberService : IMemberService
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        public MemberService(DataContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }
        public MemberDto getMember(string username)
        {
            var user = context.users.FirstOrDefault(u => u.username.ToLower() == username.ToLower());
            if (user == null) return null;
            return mapper.Map<UserEntity, MemberDto>(user);
        }

        public List<MemberDto> getMembers()
        {
            return context.users.ProjectTo<MemberDto>(mapper.ConfigurationProvider)
            .ToList();
        }
    }
}