namespace Domain.Customer;

// The customer entity lives the Customer Management Microservice. We only hold the key reference as part of our aggregate.
public record CustomerId(Guid Id);