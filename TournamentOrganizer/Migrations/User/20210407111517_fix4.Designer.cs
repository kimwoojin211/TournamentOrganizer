﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TournamentOrganizer.Entities;

namespace TournamentOrganizer.Migrations.User
{
    [DbContext(typeof(UserContext))]
    [Migration("20210407111517_fix4")]
    partial class fix4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("TournamentOrganizer.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Password")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Region")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Token")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Username")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "joebud@budd.com",
                            Name = "Joe Buden",
                            Password = "test",
                            Region = "Los Angeles, CA, USA",
                            Username = "test"
                        },
                        new
                        {
                            UserId = 2,
                            Email = "joebuddy@budd.com",
                            Name = "Joe Buddy",
                            Password = "test2",
                            Region = "Los Angeles, CA, USA",
                            Username = "test2"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
