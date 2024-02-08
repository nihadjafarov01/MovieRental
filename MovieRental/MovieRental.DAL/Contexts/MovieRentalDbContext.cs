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
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<WatchList> WatchLists { get; set; }
        public DbSet<WatchListType> WatchListTypes { get; set; }

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
            builder.Entity<Review>(r =>
            {
                r.HasKey(r => new { r.MovieId, r.UserId });
                r.Property(r => r.Id).UseIdentityColumn();

                r.HasOne(r => r.Movie)
                    .WithMany(m => m.Reviews);

                r.HasOne(r => r.User)
                    .WithMany(u => u.Reviews);
            });

            builder.Entity<AppUser>(u =>
            {
                u.HasMany(u => u.Reviews)
                    .WithOne(r => r.User);

                u.HasMany(u => u.Posts)
                    .WithOne(p => p.User);

                u.HasMany(u => u.Comments)
                    .WithOne(c => c.User);

                u.HasMany(u => u.WatchLists)
                    .WithOne(c => c.User);  
            });

            builder.Entity<Movie>(m =>
            {
                m.HasMany(m => m.Reviews)
                    .WithOne(r => r.Movie);

                m.HasMany(m => m.Posts)
                    .WithOne(p => p.Movie);

                m.HasMany(m => m.WatchLists)
                    .WithOne(c => c.Movie);
            });

            builder.Entity<Tag>(t =>
            {
                t.HasMany(t => t.Posts)
                    .WithOne(p => p.Tag);
            });

            builder.Entity<Post>(p =>
            {
                p.HasOne(p => p.Tag)
                    .WithMany(t => t.Posts);

                p.HasOne(p => p.Movie)
                    .WithMany(m => m.Posts)
                    .IsRequired(false);

                p.HasOne(p => p.User)
                    .WithMany(u => u.Posts);
            });

            builder.Entity<Comment>(c =>
            {
                c.HasOne(c => c.Post)
                    .WithMany(p => p.Comments)
                    .OnDelete(DeleteBehavior.NoAction);

                c.HasOne(c => c.User)
                    .WithMany(u => u.Comments);

                c.HasOne(c => c.ParentComment)
                    .WithMany(pc => pc.ChildComments)
                    .IsRequired(false);

                c.HasMany(c => c.ChildComments)
                    .WithOne(cc => cc.ParentComment)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<WatchList>(w =>
            {
                w.HasKey(w => new { w.MovieId, w.UserId });

                w.HasOne(w => w.User)
                    .WithMany(u => u.WatchLists);

                w.HasOne(w => w.Movie)
                    .WithMany(m => m.WatchLists);

                w.HasOne(w => w.Type)
                    .WithMany(t => t.WatchLists);
            });

            builder.Entity<WatchListType>(wt =>
            {
                wt.HasMany(wt => wt.WatchLists)
                    .WithOne(w => w.Type);
            });

            base.OnModelCreating(builder);
        }

    }
}
