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
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
    }
}