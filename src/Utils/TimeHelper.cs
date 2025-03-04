namespace BusBoard {
    class TimeHelper {
        public static string GetArrivalTimeInMinutes(int seconds) {
            double minutes = Math.Round(seconds / 60.0);

            if (minutes == 0) {
                return "now";
            }

            return Convert.ToString(minutes);
        }
    }
}