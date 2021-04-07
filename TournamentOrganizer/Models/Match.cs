using System.Collections.Generic;
using System;
using TournamentOrganizer.Entities;

namespace TournamentOrganizer.Models
{
  public class Match
  {
    public Match()
    {
      this.MatchUsers = new HashSet<MatchUser>();
    }
    public int MatchId { get; set; }

    public string Format { get; set; }

    public string Category { get; set; }
    public string Score { get; set; }
    public int TournamentId { get; set; }
    // public virtual Tournament Tournament { get; set; }
    // [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<MatchUser> MatchUsers { get; set; }

    // public ICollection<Player> Players { get; set; }
    // user clicks register for a tournament
    // user info -> player class
    // player class -> ICollection<Player> Team1
    // Team1 -> Tournament.Teams
    // Tournament.Teams == ICollection {ICollection Team1, .....}
  }
}