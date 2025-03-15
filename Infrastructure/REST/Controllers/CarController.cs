namespace Infrastructure.Rest.Controllers;

using Domain.Car;
using Domain.Ports;
using Infrastructure.REST.Resources;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("cars")]
public class CarController : ControllerBase
{
    private readonly ICar _cars;
    public CarController(ICar cars)
    {
        _cars = cars;
    }

    [HttpGet]
    public async Task<ActionResult<List<CarResource>>> GetAll()
    {
        List<Car> cars = await _cars.GetAll();

        return cars.Select(car => new CarResource(car)).ToList();
    }   
}