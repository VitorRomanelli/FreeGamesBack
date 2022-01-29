using FreeGamesConsume.Models;
using Newtonsoft.Json;
using RestSharp;

namespace FreeGamesConsume.Services
{
    public class GameService
    {
        public async Task<ResponseModel> List()
        {
            var client = new RestClient("https://www.freetogame.com/api/games");
            var request = new RestRequest("", Method.Get);
            RestResponse response = await client.ExecuteAsync(request);
            var games = JsonConvert.DeserializeObject<List<Game>>(response.Content);

            return new ResponseModel(200, games);
        }
    }
}
