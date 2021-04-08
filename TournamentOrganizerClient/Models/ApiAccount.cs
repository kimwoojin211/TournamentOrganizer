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
      System.Console.WriteLine($"2 {username} + {password} + {email}");
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"users", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(
        new
        {
          Username=username,Password=password,Email=email});
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
  }
}

