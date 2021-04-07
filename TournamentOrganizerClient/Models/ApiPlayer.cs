// using System.Threading.Tasks;
// using RestSharp;

// namespace TournamentOrganizerClient.Models
// {
//   class ApiPlayer
//   {
//     public static async Task<string> GetAll()
//     {
//       RestClient client = new RestClient("http://localhost:5000/api");
//       RestRequest request = new RestRequest($"players", Method.GET);
//       var response = await client.ExecuteTaskAsync(request);
//       return response.Content;
//     }

//     public static async Task<string> Get(int id)
//     {
//       RestClient client = new RestClient("http://localhost:5000/api");
//       RestRequest request = new RestRequest($"players/{id}", Method.GET);
//       var response = await client.ExecuteTaskAsync(request);
//       return response.Content;
//     }

//     public static async Task Post(string newPlayer)
//     {
//       RestClient client = new RestClient("http://localhost:5000/api");
//       RestRequest request = new RestRequest($"players", Method.POST);
//       request.AddHeader("Content-Type", "application/json");
//       request.AddJsonBody(newPlayer);
//       var response = await client.ExecuteTaskAsync(request);
//     }

//     public static async Task Put(int id, string newPlayer)
//     {
//       RestClient client = new RestClient("http://localhost:5000/api");
//       RestRequest request = new RestRequest($"players/{id}", Method.PUT);
//       request.AddHeader("Content-Type", "application/json");
//       request.AddJsonBody(newPlayer);
//       var response = await client.ExecuteTaskAsync(request);
//     }

//     public static async Task Delete(int id)
//     {
//       RestClient client = new RestClient("http://localhost:5000/api");
//       RestRequest request = new RestRequest($"players/{id}", Method.DELETE);
//       request.AddHeader("Content-Type", "application/json");
      
//       var response = await client.ExecuteTaskAsync(request);
//     }
//   }
// }