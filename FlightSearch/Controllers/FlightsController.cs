namespace FlightSearch.Controllers
{
    using System.Web.Http;
    using FlightSearch.Models;
    using RestSharp;

    public class FlightsController : ApiController
    {
        //used for the open API for flights
        private const string appId = "907e3679";
        private const string appKey = "a2fe2b0e0457c736300bf042deebb5aa";
        
        [HttpPost, Route("api/flights")]
        public IHttpActionResult GetFlights([FromBody] SearchFlight search)
        {
            var departureDate = search.departureDate.ToString("yyyyMMdd");
            var arrivalDate = search.arrivalDate.ToString("yyyyMMdd");

            var url = $"http://developer.goibibo.com/api/search/?&app_id={appId}&app_key={appKey}&format=json&source={search.source}&destination={search.destination}&dateofdeparture={departureDate}&dateofarrival={arrivalDate}&seatingclass={search.seatingClass}&adults={search.numAdults}&children={search.numChildren}&infants={search.numInfants}&counter={search.counter}";

            var flights = GetDeserializedFlights(url);

            if (flights != null)
            {
                var results = flights.Data.OnwardFlights;
                results.AddRange(flights.Data.ReturnFlights);

                return Ok(results);
            }

            return BadRequest();
        }

        private FlightResults GetDeserializedFlights(string url)
        {
            var client = new RestClient(url);

            var response = client.Execute<FlightResults> (new RestRequest());

            return response.Data;
        }
    }
}
