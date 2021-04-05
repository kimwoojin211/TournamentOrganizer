using Microsoft.EntityFrameworkCore;

namespace TournamentOrganizer.Models
{
  public class TournamentOrganizerContext : DbContext
  {
    public TournamentOrganizerContext(DbContextOptions<TournamentOrganizerContext> options)
      :base(options)
      {
      }
    
  }
}