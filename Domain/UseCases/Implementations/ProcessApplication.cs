namespace Domain.UseCases.Implementations;

using Domain.Application;
using Domain.Ports;
using Domain.Policy;
using Domain.Car;
using Domain.Customer;
using Domain.Service;

public class ProcessApplication : IProcessApplication
{
    private readonly IApplication _applications;
    private readonly IPolicy _policies;
    private readonly ICar _cars;

    public ProcessApplication(IApplication applications, IPolicy policies, ICar cars)
    {
        _applications = applications;
        _policies = policies;
        _cars = cars;
    }

    public async Task Process(ApplicationId applicationId, ApplicationStatus applicationDecision)
    {
        Application applicationUnderReview = await _applications.Find(applicationId) ?? throw new ArgumentException($"Application with id ${applicationId.Id} not found!");
        Car car = await _cars.Get(applicationUnderReview.CarPlates) ?? throw new ArgumentException($"Car with license plate ${applicationUnderReview.CarPlates} not found!");

        applicationUnderReview.UpdateApplicationStatus(applicationDecision);
        await _applications.Update(applicationUnderReview);

        if (applicationDecision.Equals(ApplicationStatus.Approved))
        {
            CustomerId customerId = applicationUnderReview.CustomerId;
            LicensePlate licensePlate = applicationUnderReview.CarPlates;

            decimal premiumAmount = PremiumCalculator.CalculatePremium(car.FirstAscription, car.CatalogueValue);

            Policy policy = new(applicationId, customerId, licensePlate, new Premium(premiumAmount));

            await _policies.Create(policy);
        }
    }
}