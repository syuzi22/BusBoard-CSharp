namespace BusBoard {
    class PostCodeResponse {
        public required PostCodeInfo result { get; set; }
    }

    public class PostCodeInfo
    {
        public required double longitude { get; set; }
        public required double latitude { get; set; }
    }
}