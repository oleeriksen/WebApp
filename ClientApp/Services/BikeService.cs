using System.Net.Http.Json;
using Core.Model;

namespace ClientApp.Services
{
	public class BikeService : IBikeService
	{
        HttpClient http;

        // adresse på server
        private string serverUrl = "https://localhost:7060";

        public BikeService(HttpClient http)	{
            this.http = http;
        }

        public async Task<BEBike[]> GetAll() {
            var bikes = await http.GetFromJsonAsync<BEBike[]>($"{serverUrl}/api/bike");

            return bikes.ToArray();

        }

        public async Task Add(BEBike bike){
            await http.PostAsJsonAsync<BEBike>($"{serverUrl}/api/bike", bike);
        }
    }
}

