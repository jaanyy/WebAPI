using FilmsProject.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsProject.DataAccessLayer.Context
{
    public class FilmsProjectDbContext : IdentityDbContext<User, Role, int>
    {
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Country> Countries{ get; set; }
        public DbSet<Favourite> Favourites{ get; set; }
        public DbSet<Film> Films{ get; set; }
        public DbSet<Genre> Genres{ get; set; }
        public DbSet<Participant> Participants{ get; set; }
        public DbSet<Rating> Ratings{ get; set; }

        public FilmsProjectDbContext(DbContextOptions<FilmsProjectDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Film>()
                .HasOne(f => f.Producer)
                .WithMany(p => p.ProducedFilms)
                .HasForeignKey(f=>f.ProducerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Film>()
                .HasMany(f => f.Actors)
                .WithMany(p => p.FilmsAsActor);

            builder.Entity<Film>()
                .HasMany(f => f.Genres)
                .WithMany(g => g.Films);

            builder.Entity<Film>()
                .HasOne(f => f.Country)
                .WithMany(c => c.Films)
                .HasForeignKey(f => f.CountryId);

            builder.Entity<Film>()
                .HasMany(f => f.Ratings)
                .WithOne(r=>r.Film)
                .HasForeignKey(r=>r.FilmId);

            builder.Entity<Film>()
                .HasMany(f => f.Comments)
                .WithOne(c => c.Film)
                .HasForeignKey(c => c.FilmId);

            builder.Entity<Film>()
                .HasMany(f => f.Favourites)
                .WithOne(f => f.Film)
                .HasForeignKey(f => f.FilmId);

            builder.Entity<Comment>()
                .HasKey("UserId", "FilmId", "Date");

            builder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId);

            builder.Entity<Favourite>()
                .HasKey("UserId", "FilmId");

            builder.Entity<Favourite>()
                .HasOne(f => f.User)
                .WithMany(u => u.Favourites)
                .HasForeignKey(f => f.UserId);

            builder.Entity<Rating>()
                .HasKey("UserId", "FilmId");

            builder.Entity<Rating>()
                .HasOne(r => r.User)
                .WithMany(u => u.Ratings)
                .HasForeignKey(r => r.UserId);

            builder.Entity<Country>()
                .HasData(new[] { new Country { Id = 1, Name = "Ukraine" } });
        }
    }
}
