namespace Infrastructure.Persistence.Policy;

public class PolicyEntity
{
    public Guid Id { get; set; }
    public Guid ApplicationId { get; set; }
    public Guid CustomerId { get; set; }
    public string LicensePlate { get; set; }
    public decimal PremiumAmount { get; set; }
    public int ConsecutiveClaimFreeYears { get; set; }
    public DateTime PolicyStartDate { get; set; }
    public DateTime PolicyEndDate { get; set; }
    public bool IsActive { get; set; }
    public string ClaimIds { get; set; } // Stored as CSV (e.g., "claim1,claim2,claim3")
}
