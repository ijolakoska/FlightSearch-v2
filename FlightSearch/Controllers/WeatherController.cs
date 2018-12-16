namespace FlightSearch.Controllers
{
    using System;
    using System.Web.Http;
    using RestSharp;

    public class WeatherController : ApiController
    {
        private const string weatherApiKey = "f744d4d0fa3238fa24ec49b28dee5123";
        
        [HttpGet, Route("api/weather")]
        public IHttpActionResult GetWeatherDestination(string city, DateTime date)
        {
            double daysToArrival = (date.Date - DateTime.Today).TotalDays;

            var forecastUrl = $"http://api.openweathermap.org/data/2.5/forecast?q={city}&APPID={weatherApiKey}&units=metric&cnt={daysToArrival}";
            var forecastResults = GetDeserializedForecast(forecastUrl);

            //check if we can get data for arrival date
            var existingForecast = forecastResults.List.Find(t => t.date.Date.Equals(date.Date));

            if (existingForecast != null)
            {
                return Ok(existingForecast);
            }

            //if arrival date is too far to get weather condition, return the current state
            var url = $"http://api.openweathermap.org/data/2.5/weather?q={city}&APPID={weatherApiKey}&units=metric";

            var existingWeather = GetDeserializedWeather(url);

            if (existingWeather != null) {
                return Ok(existingWeather);
            }

            return BadRequest();
        }

        private Models.WeatherCondition GetDeserializedWeather(string url)
        {
            var client = new RestClient(url);

            var response = client.Execute<Models.WeatherCondition>(new RestRequest());

            return response.Data;
        }

        private Models.Forecast GetDeserializedForecast(string url)
        {
            var client = new RestClient(url);

            var response = client.Execute<Models.Forecast>(new RestRequest());

            return response.Data;
        }
    }
}
