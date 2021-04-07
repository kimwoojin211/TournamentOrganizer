﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TournamentOrganizer.Models;

namespace TournamentOrganizer.Migrations
{
    [DbContext(typeof(TournamentOrganizerContext))]
    [Migration("20210407111504_fix4")]
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

                    b.ToTable("User");
                });

            modelBuilder.Entity("TournamentOrganizer.Models.Match", b =>
                {
                    b.Property<int>("MatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Format")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Score")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("TournamentId")
                        .HasColumnType("int");

                    b.HasKey("MatchId");

                    b.HasIndex("TournamentId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("TournamentOrganizer.Models.MatchUser", b =>
                {
                    b.Property<int>("MatchUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("MatchId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("MatchUserId");

                    b.HasIndex("MatchId");

                    b.HasIndex("UserId");

                    b.ToTable("MatchUsers");
                });

            modelBuilder.Entity("TournamentOrganizer.Models.Tournament", b =>
                {
                    b.Property<int>("TournamentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Location")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("OrganizedBy")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime(6)");

                    b.HasKey("TournamentId");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("TournamentOrganizer.Models.TournamentUser", b =>
                {
                    b.Property<int>("TournamentUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("TournamentId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("TournamentUserId");

                    b.HasIndex("TournamentId");

                    b.HasIndex("UserId");

                    b.ToTable("TournamentUsers");
                });

            modelBuilder.Entity("TournamentOrganizer.Models.Match", b =>
                {
                    b.HasOne("TournamentOrganizer.Models.Tournament", null)
                        .WithMany("Matches")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TournamentOrganizer.Models.MatchUser", b =>
                {
                    b.HasOne("TournamentOrganizer.Models.Match", "Match")
                        .WithMany("MatchUsers")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TournamentOrganizer.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Match");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TournamentOrganizer.Models.TournamentUser", b =>
                {
                    b.HasOne("TournamentOrganizer.Models.Tournament", "Tournament")
                        .WithMany("TournamentUsers")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TournamentOrganizer.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tournament");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TournamentOrganizer.Models.Match", b =>
                {
                    b.Navigation("MatchUsers");
                });

            modelBuilder.Entity("TournamentOrganizer.Models.Tournament", b =>
                {
                    b.Navigation("Matches");

                    b.Navigation("TournamentUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
