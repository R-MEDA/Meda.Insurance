namespace Domain.Ports.Mocks;

using System.Threading.Tasks;
using Domain.Car;

public class RdwMock : IRdw
{
    public Task<Car?> ReadOutCarInfo(LicensePlate licensePlate)
    {
        throw new NotImplementedException();
    }
}