namespace DistanceCalculatorService.Calculators
{
    public class HaversineCalculatorDistanceFactory : IDistanceCalculatorFactory
    {
        public IDistanceCalculator CreateCalculator()
        {
            return new HaversineDistanceCalculator();
        }
    }
}
