using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieRatingSystem.Application.Entities;
using MovieRatingSystem.Domain.Entities;

namespace MovieRatingSystem.Infrastructure.Data;

public class MovieRatingDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<TvShow> TvShows { get; set; }
    public DbSet<Rating> Ratings { get; set; }
    public DbSet<UserList> UserLists { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }

    public MovieRatingDbContext(DbContextOptions<MovieRatingDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Rating>().HasKey(r => new { r.UserId, r.MediaId });
        builder.Entity<UserList>().HasKey(ul => new { ul.UserId, ul.MediaId, ul.ListType });

        builder.Entity<RefreshToken>(entity =>
        {
            entity.HasKey(rt => rt.Id);
            entity.HasIndex(rt => rt.UserId);
            entity.Property(rt => rt.Token).IsRequired();
            entity.HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(rt => rt.UserId);
        });

        builder.Entity<Movie>().HasData(
            new Movie { Id = 1, Title = "Inception", ReleaseYear = 2010, Rating = 8.8m, Type = Domain.Enums.MediaType.Movie }
        );
    }
}