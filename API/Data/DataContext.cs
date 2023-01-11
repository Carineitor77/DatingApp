using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<AppUser> Users => Set<AppUser>();
        public DbSet<UserLike> Likes => Set<UserLike>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserLike>()
                .HasKey(k => new { k.SourceUserId, k.LikedUserId });

            builder.Entity<UserLike>()
                .HasOne(s => s.SourceUser)
                .WithMany(l => l.LikedUsers)
                .HasForeignKey(s => s.SourceUserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<UserLike>()
                .HasOne(l => l.LikedUser)
                .WithMany(s => s.LikedByUsers)
                .HasForeignKey(l => l.LikedUserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
