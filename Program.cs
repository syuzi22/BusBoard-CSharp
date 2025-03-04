// See https://aka.ms/new-console-template for more information
using System.Text.Json;

namespace BusBoard
{
    class BusBoard
    {
        public static async Task Main()
        {
            try
            {
                while (true)
                {
                    string postcode = await UserInput.GetPostcode();
                    PostcodeInfo postcodeInfo = await PostcodeClient.GetPostcodeInfo(postcode);
                    IEnumerable<StopPoint> nearestStopPoints = await GetNearestStopPoints(postcodeInfo.latitude, postcodeInfo.longitude);

                    if (nearestStopPoints.Count() == 0) {
                        ConsolePrinter.PrintNoBusStops();
                        continue;
                    }

                    await ProcessAndDisplayBusStopsAndArrivals(nearestStopPoints);
                }
            }
            catch
            {
                ConsolePrinter.PrintServiceUnavailable();
            }

        }

        private static async Task ProcessAndDisplayBusStopsAndArrivals(IEnumerable<StopPoint>nearestStopPoints) {
            foreach (var stopPoint in nearestStopPoints)
            {
                ConsolePrinter.PrintBusStopInformation(stopPoint.commonName, stopPoint.distance);
                IEnumerable<BusArrival> nextFiveBuses = await GetNextFiveBuses(stopPoint.naptanId);

                if (nextFiveBuses.Count() == 0)
                {
                    ConsolePrinter.PrintNoBuses();
                    continue;
                }

                ConsolePrinter.PrintBusArrivals(nextFiveBuses);
            }
        }

        private static async Task<IEnumerable<StopPoint>> GetNearestStopPoints(double latitude, double longitude)
        {
            List<StopPoint> stopPoints = await TflClient.GetStopPoints(latitude, longitude);

            return stopPoints.Take(2);
        }

        private static async Task<IEnumerable<BusArrival>> GetNextFiveBuses(string naptanId)
        {
            List<BusArrival> busArrivals = await TflClient.GetArrivalPredictionsForStopCode(naptanId);
            busArrivals.Sort((firstBus, secondBus) => firstBus.timeToStation.CompareTo(secondBus.timeToStation));

            return busArrivals.Take(5);
        }
    }
}