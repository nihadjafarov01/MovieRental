using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieRental.Core.Models;
using MovieRental.Core.Models.Common;
using System.Collections.Generic;

namespace MovieRental.DAL.Contexts
{
    public class MovieRentalDbContext : IdentityDbContext
    {
        public MovieRentalDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker
                 .Entries<BaseModel>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedTime = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedTime = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Review>()
                .HasOne(r => r.Movie)
                .WithMany(m => m.Reviews);

            builder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(m => m.Reviews);

            builder.Entity<AppUser>()
                .HasMany(u => u.Reviews)
                .WithOne(r => r.User);

            builder.Entity<Movie>()
                .HasMany(m => m.Reviews)
                .WithOne(r => r.Movie);

            base.OnModelCreating(builder);
        }

    }
}
