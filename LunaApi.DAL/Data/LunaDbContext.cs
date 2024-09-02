using Microsoft.EntityFrameworkCore;
using LunaApi.Common.Models;
using LunaApi.DAL.Configurations;

namespace LunaApi.DAL.Data
{
    public class LunaDbContext : DbContext
    {
        public LunaDbContext(DbContextOptions<LunaDbContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<TaskEntity> TaskEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new TaskEntityConfiguration());
        }
    }
}
