using DistanceCalculatorService.Model;
using System;


namespace DistanceCalculatorService.Calculators
{
    public class PythagorasDistanceCalculator : IDistanceCalculator
    {
                
        public CalculationType CalculationType => CalculationType.Pythagoras;

        public double CalculateDistance(double latitude, double longitude, double otherlatitude, double otherlongitude)
        {
            var distance = Math.Sqrt((Math.Pow( otherlatitude - latitude, 2) + Math.Pow(otherlongitude - longitude, 2)));

            return distance;
        }
    }
}
