using RestSharp;

namespace BusBoard {
    class PostcodeClient {
        private static readonly RestClient postCodeClient = new RestClient("https://api.postcodes.io/postcodes/");
        // api.postcodes.io/postcodes/NW75GT/validate

        public static async Task<PostcodeInfo> GetPostcodeInfo(string postCode) {
            var request = new RestRequest($"{postCode}");    
            var response = await postCodeClient.GetAsync<PostcodeResponse>(request);

            return response == null ? throw new Exception("PostCode API Error") : response.result;
        }

        public static async Task<bool> ValidatePostcode(string postCode) {
            var request = new RestRequest($"{postCode}/validate");    
            var response = await postCodeClient.GetAsync<PostcodeValidateResponse>(request);

            return response == null ? throw new Exception("PostCode API Error") : response.result;
        }
    }
}