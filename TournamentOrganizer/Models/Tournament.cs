using System;
using System.Collections.Generic;
using TournamentOrganizer.Entities;

namespace TournamentOrganizer.Models
{
  public class Tournament
  {
    public Tournament()
    {
      this.RegisteredPlayers = new HashSet<User>();
      this.Moderators = new HashSet<User>();
    }
    public int TournamentId { get; set; }
    public string Name { get; set; }
    public string OrganizedBy { get; set; }
    public string Location { get; set; }
    public DateTime Time { get; set; }

    public string Category { get; set; }
    public virtual ICollection<User> RegisteredPlayers { get; set; }
    public virtual ICollection<User> Moderators { get; set; }
    // public virtual Bracket Bracket { get; set; }
    // public string Standings { get; set; }

  }
}