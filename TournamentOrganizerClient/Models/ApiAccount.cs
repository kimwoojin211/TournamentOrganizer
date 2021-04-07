using System.Threading.Tasks;
using RestSharp;

namespace TournamentOrganizerClient.Models
{
  class ApiAccount
  {
    public static async Task<string> GetAll()
    {
      System.Console.WriteLine("0");
      RestClient client = new RestClient("http://localhost:5000/api");
      System.Console.WriteLine("1");
      RestRequest request = new RestRequest($"users", Method.GET);
      System.Console.WriteLine("2");
      var response = await client.ExecuteTaskAsync(request);
      System.Console.WriteLine($"3 {response.Content}");
      return response.Content;
    }
  }
}

