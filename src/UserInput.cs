using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusBoard
{
    class UserInput
    {
        public static async Task<string> GetPostcode()
        {
            ConsolePrinter.PrintPostcodePrompt();
            string? input = Console.ReadLine();

            while(string.IsNullOrEmpty(input) || !await IsValidUKPostCode(input)) {
                ConsolePrinter.PrintValidPostcodePrompt();
                input = Console.ReadLine();
            }

            return input;
        }

        private static async Task<bool> IsValidUKPostCode(string? postcode) {
            string pattern = @"^([A-Z]{1,2}[0-9][0-9A-Z]?)\s?([0-9][A-Z]{2})$";

            if (string.IsNullOrEmpty(postcode) || !Regex.IsMatch(postcode, pattern, RegexOptions.IgnoreCase)) {
                return false; 
            }

            return await PostcodeClient.ValidatePostcode(postcode);
        }
    }
}