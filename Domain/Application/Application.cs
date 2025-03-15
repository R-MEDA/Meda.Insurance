namespace Domain.Application;

using Domain.Car;
using Domain.Customer;

public class Application
{
    public ApplicationId Id { get; private set; }
    public CustomerId CustomerId { get; private set; }
    public LicensePlate CarPlates { get; private set; }
    public ApplicationStatus ApplicationStatus { get; private set; }

    public Application(CustomerId customerId, LicensePlate carPlates)
    {
        Id = new ApplicationId(Guid.CreateVersion7());
        CustomerId = customerId;
        CarPlates = carPlates;
        ApplicationStatus = ApplicationStatus.Pending;
    }

    private Application(ApplicationId id, CustomerId customerId, LicensePlate carPlates, ApplicationStatus status)
    {
        Id = id;
        CustomerId = customerId;
        CarPlates = carPlates;
        ApplicationStatus = status;
    }

    public static Application Rehydrate(ApplicationId id, CustomerId customerId, LicensePlate carPlates, ApplicationStatus status)
    {
        return new Application(id, customerId, carPlates, status);
    }

    public void UpdateApplicationStatus(ApplicationStatus newStatus)
    {
        if (ApplicationAlreadyReviewed(ApplicationStatus))
        {
            throw new ArgumentException("Application already reviewed");
        }
        ApplicationStatus = newStatus;
    }

    private readonly Func<ApplicationStatus, bool> ApplicationAlreadyReviewed = (status) => status == ApplicationStatus.Approved || status == ApplicationStatus.Declined;
}
