using System.ComponentModel.DataAnnotations;

namespace dating_app.api.Data.Entity
{
    public class UserEntity
    {
        [Key]
        public int userId { get; set; }
        [Required]
        [MaxLength(256)]
        public string username { get; set; }
        [MaxLength(256)]
        public string email { get; set; }
        public byte[] passwordHash { get; set; }
        public byte[] passwordSalt { get; set; }
    }
}