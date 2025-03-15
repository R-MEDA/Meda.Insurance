namespace Infrastructure.Persistence.Policy;

using Domain.Policy;
using Domain.Application;
using Domain.Car;
using Domain.Claim;
using Domain.Customer;

public static class PolicyMapper
{
    public static PolicyEntity ToEntity(Policy policy)
    {
        return new PolicyEntity
        {
            Id = policy.Id.Id,
            ApplicationId = policy.ApplicationId.Id,
            CustomerId = policy.CustomerId.Id,
            LicensePlate = policy.LicensePlate.Plate,
            PremiumAmount = policy.Premium.Price,
            ConsecutiveClaimFreeYears = policy.ConsecutiveClaimFreeYears,
            PolicyStartDate = policy.PolicyStartDate,
            PolicyEndDate = policy.PolicyEndDate,
            IsActive = policy.IsActive,
            ClaimIds = string.Join(",", policy.ClaimIds.Select(c => c.Id))
        };
    }

    public static Policy ToDomain(PolicyEntity entity)
    {
        return Policy.Rehydrate(
            new PolicyId(entity.Id),
            new ApplicationId(entity.ApplicationId),
            new CustomerId(entity.CustomerId),
            new LicensePlate(entity.LicensePlate),
            entity.ClaimIds?.Split(",", StringSplitOptions.RemoveEmptyEntries)
                           .Select(id => new ClaimId(Guid.Parse(id)))
                           .ToList() ?? [],
            new Premium(entity.PremiumAmount),
            entity.ConsecutiveClaimFreeYears,
            entity.PolicyStartDate,
            entity.PolicyEndDate,
            entity.IsActive
        );
    }
}
