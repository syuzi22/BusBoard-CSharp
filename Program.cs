// See https://aka.ms/new-console-template for more information
namespace BusBoard
{
    class BusBoard {
        public static async Task Main() {
            while(true) {
                Console.WriteLine("Please enter the bus stop code:");
                string stopCode = Console.ReadLine() ?? "";
                List<BusArrival> busArrivals = await TflClient.GetArrivalPredictionsForStopCode(stopCode);
                busArrivals.Sort((firstBus, secondBus) => firstBus.timeToStation.CompareTo(secondBus.timeToStation));
                IEnumerable<BusArrival> nextFiveBuses = busArrivals.Take(5);
                ConsolePrinter printer = new ConsolePrinter();
                printer.PrintBusArrivals(nextFiveBuses);
            }
        }
    }
}