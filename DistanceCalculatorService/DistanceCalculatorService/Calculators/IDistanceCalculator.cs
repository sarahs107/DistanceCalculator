using DistanceCalculatorService.Model;

namespace DistanceCalculatorService.Calculators
{
  
    public interface IDistanceCalculator
    {
        CalculationType CalculationType { get; }
        double CalculateDistance(double latitude, double longitude, double otherlatitude, double otherlongitude);
    }
}
