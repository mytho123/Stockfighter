using Stockfighter.Helpers;
using Stockfighter.HttpModels;
using System;
using System.Threading.Tasks;

namespace Stockfighter
{
    public class GameMaster
    {
        private const string gmUrl = "https://www.stockfighter.io/gm/";
        private const string uiUrl = "https://www.stockfighter.io/ui/levels";

        public GameMaster(string apiKey)
        {
            this.ApiKey = apiKey;
        }

        public string ApiKey { get; set; }

        public async Task<LevelResponse> GetLevel(string levelName)
        {
            using (var client = new Client(ApiKey))
            {
                var response = await client.Post<LevelResponse>(gmUrl, $"levels/{levelName}", null).ConfigureAwait(false);

                if (!response.Ok)
                {
                    throw new Exception($"Got ok == false while getting level {levelName}.");
                }

                return response;
            }
        }
    }
}