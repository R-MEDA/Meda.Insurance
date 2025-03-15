namespace Domain.Ports;

using Domain.Car;

public interface ICar
{
    Task AddCarToInHouseRegistry(Car car);
    Task<Car?> Get(LicensePlate licensePlate);
    Task<List<Car>> GetAll();
}