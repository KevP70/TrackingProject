using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProjetSuiviGeekServer.Controller
{
    public class SearchController
    {
        static async Task Main(string[] args)
        {
            string userInput = GetUserInput(); // Obtenez l'entrée de l'utilisateur depuis un input

            if (!string.IsNullOrWhiteSpace(userInput))
            {
                await SearchMedia(userInput);
            }
            else
            {
                Console.WriteLine("Please provide a search query.");
            }
        }

        static async Task SearchMedia(string query)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://kitsu.io/api/edge/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/vnd.api+json"));

                string mangaUrl = $"manga?filter[text]={query}";
                string animeUrl = $"anime?filter[text]={query}";

                HttpResponseMessage mangaResponse = await client.GetAsync(mangaUrl);
                HttpResponseMessage animeResponse = await client.GetAsync(animeUrl);

                if (mangaResponse.IsSuccessStatusCode && animeResponse.IsSuccessStatusCode)
                {
                    string mangaJson = await mangaResponse.Content.ReadAsStringAsync();
                    string animeJson = await animeResponse.Content.ReadAsStringAsync();

                    // TODO: Traitez les JSON pour obtenir les informations nécessaires, y compris les noms des mangas et des animés
                    Console.WriteLine("Manga JSON:");
                    Console.WriteLine(mangaJson);
                    Console.WriteLine("Anime JSON:");
                    Console.WriteLine(animeJson);
                }
                else
                {
                    Console.WriteLine("Failed to get search results.");
                }
            }
        }

        static string GetUserInput()
        {
            Console.WriteLine("Enter your search query:");
            return Console.ReadLine();
        }


    }
}
