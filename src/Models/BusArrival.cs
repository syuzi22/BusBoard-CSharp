namespace BusBoard {
    class BusArrival {
        public required string lineId { get; set; }
        public required string destinationName { get; set; }
        public required int timeToStation { get; set; }
    }
}