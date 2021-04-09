using System.Threading.Tasks;
using RestSharp;

namespace TournamentOrganizerClient.Models
{
  class ApiAccount
  {
    public static async Task<string> GetAll()
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"users", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> Get(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"users/{id}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
    

    public static async Task<string> Register(string username, string password, string email)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"users", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(
        new {Username=username,Password=password,Email=email});
      var response = await client.ExecuteTaskAsync(request);

      return response.Content;
    }
    public static async Task<string> Login(string username, string password)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"users/authenticate", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(
        new { Username = username, Password = password });
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
    public static async Task Put(int id, string account)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"users/{id}", Method.PUT);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(account);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task Delete(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"users/{id}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      var response = await client.ExecuteTaskAsync(request);
    }
    
    public static async Task<string> GetUserTournaments(int userId)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"tournaments/?userId={userId}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
    
    public static async Task<string> GetUserMatches(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"matches/?userId={id}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
  }
}

