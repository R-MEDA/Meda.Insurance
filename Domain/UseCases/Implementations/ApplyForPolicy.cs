namespace Domain.UseCases.Implementations;

using Domain.Application;
using Domain.Car;
using Domain.Customer;
using Domain.Ports;
using Domain.UseCases;

public class ApplyForPolicy : IApplyForPolicy
{
    private readonly IApplication _applications;
    private readonly IRdw _rdw;
    private readonly ICar _car;

    public ApplyForPolicy(IApplication applications, IRdw rdw, ICar car)
    {
        _applications = applications;
        _rdw = rdw;
        _car = car;
    }

    public async Task Apply(CustomerId customerId, LicensePlate licensePlate)
    {
        Application application = new Application(customerId, licensePlate);

        Car car = await _rdw.ReadOutCarInfo(licensePlate);

        await _car.AddCarToInHouseRegistry(car);
        await _applications.Apply(application);        
    }
}