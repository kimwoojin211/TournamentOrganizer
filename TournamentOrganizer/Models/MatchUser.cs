using TournamentOrganizer.Entities;

namespace TournamentOrganizer.Models
{
  public class MatchUser
  {
    public int MatchUserId { get; set; }
    public int UserId { get; set; }
    public int MatchId { get; set; }
    public virtual User User { get; set; }
    public virtual Match Match { get; set; }

  }
}