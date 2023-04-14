// Import required namespaces
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Fag_el_Gamous.Models;
using Microsoft.AspNetCore.Mvc;

// Define the Fag_el_Gamous.Controllers namespace
namespace Fag_el_Gamous.Controllers
{
    // Create a PredictionController class that inherits from Controller
    public class PredictionController : Controller
    {
        // Initialize a static HttpClient instance
        private static readonly HttpClient httpClient = new HttpClient();

        // Handle GET requests for the Index action
        public IActionResult Index()
        {
            // Return the PredictHeadLocation view
            return View("PredictHeadLocation");
        }

        // Handle POST requests for the Submit action
        [HttpPost]
        public async Task<IActionResult> Submit(BurialDataModel burialData)
        {
            // Call the external API with the provided burial data
            var apiResponse = await CallApi(burialData);

            // Check if the API call was successful
            if (apiResponse.IsSuccessStatusCode)
            {
                // Deserialize the API response and display the PredictionResult view
                var jsonResponse = await apiResponse.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<ApiResponse>(jsonResponse);
                return View("PredictionResult", result);
            }
            else
            {
                // Handle error response from API
                ModelState.AddModelError("", "An error occurred while processing the request.");
                return View("Index", burialData);
            }
        }

        // Call the external API with the provided burial data
        private async Task<HttpResponseMessage> CallApi(BurialDataModel burialData)
        {
            // Define the API URL
            var apiUrl = "http://burialapi-prod.us-east-1.elasticbeanstalk.com/score";

            // Serialize the burial data to a JSON string
            var requestBody = JsonSerializer.Serialize(burialData);

            // Create an HTTP content object with the JSON string and UTF-8 encoding
            var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

            // Clear the HTTP client's default request headers and add a new JSON header
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Send a POST request to the API with the JSON content and return the response
            return await httpClient.PostAsync(apiUrl, content);
        }
    }
}
