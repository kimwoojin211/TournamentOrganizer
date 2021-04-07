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
    protected override void OnModelCreating(ModelBuilder builder)
    {
    }

  }
}