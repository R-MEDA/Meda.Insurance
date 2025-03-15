namespace Infrastructure.Persistence.Car;

using Domain.Car;
using Domain.Ports;
using Microsoft.EntityFrameworkCore;

public class CarRepository : ICar
{
    private readonly PolicyContext _context;

    public CarRepository(PolicyContext context)
    {
        _context = context;
    }
    public async Task AddCarToInHouseRegistry(Domain.Car.Car car)
    {
        CarEntity carEntity = CarMapper.ToEntity(car);
        await _context.Cars.AddAsync(carEntity);
        await _context.SaveChangesAsync();
    }

    public async Task<Car?> Get(LicensePlate licensePlate)
    {
        CarEntity? savedCar = await _context.Cars.Where(c => c.LicensePlate == licensePlate.Plate).FirstOrDefaultAsync();
        return CarMapper.ToDomain(savedCar);
    }

    public async Task<List<Car>> GetAll()
    {
        List<CarEntity> allCars = await _context.Cars.ToListAsync();
        return [.. allCars.Select(CarMapper.ToDomain)];
    }
}