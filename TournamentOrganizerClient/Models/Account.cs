using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace TournamentOrganizerClient.Models
{
  public class Account
  {
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Region { get; set; }
    public string Password { get; set; }
    public string Token { get; set; }
    public static List<Account> GetAccounts()
    {
      var apiCalltask = ApiAccount.GetAll();
      var result = apiCalltask.Result;
      List<Account> accountList = new List<Account>();

      if(result!=null && result.Length != 0)
      {
        JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
        accountList = JsonConvert.DeserializeObject<List<Account>>(jsonResponse.ToString());
      }
      return accountList;
    }

    public static Account GetDetails(int id)
    {
      var apiCallTask = ApiAccount.Get(id);
      System.Console.WriteLine("------------" + apiCallTask.ToString());
      var result = apiCallTask.Result;
      Account account = new Account();
      if (result != null)
      {
        JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      }

      return account;
    }

    // public static void Register(Account account)
    // {
    //   string jsonAccount = JsonConvert.SerializeObject(account);
    //   var apiCallTask = ApiAccount.Register(jsonAccount);
    // }

    // public static void Put(Account account)
    // {
    //   string jsonAccount = JsonConvert.SerializeObject(account);
    //   var appiCallTask = ApiAccount.Put(account.AccountId, jsonAccount);
    // }

    // public static void Delete(int id)
    // {
    //   var apiCallTask = ApiAccount.DeleteAccount(id);
    // }
  }
}