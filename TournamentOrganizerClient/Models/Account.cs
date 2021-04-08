using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace TournamentOrganizerClient.Models
{
  public class Account
  {
    public Account()
    {
    }
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Region { get; set; }

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
      var result = apiCallTask.Result;
      Account account = new Account();
      if (result != null)
      {
        JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
        account = JsonConvert.DeserializeObject<Account>(jsonResponse.ToString());
      }
      return account;
    }

    public static bool Register(string username, string password, string email)
    {
      var apiCallTask = ApiAccount.Register(username, password, email);
      var result = apiCallTask.Result;
      Account account = new Account();
      return (result is null);
    }

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