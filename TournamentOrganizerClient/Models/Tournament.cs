using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace TournamentOrganizerClient.Models
{
  public class Tournament
  {
    public Tournament()
    {
      this.Matches = new List<Match>();
      this.RegisteredUsers = new List<Account>();
    }
    public int TournamentId { get; set; }
    public string Name { get; set; }
    public string OrganizedBy { get; set; }
    public string Location { get; set; }
    public DateTime Time { get; set; }
    public string Category { get; set; }
    public List<Match> Matches { get; set; }
    public List<Account> RegisteredUsers { get; set; }
    
    // public virtual ICollection<User> Moderators { get; set; }
    // public virtual Bracket Bracket { get; set; }
    // public string Standings { get; set; }

    public static List<Tournament> GetTournaments()
    {
      var apiCalltask = ApiTournament.GetAll();
      var result = apiCalltask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Tournament> tournamentList = JsonConvert.DeserializeObject<List<Tournament>>(jsonResponse.ToString());

      return tournamentList;
    }

    public static void Post(Tournament tournament)
    {
      string jsonTournament = JsonConvert.SerializeObject(tournament);
      var apiCallTask = ApiTournament.Post(jsonTournament);
    }

    public static Tournament GetDetails(int id)
    {
      var apiCallTask = ApiTournament.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Tournament tournament = JsonConvert.DeserializeObject<Tournament>(jsonResponse.ToString());

      return tournament;
    }

    public static void Put(int id,Tournament tournament)
    {
      string jsonTournament = JsonConvert.SerializeObject(tournament);
      var apiCallTask = ApiTournament.Put(id, jsonTournament);
    }

    public static void Delete(int id)
    {
      var apiCallTask = ApiTournament.Delete(id);
    }
    public static List<Account> GetTournamentUsers(int tournamentId)
    {
      var apiCalltask = ApiTournament.GetTournamentUsers(tournamentId);
      var result = apiCalltask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Account> userList = JsonConvert.DeserializeObject<List<Account>>(jsonResponse.ToString());

      return userList;
    }
  }
}


