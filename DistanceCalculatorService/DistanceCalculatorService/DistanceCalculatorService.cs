
using DistanceCalculatorService.Calculators;
using DistanceCalculatorService.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DistanceCalculatorService
{
 
    public class DistanceCalculatorService : IDistanceCalculatorService
    {
        IDictionary<string, IDistanceCalculator> calcDictionary = new Dictionary<string, IDistanceCalculator>();

        public DistanceCalculatorService(IList<IDistanceCalculator> distanceCalculators)
        {

            calcDictionary = distanceCalculators.Distinct().ToDictionary(x =>x.CalculationType.ToString(), x => x);
        }
  

        public CalculatedDistance CalculateDistance(double latitude, double longitude, double otherlatitude, double otherlongitude, CalculationType calcType, UnitOfDistance unitOfDistance)
        {                   
            IDistanceCalculator calculator;
            if (calcDictionary.TryGetValue(calcType.ToString(), out calculator))
            {
                if (unitOfDistance == UnitOfDistance.Km || unitOfDistance == UnitOfDistance.Miles)
                {
                    var dist = calculator.CalculateDistance(latitude, longitude, otherlatitude, otherlongitude);
                    if (unitOfDistance != UnitOfDistance.Km)
                    {
                        dist = ConvertDistance.ConvertKilometersToMiles(dist);
                    }
                    return new CalculatedDistance
                    {
                        Distance = dist,
                        UnitOfDistance = unitOfDistance.ToString()
                    };
                }
                throw new Exception("Unsupported Unit of Distance-" + unitOfDistance.ToString());
            }
            else
            {
                throw new Exception("Unsupported Calculation Type-" + calcType.ToString());
            }
        }     
    }
}
