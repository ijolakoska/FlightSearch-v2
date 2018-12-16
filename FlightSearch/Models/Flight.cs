namespace FlightSearch.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public class FlightResults
    {
        [JsonProperty(PropertyName = "data")]
        public FlightsData Data { get; set; }
    }

    public class FlightsData
    {
        [JsonProperty(PropertyName = "returnflights")]
        public List<Flight> ReturnFlights { get; set; } = new List<Flight>();

        [JsonProperty(PropertyName = "onwardflights")]
        public List<Flight> OnwardFlights { get; set; } = new List<Flight>();
    }

    public class Flight
    {

        [JsonProperty(PropertyName = "airline")]
        public string airline { get; set; }

        [JsonProperty(PropertyName = "depdate")]
        public string depdate { get; set; }

        [JsonProperty(PropertyName = "arrdate")]
        public string arrdate { get; set; }

        [JsonProperty(PropertyName = "stops")]
        public int stops { get; set; }

        [JsonProperty(PropertyName = "operatingcarrier")]
        public string operatingcarrier { get; set; }

        [JsonProperty(PropertyName = "flightno")]
        public int flightno { get; set; }

        [JsonProperty(PropertyName = "origin")]
        public string origin { get; set; }

        [JsonProperty(PropertyName = "destination")]
        public string destination { get; set; }

        public string fullflightno
        {
            get => $"{this.operatingcarrier}{this.flightno}";
        }

        public DateTime fulldepdate
        {
            get {
                var date = depdate.Split('t')[0];
                var time = depdate.Split('t')[1];
                return DateTime.ParseExact($"{date} {time}", "yyyy-MM-dd HHmm", System.Globalization.CultureInfo.InvariantCulture);
            }
        }

        public DateTime fullarrdate
        {
            get
            {
                var date = arrdate.Split('t')[0];
                var time = arrdate.Split('t')[1];
                return DateTime.ParseExact($"{date} {time}", "yyyy-MM-dd HHmm", System.Globalization.CultureInfo.InvariantCulture);
            }
        }
    }
}