using System.Text.RegularExpressions;

namespace BusBoard
{
    class UserInput
    {
        public static string GetPostcode()
        {
            ConsolePrinter.PrintPostcodePrompt();
            string? input = Console.ReadLine();

            while(input == null || !IsValidUKPostCode(input)) {
                ConsolePrinter.PrintValidPostcodePrompt();
                input = Console.ReadLine();
            }

            return input;
        }

        private static bool IsValidUKPostCode(string postcode)
        {
            string pattern = @"^([A-Z]{1,2}[0-9][0-9A-Z]?)\s?([0-9][A-Z]{2})$";

            return Regex.IsMatch(postcode, pattern, RegexOptions.IgnoreCase);
        }
    }
}