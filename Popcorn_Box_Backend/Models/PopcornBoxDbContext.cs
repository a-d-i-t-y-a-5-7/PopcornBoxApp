using Microsoft.EntityFrameworkCore;
using Popcorn_Box_Backend.Migrations;
using System.Diagnostics;

namespace Popcorn_Box_Backend.Models
{
    public class PopcornBoxDbContext : DbContext
    {
        public PopcornBoxDbContext(DbContextOptions<PopcornBoxDbContext>options):base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MediaType> MediaTypes { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<FavouriteMedia> FavoriteMedia { get; set; }
        public DbSet<FavouriteSong> FavoriteSong { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("MyCon"));
        }*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);

            modelBuilder.Entity<User>()
                .HasOne<Role>(r => r.Role)
                .WithMany(u => u.UsersCollection)
                .HasForeignKey(u => u.RoleId);

            modelBuilder.Entity<Role>()
                .HasKey(r => r.RoleId);

            modelBuilder.Entity<Role>()
                .HasMany<User>(r => r.UsersCollection)
                .WithOne(u => u.Role)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Genre>()
                .HasKey(g => g.GenreId);

            modelBuilder.Entity<Genre>()
                .HasMany<Media>(m => m.MediasCollection)
                .WithOne(m => m.Genre)
                .HasForeignKey(m => m.GenreId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MediaType>()
                .HasKey(g => g.MediaId);

            modelBuilder.Entity<MediaType>()
                .HasMany<Media>(m => m.MediasCollection)
                .WithOne(m => m.MediaType)
                .HasForeignKey(m => m.MediaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Media>()
                .HasKey(g => g.Id);

            modelBuilder.Entity<Media>()
                .HasOne<Genre>(g => g.Genre)
                .WithMany(g => g.MediasCollection)
                .HasForeignKey(g => g.GenreId);

            modelBuilder.Entity<Media>()
                .HasOne<MediaType>(m => m.MediaType)
                .WithMany(m => m.MediasCollection)
                .HasForeignKey(m => m.MediaId);

            modelBuilder.Entity<Media>()
                .HasOne<User>(u => u.User)
                .WithMany(u => u.MediasCollection)
                .HasForeignKey(u => u.ClientId);

            modelBuilder.Entity<Song>()
                .HasKey(s => s.SongsId);

            modelBuilder.Entity<Song>()
                .HasOne<Genre>(g => g.Genre)
                .WithMany(g => g.SongsCollection)
                .HasForeignKey(g => g.GenreId);

            modelBuilder.Entity<Song>()
                .HasOne<User>(u => u.User)
                .WithMany(u => u.SongsCollection)
                .HasForeignKey(u => u.ClientId);

            modelBuilder.Entity<FavouriteMedia>()
                .HasKey(fm => fm.FavId);

            modelBuilder.Entity<FavouriteMedia>()
                .HasOne<User>(fm => fm.user)
                .WithMany(u => u.FavouriteMediaCollection)
                .HasForeignKey(fm => fm.UserId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<FavouriteMedia>()
                .HasOne<Media>(fm => fm.media)
                .WithMany(m => m.FavouriteMediaCollection)
                .HasForeignKey(fm => fm.MediaId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Media>()
                .HasMany<FavouriteMedia>(m => m.FavouriteMediaCollection)
                .WithOne(fm => fm.media)
                .HasForeignKey(fm => fm.MediaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany<Media>(u => u.MediasCollection)
                .WithOne(m => m.User)
                .HasForeignKey(m => m.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany<FavouriteMedia>(u => u.FavouriteMediaCollection)
                .WithOne(fm => fm.user)
                .HasForeignKey(fm => fm.UserId);

            modelBuilder.Entity<FavouriteSong>()
                .HasKey(fs => fs.FavSongId);

            modelBuilder.Entity<FavouriteSong>()
                .HasOne<User>(fs => fs.user)
                .WithMany(u => u.FavSongsCollection)
                .HasForeignKey(fs => fs.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<FavouriteSong>()
                .HasOne<Song>(fs => fs.song)
                .WithMany(s => s.FavSongCollection)
                .HasForeignKey(fs => fs.SongId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Song>()
                .HasMany<FavouriteSong>(s => s.FavSongCollection)
                .WithOne(fs => fs.song)
                .HasForeignKey(fs => fs.SongId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
