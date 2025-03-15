using Domain.Policy;

namespace Infrastructure.REST.Resources;

public class PolicyResource
{
    public Guid PolicyId { get; set; }
    public Guid ApplicationId {get; set; }
    public Guid CustomerId { get; set; }
    public string LicensePlate { get; set; }
    public List<Guid> ClaimIds { get; set; }
    public decimal Premium { get; set; }
    public int ConsecutiveClaimFreeYears { get; set; }
    public DateTime PolicyStartDate { get; set; }
    public DateTime PolicyEndDate { get; set; }
    public bool IsActive { get; set; }

    public PolicyResource(Policy policy)
    {
        PolicyId = policy.Id.Id;
        ApplicationId = policy.ApplicationId.Id;
        CustomerId = policy.CustomerId.Id;
        LicensePlate = policy.LicensePlate.Plate;
        ClaimIds = policy.ClaimIds.Select(c => c.Id).ToList();
        Premium = policy.Premium.Price;
        ConsecutiveClaimFreeYears = policy.ConsecutiveClaimFreeYears;
        PolicyStartDate = policy.PolicyStartDate;
        PolicyEndDate = policy.PolicyEndDate;
        IsActive = policy.IsActive;
    }
}