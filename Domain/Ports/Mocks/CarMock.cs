namespace Domain.Ports.Mocks;

using System.Threading.Tasks;
using Domain.Car;

public class CarMock : ICar
{
    private List<Car> Cars = [];

    public Task<Car?> Get(LicensePlate licensePlate)
    {
        return Task.Run(() => Cars.Where(car => car.LicensePlate == licensePlate).FirstOrDefault());
    }

    public Task<List<Car>> GetAll()
    {
        return Task.Run(() => Cars);
    }

    public Task AddCarToInHouseRegistry(Car car)
    {
        return Task.Run(() => Cars.Add(car));
    }
}