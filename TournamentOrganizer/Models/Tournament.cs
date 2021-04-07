using System;
using System.Collections.Generic;
using TournamentOrganizer.Entities;

namespace TournamentOrganizer.Models
{
  public class Tournament
  {
    public Tournament()
    {
      this.Matches = new HashSet<Match>();
      this.TournamentUsers = new HashSet<TournamentUser>();
      // this.Moderators = new HashSet<User>();
    }
    public int TournamentId { get; set; }
    public string Name { get; set; }
    public string OrganizedBy { get; set; }
    public string Location { get; set; }
    public DateTime Time { get; set; }

    public string Category { get; set; }
    public ICollection<Match> Matches { get; set; }
    // [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TournamentUser> TournamentUsers { get; set; }
    // public virtual ICollection<User> Moderators { get; set; }
    // public virtual Bracket Bracket { get; set; }
    // public string Standings { get; set; }

  }
}