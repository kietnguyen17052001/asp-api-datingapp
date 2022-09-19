using dating_app.api.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace dating_app.api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<UserEntity> users { get; set; }
    }
}