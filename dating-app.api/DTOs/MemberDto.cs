using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dating_app.api.DTOs
{
    public class MemberDto
    {
        public string username { get; set; }
        public string email { get; set; }
        public int age { get; set; }
        public string knowAs { get; set; }
        public string gender { get; set; }
        public string introduction { get; set; }
        public string city { get; set; }
        public string avatar { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
    }
}