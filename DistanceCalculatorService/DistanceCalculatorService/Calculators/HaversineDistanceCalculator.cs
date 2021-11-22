using DistanceCalculatorService.Model;
using System;

namespace DistanceCalculatorService.Calculators
{
    public class HaversineDistanceCalculator : IDistanceCalculator
    {
        const int EarthRadiusKm = 6371;
        const double D2R = (Math.PI / 180D);
   
        
        public CalculationType CalculationType => CalculationType.Haversine;

        public double CalculateDistance(double latitude, double longitude, double otherlatitude, double otherlongitude)
        {

            double dlong = (otherlongitude - longitude) * D2R;
            double dlat = (otherlatitude - latitude) * D2R;
            double a = Math.Pow(Math.Sin(dlat / 2D), 2D) + Math.Cos(latitude * D2R) * Math.Cos(otherlatitude * D2R) * Math.Pow(Math.Sin(dlong / 2D), 2D);
            double c = 2D * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1D - a));
            double dist = EarthRadiusKm * c;

            return dist;
        }
    }
}
