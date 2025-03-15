namespace Domain.Policy;

using Domain.Application;
using Domain.Car;
using Domain.Claim;
using Domain.Customer;

public class Policy
{
    public PolicyId Id { get; private set; }
    public ApplicationId ApplicationId { get; private set; }
    public CustomerId CustomerId { get; private set; }
    public LicensePlate LicensePlate { get; private set; }
    public List<ClaimId> ClaimIds { get; private set; }
    public Premium Premium { get; private set; }
    public int ConsecutiveClaimFreeYears { get; private set; }
    public DateTime PolicyStartDate { get; private set; }
    public DateTime PolicyEndDate { get; private set; }
    public bool IsActive { get; private set; }

    public Policy(ApplicationId applicationId, CustomerId customerId, LicensePlate licensePlate, Premium premium)
    {
        Id = new PolicyId(Guid.CreateVersion7());
        ApplicationId = applicationId;
        CustomerId = customerId;
        LicensePlate = licensePlate;
        ClaimIds = new List<ClaimId>();
        Premium = premium;
        ConsecutiveClaimFreeYears = 0;
        PolicyStartDate = DateTime.UtcNow;
        PolicyEndDate = PolicyStartDate.AddYears(1);
        IsActive = true;
    }

    private Policy(PolicyId id, ApplicationId applicationId, CustomerId customerId, LicensePlate licensePlate,
                   List<ClaimId> claimIds, Premium premium, int consecutiveClaimFreeYears,
                   DateTime policyStartDate, DateTime policyEndDate, bool isActive)
    {
        Id = id;
        ApplicationId = applicationId;
        CustomerId = customerId;
        LicensePlate = licensePlate;
        ClaimIds = claimIds ?? new List<ClaimId>();
        Premium = premium;
        ConsecutiveClaimFreeYears = consecutiveClaimFreeYears;
        PolicyStartDate = policyStartDate;
        PolicyEndDate = policyEndDate;
        IsActive = isActive;
    }

    public static Policy Rehydrate(PolicyId id, ApplicationId applicationId, CustomerId customerId,
                                   LicensePlate licensePlate, List<ClaimId> claimIds, Premium premium,
                                   int consecutiveClaimFreeYears, DateTime policyStartDate,
                                   DateTime policyEndDate, bool isActive)
    {
        return new Policy(id, applicationId, customerId, licensePlate, claimIds, premium,
                          consecutiveClaimFreeYears, policyStartDate, policyEndDate, isActive);
    }

    public void AddClaim(ClaimId claimId)
    {
        ClaimIds.Add(claimId);
        ConsecutiveClaimFreeYears = 0;
    }

    public void CancelPolicy()
    {
        IsActive = false;
    }

    public void RenewPolicy()
    {
        if (IsActive)
        {
            PolicyStartDate = DateTime.UtcNow;
            PolicyEndDate = PolicyStartDate.AddYears(1);
            ConsecutiveClaimFreeYears++;
            ApplyNoClaimBonus();
        }
    }

    private void ApplyNoClaimBonus()
    {
        if (ConsecutiveClaimFreeYears > 0)
        {
            Premium = Premium.UpdatePremium(-500.00m);
        }
    }

    public bool IsPolicyActive()
    {
        return IsActive && DateTime.UtcNow <= PolicyEndDate;
    }

    public void RevisePremium()
    {
        if (ClaimIds.Count > 3 && ConsecutiveClaimFreeYears == 0)
        {
            Premium = Premium.UpdatePremium(500);
        }
    }
}
