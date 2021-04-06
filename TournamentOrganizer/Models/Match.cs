using System.Collections.Generic;
using System;


namespace TournamentOrganizer.Models
{
  public class Match
  {
    public Match()
    {
      this.Teams = new HashSet<Player>>();
    }
    public int MatchId { get; set; }

    public string Format { get; set; }

    public string Category { get; set; }
    public int TournamentId { get; set; }
    public string Score { get; set; }

    public virtual HashSet<Player> Players { get; set; }

    // public ICollection<Player> Players { get; set; }
    // user clicks register for a tournament
    // user info -> player class
    // player class -> ICollection<Player> Team1
    // Team1 -> Tournament.Teams
    // Tournament.Teams == ICollection {ICollection Team1, .....}
  }
}