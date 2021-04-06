﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TournamentOrganizer.Models;

namespace TournamentOrganizer.Migrations
{
    [DbContext(typeof(TournamentOrganizerContext))]
    partial class TournamentOrganizerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("TournamentOrganizer.Models.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AllTournamentMatches")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("CurrentMatch")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<int>("TournamentId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PlayerId");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("TournamentOrganizer.Models.PlayerTournament", b =>
                {
                    b.Property<int>("PlayerTournamentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("TournamentId")
                        .HasColumnType("int");

                    b.HasKey("PlayerTournamentId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("TournamentId");

                    b.ToTable("PlayerTournament");
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

            modelBuilder.Entity("TournamentOrganizer.Models.PlayerTournament", b =>
                {
                    b.HasOne("TournamentOrganizer.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TournamentOrganizer.Models.Tournament", "Tournament")
                        .WithMany("RegisteredPlayers")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("TournamentOrganizer.Models.Tournament", b =>
                {
                    b.Navigation("RegisteredPlayers");
                });
#pragma warning restore 612, 618
        }
    }
}
