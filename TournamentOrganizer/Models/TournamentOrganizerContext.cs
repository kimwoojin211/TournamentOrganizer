using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace TournamentOrganizer.Models
{
  public class TournamentOrganizerContext : DbContext
  {
    public TournamentOrganizerContext(DbContextOptions<TournamentOrganizerContext> options)

      :base(options)
      {
      }
    

    public DbSet<Tournament> Tournaments { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Match> Matches { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
      // builder.Entity<HashSet<Player>>().HasNoKey();
      // builder.Entity<HashSet<Player>>().HasOne(u => u.Team).WithMany(u => u.TeamMembers);
    }

  }
}