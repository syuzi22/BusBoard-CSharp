namespace BusBoard {
    class StopPointsResponse {
        public required List<StopPoint> stopPoints { get; set; }
    }

    public class StopPoint
    {
        public required string naptanId { get; set; }
    }
}