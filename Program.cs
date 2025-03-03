// See https://aka.ms/new-console-template for more information
namespace BusBoard
{
    class BusBoard {
        public static async Task Main() {
            while(true) {
                Console.WriteLine("Please enter the postcode:");
                string? postCode = Console.ReadLine();
                if (postCode == null) {
                    break;
                }
                PostCodeResponse postCodeInfo = await PostCodeClient.GetPostCodeInfo(postCode);
                StopPointsResponse stopPointsResponse = await TflClient.GetStopPoints(postCodeInfo.result.latitude, postCodeInfo.result.longitude);
                IEnumerable<StopPoint> nearestStopPoints = stopPointsResponse.stopPoints.Take(2);
                foreach (var stopPoint in nearestStopPoints)
                {
                    Console.WriteLine($"Bus Stop Code: {stopPoint.naptanId}");
                    List<BusArrival> busArrivals = await TflClient.GetArrivalPredictionsForStopCode(stopPoint.naptanId);
                    busArrivals.Sort((firstBus, secondBus) => firstBus.timeToStation.CompareTo(secondBus.timeToStation));
                    IEnumerable<BusArrival> nextFiveBuses = busArrivals.Take(5);
                    ConsolePrinter.PrintBusArrivals(nextFiveBuses);
                }
                
            }
        }
    }
}