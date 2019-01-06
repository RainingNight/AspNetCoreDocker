using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Web.Pages
{
    public class FetchDataModel : PageModel
    {
        private static HttpClient _client;

        public FetchDataModel(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("api");
        }

        public IList<WeatherForecast> Forecasts { get; set; }

        public async Task OnGetAsync()
        {
            var res = await _client.GetStringAsync("/api/SampleData/WeatherForecasts");
            Forecasts = JsonConvert.DeserializeObject<IList<WeatherForecast>>(res);
        }
    }

    public class WeatherForecast
    {
        public string DateFormatted { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF { get; set; }

        public string Summary { get; set; }
    }
}
