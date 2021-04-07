using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TournamentOrganizerClient.Models
{
  public class Player
  {
    public int PlayerId { get; set; }

    public int UserId { get; set; }

    public virtual User User {get; set;}

    public virtual Match CurrentMatch { get; set; }
    public virtual ICollection<Tournament> AllMatches { get; set; }
    public int TournamentId { get; set; }


    public static List<Player> GetPlayers()
    {
      var apiCallTask = ApiPlayer.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Player> playerList = JsonConvert.DeserializeObject<List<Player>>(jsonResponse.ToString());

      return playerList;
    }

    public static Player GetDetails(int id)
    {
      var apiCallTask = ApiPlayer.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Player player = JsonConvert.DeserializeObject<Player>(jsonResponse.ToString());

      return player;
    }

    public static void Post(Player player)
    {
      string jsonPlayer = JsonConvert.SerializeObject(player);
      var apiCallTask = ApiMatch.Post(jsonPlayer);
    }

    public static void Put(Player player)
    {
      string jsonPlayer = JsonConvert.SerializeObject(player);
      var apiCallTask = ApiPlayer.Put(player.PlayerId, jsonPlayer);
    }

    public static void Delete(int id)
    {
      var apiCallTask = ApiPlayer.Delete(id);
    }
  }
}