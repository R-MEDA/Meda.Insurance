namespace Infrastructure.Persistence.Application;

using Domain.Application;
using Domain.Car;
using Domain.Customer;

public static class ApplicationMapper
{
    public static ApplicationEntity ToEntity(Application application)
    {
        return new ApplicationEntity
        {
            Id = application.Id.Id,
            CustomerId = application.CustomerId.Id,
            CarPlates = application.CarPlates.Plate,
            ApplicationStatus = application.ApplicationStatus.ToString() 
        };
    }

    public static Application ToDomain(ApplicationEntity entity)
    {
        
        return Application.Rehydrate(
            new ApplicationId(entity.Id),
            new CustomerId(entity.CustomerId),
            new LicensePlate(entity.CarPlates),
            Enum.Parse<ApplicationStatus>(entity.ApplicationStatus) 
        );
    }
}
