namespace Infrastructure.REST.Request;

public class ApplyForPolicyRequest
{
    public required string LicensePlate { get; set; }
    public Guid CustomerId { get; set; }
}