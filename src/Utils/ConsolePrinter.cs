namespace BusBoard {
    class ConsolePrinter {
        public static void PrintBusArrivals(IEnumerable<BusArrival> busArrivals) {
            Console.WriteLine("====================================================");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{0,-10} {1,-35} {2,-10}", "Bus", "Destination", "Time");
            Console.ResetColor();
            Console.WriteLine("====================================================");
            foreach (var bus in busArrivals)
            {
                Console.WriteLine("{0, -10} {1, -35} {2, -10}", 
                    bus.lineId, 
                    bus.destinationName, 
                    TimeHelper.GetArrivalTimeInMinutes(bus.timeToStation));
            }
            Console.WriteLine("====================================================");
        }
    }
}