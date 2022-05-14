using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Wheat.Models.Entities;

namespace Wheat.DataLayer.DataBase
{
    public class WheatDbContext : IdentityDbContext<WIdentityUser>
    {
        public WheatDbContext(DbContextOptions<WheatDbContext> options):base(options){}
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
        public virtual DbSet<SellContract> SellContracts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<WIdentityUser>().HasIndex(u=>u.Code).IsUnique();
            base.OnModelCreating(builder);
        }
    }
}
