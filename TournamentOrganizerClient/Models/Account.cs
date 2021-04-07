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
      System.Console.WriteLine("11");
      var apiCalltask = ApiAccount.GetAll();
      System.Console.WriteLine("12");
      var result = apiCalltask.Result;

      System.Console.WriteLine($"13 {apiCalltask.Result}");
      System.Console.WriteLine("check");
      if(result!=null && result.Length != 0)
      {
        JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);

        System.Console.WriteLine($"14 {jsonResponse.ToString()}");
        List<Account> accountList = JsonConvert.DeserializeObject<List<Account>>(jsonResponse.ToString());

        System.Console.WriteLine("15");
        return accountList;
      }
      else
      {
        return new List<Account>();
      }
    }

    // public static Account GetDetails(int id)
    // {
    //   var apiCallTask = ApiAccount.GetAccount(id);
    //   var result = apiCallTask.Result;

    //   JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
    //   Account account = JsonConvert.DeserializeObject<Account>(jsonResponse.ToString());

    //   return account;
    // }

    // public static void Post(Account account)
    // {
    //   string jsonAccount = JsonConvert.SerializeObject(account);
    //   var apiCallTask = ApiAccount.PostAccount(jsonAccount);
    // }

    // public static void Put(Account account)
    // {
    //   string jsonAccount = JsonConvert.SerializeObject(account);
    //   var appiCallTask = ApiAccount.PutAccount(account.AccountId, jsonAccount);
    // }

    // public static void Delete(int id)
    // {
    //   var apiCallTask = ApiAccount.DeleteAccount(id);
    // }
  }
}