namespace FlightSearch.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class Forecast
    {
        [JsonProperty(PropertyName = "list")]
        public List<WeatherCondition> List { get; set; } = new List<WeatherCondition>();
    }

    public class WeatherCondition
    {
        [JsonProperty(PropertyName = "weather")]
        public List<Weather> weather { get; set; } = new List<Weather>();

        [JsonProperty(PropertyName = "main")]
        public Main Main { get; set; }

        [JsonProperty(PropertyName = "wind")]
        public Wind wind { get; set; }

        [JsonProperty(PropertyName = "dt")]
        public int dt { get; set; }

        public DateTime date
        {
            get {
                    DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                    return dtDateTime.AddSeconds(dt).ToLocalTime();
            }
        }
    }

    public class Weather
    {
        [JsonProperty(PropertyName = "main")]
        public string Main { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "icon")]
        public string Icon { get; set; }
    }

    public class Main {

        [JsonProperty(PropertyName = "temp")]
        public double Temp { get; set; }

        [JsonProperty(PropertyName = "humidity")]
        public int Humidity { get; set; }

        [JsonProperty(PropertyName = "pressure")]
        public int Pressure { get; set; }
    }

    public class Wind {

        [JsonProperty(PropertyName = "speed")]
        public float speed { get; set; }
    }
}