namespace Domain.Ports;

using Domain.Car;

public interface IRdw
{
    Task<Car> ReadOutCarInfo(LicensePlate licensePlate);
}