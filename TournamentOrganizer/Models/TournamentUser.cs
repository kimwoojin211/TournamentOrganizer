using TournamentOrganizer.Entities;

namespace TournamentOrganizer.Models
{
  public class TournamentUser
  {
    public int TournamentUserId { get; set; }
    public int UserId { get; set; }
    public int TournamentId { get; set; }
    public virtual User User { get; set; }
    public virtual Tournament Tournament { get; set; }

  }
}