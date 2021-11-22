namespace DistanceCalculatorService
{
    public static class ConvertDistance
    {
        private const double MilesToKm = 1.609344;
        private const double KmToMiles = 0.621371192;

        public static double ConvertMilesToKilometers(double miles)
        { 
          
            return miles * MilesToKm;
        }

        public static double ConvertKilometersToMiles(double kilometers)
        {
            return kilometers * KmToMiles;
        }
    }
}
