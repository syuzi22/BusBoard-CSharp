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

        public static void PrintBusStopInformation(string commonName, double distance) {
            Console.WriteLine($"Bus Stop: {commonName}");
            Console.WriteLine($"Distance: {Math.Round(distance)}m");
        }

        public static void PrintPostcodePrompt() {
            Console.WriteLine("Please enter the postcode:");
        }

        public static void PrintValidPostcodePrompt() {
            Console.WriteLine("This postcode does not exist. Please provide valid UK postcode:");
        }

        public static void PrintNoBusStops() {
            Console.WriteLine("Unfortunately, there are no bus stops near this postcode.\n");
        }

        public static void PrintNoBuses() {
            Console.WriteLine("Unfortunately, there are no buses for this bus stop.\n");
        }

        public static void PrintServiceUnavailable() {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Service is temporarily unavailable. Please try again later.");
            Console.ResetColor();
        }
    }
}