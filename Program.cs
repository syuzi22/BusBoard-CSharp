// See https://aka.ms/new-console-template for more information
namespace BusBoard
{
    class BusBoard {
        public static async Task Main() {
            while(true) {
                string postCode = UserInput.GetPostcode();
                IEnumerable<StopPoint> nearestStopPoints = await GetNearestStopPoints(postCode);

                foreach (var stopPoint in nearestStopPoints)
                {
                    IEnumerable<BusArrival> nextFiveBuses = await GetNextFiveBuses(stopPoint.naptanId);
                    ConsolePrinter.PrintBusStopInformation(stopPoint.commonName, stopPoint.distance);
                    ConsolePrinter.PrintBusArrivals(nextFiveBuses);
                }
                
            }
        }

        private static async Task<IEnumerable<StopPoint>> GetNearestStopPoints(string postCode) {
            PostCodeInfo postCodeInfo = await PostCodeClient.GetPostCodeInfo(postCode);
            List<StopPoint> stopPoints = await TflClient.GetStopPoints(postCodeInfo.latitude, postCodeInfo.longitude);

            return stopPoints.Take(2);
        }

        private static async Task<IEnumerable<BusArrival>> GetNextFiveBuses(string naptanId) {
            List<BusArrival> busArrivals = await TflClient.GetArrivalPredictionsForStopCode(naptanId);
            busArrivals.Sort((firstBus, secondBus) => firstBus.timeToStation.CompareTo(secondBus.timeToStation));

            return busArrivals.Take(5);
        }
    }
}