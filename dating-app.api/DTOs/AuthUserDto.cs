using System.ComponentModel.DataAnnotations;

namespace dating_app.api.DTOs
{
    public class AuthUserDto
    {
        [Required]
        [MaxLength(256)]
        public string username { get; set; }
        [Required]
        [MaxLength(256)]
        public string password { get; set; }
    }
}