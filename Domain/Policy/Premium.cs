namespace Domain.Policy;

public record Premium(decimal Price)
{
    public Premium UpdatePremium(decimal amount)
    {
        return new Premium(Price + amount);
    }
};