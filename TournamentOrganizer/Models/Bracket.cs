using System.Collections.Generic;

namespace TournamentOrganizer.Models
{
  public class Bracket
  {
    public Bracket()
    {
    }
    public int BracketId { get; set; }
    public string Format { get; set; }
    // i want to use a binary tree. D: ~Wooj
    public ICollection<Match> Matches { get; set; }
  }
}