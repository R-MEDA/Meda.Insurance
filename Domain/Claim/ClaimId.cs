namespace Domain.Claim;

// The claim entity lives in another microservice. We only hold the key reference as part of our aggregate.
public record ClaimId(Guid Id);