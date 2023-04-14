using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Fag_el_Gamous.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fag_el_Gamous.Controllers
{
    public class PredictionController : Controller
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public IActionResult Index()
        {
            return View("PredictHeadLocation");
        }

        [HttpPost]
        public async Task<IActionResult> Submit(BurialDataModel burialData)
        {
            var apiResponse = await CallApi(burialData);
            if (apiResponse.IsSuccessStatusCode)
            {
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

        private async Task<HttpResponseMessage> CallApi(BurialDataModel burialData)
        {
            var apiUrl = "http://burialapi-prod.us-east-1.elasticbeanstalk.com/score";

            var requestBody = JsonSerializer.Serialize(burialData);
            var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return await httpClient.PostAsync(apiUrl, content);
        }
    }
}
