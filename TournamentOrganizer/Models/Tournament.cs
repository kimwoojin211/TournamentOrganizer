using System;
using System.Collections.Generic;

namespace TournamentOrganizer.Models
{
  public class Tournament
  {
    public Tournament()
    {
      this.RegisteredPlayers = new HashSet<PlayerTournament>();
      // this.Moderators = new HashSet<UserTournament>();
    }
    public int TournamentId { get; set; }
    public string Name { get; set; }
    public string OrganizedBy { get; set; }
    public string Location { get; set; }
    public DateTime Time { get; set; }

    public string Category { get; set; }
    public virtual ICollection<PlayerTournament> RegisteredPlayers { get; }
    // public virtual ICollection<UserTournament> Moderators { get; }
    // public virtual Bracket Bracket { get; set; }
    // public string Standings { get; set; }

  }
}