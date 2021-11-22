using DistanceCalculatorService.Model;

namespace DistanceCalculatorService
{
    public interface IDistanceCalculatorService
    {
        CalculatedDistance CalculateDistance(double latitude, double longitude, double otherlatitude, double otherlongitude, CalculationType calcType, UnitOfDistance unitOfDistance);
    }
}
