using RestSharp;

namespace BusBoard {
    class TflClient {
        private static readonly RestClient stopPointClient = new RestClient("https://api.tfl.gov.uk/StopPoint");

        public static async Task<List<BusArrival>> GetArrivalPredictionsForStopCode(string stopCode) {
            var request = new RestRequest($"{stopCode}/Arrivals");    
            var response = await stopPointClient.GetAsync<List<BusArrival>>(request);

            return response == null ? throw new Exception("Tfl API Error") : response;
        }
    }
}