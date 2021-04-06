namespace TournamentOrganizer.Models
{
  public class PlayerTournament
  {
    public int PlayerTournamentId { get; set; }
    public int PlayerId { get; set; }
    public int TournamentId { get; set; }
    public virtual Player Player { get; set; }
    public virtual Tournament Tournament { get; set; }

  }
}