using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TournamentOrganizerClient.Models
{
  public class Match
  {
    public int MatchId { get; set; }

    public string Format { get; set; }

    public string Category { get; set; }
    public string Score { get; set; }
    public int TournamentId { get; set; }


    public static List<Match> GetMatches()
    {
      var apiCalltask = ApiMatch.GetAll();
      var result = apiCalltask.Result;
      List<Match> matchList = new List<Match>();

      if(result!=null && result.Length != 0)
      {
        JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
        matchList = JsonConvert.DeserializeObject<List<Match>>(jsonResponse.ToString());
      }
      return matchList;
    }

    public static Match GetDetails(int id)
    {
      var apiCallTask = ApiMatch.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Match match = JsonConvert.DeserializeObject<Match>(jsonResponse.ToString());

      return match;
    }

    public static void Post(Match match)
    {
      string jsonMatch = JsonConvert.SerializeObject(match);
      var apiCallTask = ApiMatch.Post(jsonMatch);
    }

    public static void Put(Match match)
    {
      string jsonMatch = JsonConvert.SerializeObject(match);
      var apiCallTask = ApiMatch.Put(match.MatchId, jsonMatch);
    }

    public static void Delete(int id)
    {
      var apiCallTask = ApiMatch.Delete(id);
    }
  }
}