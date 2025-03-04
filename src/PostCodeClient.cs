using RestSharp;

namespace BusBoard {
    class PostcodeClient {
        private static readonly RestClient postCodeClient = new RestClient("https://api.postcodes.io/postcodes/");

        public static async Task<PostcodeInfo> GetPostcodeInfo(string postCode) {
            var request = new RestRequest($"{postCode}");    
            var response = await postCodeClient.GetAsync<PostcodeResponse>(request);

            return response == null ? throw new Exception("PostCode API Error") : response.result;
        }
    }
}