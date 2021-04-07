using TournamentOrganizer.Entities;

namespace TournamentOrganizer.Models
{
  public class TournamentUser
  {
    public int TournamentUserId { get; set; }
    public int UserId { get; set; }
    public int TournamentId { get; set; }
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual User User { get; set; }
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual Tournament Tournament { get; set; }

  }
}