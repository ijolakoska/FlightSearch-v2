using System;

namespace FlightSearch.Models
{
    public class SearchFlight
    {
        public string source { get; set; }

        public string destination { get; set; }

        public int numAdults { get; set; }

        public int numChildren { get; set; }

        public int numInfants { get; set; }

        public DateTime departureDate { get; set; }

        public DateTime arrivalDate { get; set; }

        public string seatingClass { get; set; }

        public int counter { get; set; }
    }
}