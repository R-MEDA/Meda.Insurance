namespace Domain.UseCases;

using Domain.Car;
using Domain.Customer;

public interface IApplyForPolicy
{
    Task Apply(CustomerId customerId, LicensePlate licensePlate);
}