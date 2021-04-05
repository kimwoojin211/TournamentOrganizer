namespace TournamentOrganizer.Models
{
  public class Player
  {
    public int PlayerId { get; set; }
    public int UserId { get; set; }

    public int Score { get; set; }

    public string CurrentMatch { get; set; }
    public string AllTournamentMatches { get; set; }
    public int TournamentId { get; set; }
  }
}