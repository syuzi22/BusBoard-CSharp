namespace BusBoard {
    class ConsolePrinter {
        public void PrintBusArrivals(IEnumerable<BusArrival> busArrivals) {
            Console.WriteLine("===============================================");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{0,-10} {1,-30} {2,-10}", "Bus", "Destination", "Time");
            Console.ResetColor();
            Console.WriteLine("===============================================");
            foreach (var bus in busArrivals)
            {
                Console.WriteLine("{0, -10} {1, -30} {2, -10}", 
                    bus.lineId, 
                    bus.destinationName, 
                    TimeHelper.GetArrivalTimeInMinutes(bus.timeToStation));
            }
            Console.WriteLine("===============================================");
        }
    }
}