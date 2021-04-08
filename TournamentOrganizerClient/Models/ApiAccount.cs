using System.Threading.Tasks;
using RestSharp;

namespace TournamentOrganizerClient.Models
{
  class ApiAccount
  {
    public static async Task<string> GetAll()
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"accounts", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> Get(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"accounts/{id}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> Register(string username, string password)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"accounts", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(
        new {Username=username,Password=password});
      var response = await client.ExecuteTaskAsync(request);
      System.Console.WriteLine(" " + response.Content + " r08237598237592385" );
      return response.Content;
    }
    public static async Task<string> Login(string username, string password)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"accounts/authenticate", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(
        new { Username = username, Password = password });
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
    public static async Task Put(int id, string account)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"accounts/{id}", Method.PUT);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(account);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task Delete(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"accounts/{id}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      var response = await client.ExecuteTaskAsync(request);
    }

  }
}

