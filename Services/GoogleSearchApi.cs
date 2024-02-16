using ChatGptApi.Models;
using Newtonsoft.Json;
using OpeInformation.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ChatGptApi.Services
{

    public class GoogleSearchApi
    {
        public static async Task<string> GetGoogleImagesAsync(string query, string num)
        {
            string apiKey = "AIzaSyAY9VCDshf992av7-f6qI0tawEiqlAaTPg";
            string cx = "13c526caeac6a478c";

            HttpClient httpClient = new HttpClient();

            string url = $"https://www.googleapis.com/customsearch/v1?key={apiKey}&cx={cx}&q={query}&searchType=image&num={num}&imgSize=large";

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();

                GoogleImageResponse data = JsonConvert.DeserializeObject<GoogleImageResponse>(jsonResponse);
                if (data != null && data.Items != null)
                {
                    string imageLinks = "";
                    foreach (GoogleImage image in data.Items)
                    {
                        imageLinks = image.Link;
                    }

                    return imageLinks;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return null;
        }
    }
}