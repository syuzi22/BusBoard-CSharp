using RestSharp;

namespace BusBoard {
    class PostCodeClient {
        private static readonly RestClient postCodeClient = new RestClient("https://api.postcodes.io/postcodes/");

        public static async Task<PostCodeResponse> GetPostCodeInfo(string postCode) {
            var request = new RestRequest($"{postCode}");    
            var response = await postCodeClient.GetAsync<PostCodeResponse>(request);

            return response == null ? throw new Exception("PostCode API Error") : response;
        }
    }
}