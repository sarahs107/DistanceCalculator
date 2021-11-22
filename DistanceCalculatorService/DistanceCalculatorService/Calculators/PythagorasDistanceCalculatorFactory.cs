namespace DistanceCalculatorService.Calculators
{
    public class PythagorasDistanceCalculatorFactory : IDistanceCalculatorFactory
    {
        public IDistanceCalculator CreateCalculator()
        {
            return new PythagorasDistanceCalculator();
        }
    }
}
