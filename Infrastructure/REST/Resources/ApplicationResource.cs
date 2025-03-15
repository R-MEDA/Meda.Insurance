using Domain.Application;

namespace Infrastructure.REST.Resources;

public class ApplicationResource
{
    public Guid ApplicationId { get; set; }
    public Guid CustomerId { get; set; }
    public string LicensePlate { get; set; }
    public ApplicationStatus ApplicationStatus { get; set; }

    public ApplicationResource(Application application)
    {
        ApplicationId = application.Id.Id;
        CustomerId = application.CustomerId.Id;
        LicensePlate = application.CarPlates.Plate;
        ApplicationStatus = application.ApplicationStatus;
    }
}