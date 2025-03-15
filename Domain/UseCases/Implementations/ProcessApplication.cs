namespace Domain.UseCases.Implementations;

using Domain.Application;
using Domain.Ports;
using Domain.Policy;
using Domain.Car;
using Domain.Customer;

public class ProcessApplication : IProcessApplication
{
    private readonly IApplication _applications;
    private readonly IPolicy _policies;

    public ProcessApplication(IApplication applications, IPolicy policies)
    {
        _applications = applications;
        _policies = policies;
    }

    public async Task Process(ApplicationId applicationId, ApplicationStatus applicationDecision)
    {
        Application applicationUnderReview = await _applications.Find(applicationId) ?? throw new ArgumentException($"Application with id ${applicationId.Id} not found!");

        applicationUnderReview.UpdateApplicationStatus(applicationDecision);
        await _applications.Update(applicationUnderReview);

        if (applicationDecision.Equals(ApplicationStatus.Approved))
        {
            CustomerId customerId = applicationUnderReview.CustomerId;
            LicensePlate licensePlate = applicationUnderReview.CarPlates;

            Policy policy = new(applicationId, customerId, licensePlate, new Premium(700.00m));

            await _policies.Create(policy);
        }
    }
}