using System.Collections.Generic;
namespace TournamentOrganizer.Models
{
  public class Player
  {
    public Player()
    {
      this.AllTournamentMatches = new HashSet<Tournament>();
    }
    public int PlayerId { get; set; }
    public int UserId { get; set; }

    public int Score { get; set; }

    public virtual Match CurrentMatch { get; set; }
    public virtual ICollection<Tournament> AllTournamentMatches { get; }
    public int TournamentId { get; set; }
  }
}