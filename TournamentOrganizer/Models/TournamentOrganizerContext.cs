using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TournamentOrganizer.Entities;

namespace TournamentOrganizer.Models
{
  public class TournamentOrganizerContext : DbContext
  {
    public TournamentOrganizerContext(DbContextOptions<TournamentOrganizerContext> options)
      :base(options)
      {
      }

    public DbSet<Tournament> Tournaments { get; set; }
    public DbSet<Match> Matches { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<MatchUser> MatchUsers { get; set; }
    public DbSet<TournamentUser> TournamentUsers { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Tournament>()
      .HasData(
        new Tournament{
          TournamentId=1,
          Name="test1",
          OrganizedBy="JoJo OntheRadio",
          Location="West Coast",
          Category="Game",
        });
      builder.Entity<Match>()
      .HasData(
        new Match{
          MatchId=1,
          Format="First to 5",
          Category="Game",
          Score="1-1",
          TournamentId=1,
        });
      builder.Entity<User>()
          .HasData(
            new User{
              UserId= 1, 
              Username= "test",
              Password= "test",
              Name= "Joe Buden",
              Email= "joebud@budd.com",
              Region= "Los Angeles, CA, USA",
            },
            new User
            {
              UserId = 2,
              Username = "test2",
              Password = "test2",
              Name = "Joe Buddy",
              Email = "joebuddy@budd.com",
              Region = "Los Angeles, CA, USA",
            });
    }
  }
}