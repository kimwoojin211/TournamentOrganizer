using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TournamentOrganizer
{
  public class Match
  {
     public int MatchId { get; set; }

        public string Players { get; set; }
     
        public string Format { get; set; }
     
        public string Category { get; set; }
        public int BracketId { get; set; }
        public int TournamentId { get; set; }
        public string Sets {get; set;}
        

    public static List<Match> GetMatches()
    {
      var apiCallTask = ApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Match> matchList = JsonConvert.DeserializeObject<List<Match>>(jsonResponse.ToString());

      return matchList;
    }

    public static Match GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      match match = JsonConvert.DeserializeObject<Match>(jsonResponse.ToString());

      return match;
    }

    public static void Post(Match match)
    {
      string jsonMatch = JsonConvert.SerializeObject(match);
      var apiCallTask = ApiHelper.Post(jsonMatch);
    }

    public static void Put(Match match)
    {
      string jsonMatch = JsonConvert.SerializeObject(match);
      var apiCallTask = ApiHelper.Put(match.MatchId, jsonMatch);
    }

    public static void Delete(int id)
    {
      var apiCallTask = ApiHelper.Delete(id);
    }
  }
}