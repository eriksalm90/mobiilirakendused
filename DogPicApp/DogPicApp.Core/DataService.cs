using Newtonsoft.Json;
using StarwarsApp.Core.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace StarwarsApp.Core
{
    public class DataService
    {
        public static async Task<Breeds> GetDogByBreed(string breed)
        {
            var query = "https://dog.ceo/api/breed/" + breed + "/images/random";
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(query);

            Breeds data = null;
            if (response != null)
            {
                data = JsonConvert.DeserializeObject<Breeds>(response);
            }
            return data;
        }

        public static async Task<RandomDogs> GetRandomDog(string breed)
        {
            string query = "";
            if (breed=="random") { 
                query = "https://dog.ceo/api/breeds/image/random";
            }
            else
            {
                query = "https://dog.ceo/api/breed/" + breed + "/images/random";
            }

            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(query);

            RandomDogs data = null;
            if (response != null)
            {
                data = JsonConvert.DeserializeObject<RandomDogs>(response);
            }
            return data;
        }

        public static async Task<Breeds> GetAllBreeds()
        {
            var query = "https://dog.ceo/api/breeds/list/all";
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(query);

            Breeds data = null;
            if (response != null)
            {
                data = JsonConvert.DeserializeObject<Breeds>(response);
            }
            return data;
        }

    }
}
