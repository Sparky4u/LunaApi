using Microsoft.EntityFrameworkCore;
using LunaApi.Common.Models;

namespace LunaApi.DAL.Data
{
    public class LunaDbContext : DbContext
    {
        public LunaDbContext(DbContextOptions<LunaDbContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}
