﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Popcorn_Box_Backend.Models;

#nullable disable

namespace Popcorn_Box_Backend.Migrations
{
    [DbContext(typeof(PopcornBoxDbContext))]
    [Migration("20230531083507_AddingFavouriteMedia")]
    partial class AddingFavouriteMedia
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Popcorn_Box_Backend.Models.FavouriteMedia", b =>
                {
                    b.Property<int>("FavId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FavId"));

                    b.Property<int>("MediaId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("FavId");

                    b.HasIndex("MediaId");

                    b.HasIndex("UserId");

                    b.ToTable("FavoriteMedia");
                });

            modelBuilder.Entity("Popcorn_Box_Backend.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenreId"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreId");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Popcorn_Box_Backend.Models.Media", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Actors")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Directors")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("FullLength")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<int>("MediaId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Thumbnail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Trailer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Year")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("GenreId");

                    b.HasIndex("MediaId");

                    b.ToTable("Medias");
                });

            modelBuilder.Entity("Popcorn_Box_Backend.Models.MediaType", b =>
                {
                    b.Property<int>("MediaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MediaId"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MediaId");

                    b.ToTable("MediaTypes");
                });

            modelBuilder.Entity("Popcorn_Box_Backend.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Popcorn_Box_Backend.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("IsApproved")
                        .HasColumnType("int");

                    b.Property<bool>("IsSubscribed")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<byte[]>("ProfilePic")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Popcorn_Box_Backend.Models.FavouriteMedia", b =>
                {
                    b.HasOne("Popcorn_Box_Backend.Models.Media", "media")
                        .WithMany("FavouriteMediaCollection")
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Popcorn_Box_Backend.Models.User", "user")
                        .WithMany("FavouriteMediaCollection")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("media");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Popcorn_Box_Backend.Models.Media", b =>
                {
                    b.HasOne("Popcorn_Box_Backend.Models.User", "User")
                        .WithMany("MediasCollection")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Popcorn_Box_Backend.Models.Genre", "Genre")
                        .WithMany("MediasCollection")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Popcorn_Box_Backend.Models.MediaType", "MediaType")
                        .WithMany("MediasCollection")
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("MediaType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Popcorn_Box_Backend.Models.User", b =>
                {
                    b.HasOne("Popcorn_Box_Backend.Models.Role", "Role")
                        .WithMany("UsersCollection")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Popcorn_Box_Backend.Models.Genre", b =>
                {
                    b.Navigation("MediasCollection");
                });

            modelBuilder.Entity("Popcorn_Box_Backend.Models.Media", b =>
                {
                    b.Navigation("FavouriteMediaCollection");
                });

            modelBuilder.Entity("Popcorn_Box_Backend.Models.MediaType", b =>
                {
                    b.Navigation("MediasCollection");
                });

            modelBuilder.Entity("Popcorn_Box_Backend.Models.Role", b =>
                {
                    b.Navigation("UsersCollection");
                });

            modelBuilder.Entity("Popcorn_Box_Backend.Models.User", b =>
                {
                    b.Navigation("FavouriteMediaCollection");

                    b.Navigation("MediasCollection");
                });
#pragma warning restore 612, 618
        }
    }
}
