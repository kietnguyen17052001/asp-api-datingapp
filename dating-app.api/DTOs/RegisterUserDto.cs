using System.ComponentModel.DataAnnotations;

namespace dating_app.api.DTOs
{
    public class RegisterUserDto
    {
        [Required]
        [MaxLength(256)]
        public string username { get; set; }
        [MaxLength(256)]
        public string password { get; set; }
        [MaxLength(256)]
        public string email { get; set; }
        public DateTime? dateOfBirth { get; set; }
        [MaxLength(32)]
        public string knowAs { get; set; }
        [MaxLength(6)]
        public string gender { get; set; }
        [MaxLength(256)]
        public string introduction { get; set; }
        [MaxLength(32)]
        public string city { get; set; }
        [MaxLength(256)]
        public string avatar { get; set; }
    }
}