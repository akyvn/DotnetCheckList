using Microsoft.EntityFrameworkCore;

namespace checkList.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<UserCheckListItem> UserCheckListItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
            .HasMany(u => u.userCheckListItems)
            .WithOne(uc => uc.user)
            .HasForeignKey(uc => uc.UserId);
        }
    }
}