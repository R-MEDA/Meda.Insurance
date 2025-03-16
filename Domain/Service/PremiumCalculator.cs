namespace Domain.Service;

public static class PremiumCalculator
{
    public static decimal CalculatePremium(DateTime carYear, int carValue)
    {
        decimal premium = 500.00m;

        decimal riskFactor = new Random().NextInt64(1, 10);

        if (carYear.Year < 2010)
        {
            premium += 100.00m;
        }

        if (carValue > 100000.00m)
        {
            premium += 100.00m;
        }

        return premium * riskFactor;
    }   
}