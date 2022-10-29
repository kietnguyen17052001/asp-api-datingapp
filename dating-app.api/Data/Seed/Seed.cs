using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using dating_app.api.Data.Entity;

namespace dating_app.api.Data.Seed
{
    public class Seed
    {
        public static void SeedUsers(DataContext context)
        {
            if (context.users.Any()) return;
            var userFile = System.IO.File.ReadAllText("Data/Seed/User.json");
            var users = JsonSerializer.Deserialize<List<UserEntity>>(userFile);
            if (users == null) return;
            foreach (var user in users)
            {
                using var hmac = new HMACSHA512();
                user.passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Prot3ct3d"));
                user.passwordSalt = hmac.Key;
                user.createdAt = DateTime.Now;
                context.users.Add(user);
            }
            context.SaveChanges();
        }
    }
}