namespace BusBoard {
    class PostcodeResponse {
        public required PostcodeInfo result { get; set; }
    }

    public class PostcodeInfo {
        public required double longitude { get; set; }
        public required double latitude { get; set; }
    }
}