namespace Infrastructure.Clients.Rdw;

using System.Text.Json;
using System.Threading.Tasks;
using Domain.Car;
using Domain.Ports;

public class RdwClient : IRdw
{
    private readonly HttpClient _httpClient;

    public RdwClient()
    {
        _httpClient = new()
        {
            BaseAddress = new Uri("https://opendata.rdw.nl")
        };
    }

    public async Task<Car> ReadOutCarInfo(LicensePlate licensePlate)
    {
        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"resource/m9d7-ebf2.json?kenteken={licensePlate.Plate}");

            response.EnsureSuccessStatusCode();

            string jsonResponse = await response.Content.ReadAsStringAsync();

            RdwCarResource[]? cars = JsonSerializer.Deserialize<RdwCarResource[]>(jsonResponse);


            RdwCarResource car = cars[0];

            //ANTI-CORRUPTION-LAYER. Iy maps all the technical junk from the RDW to our domain.
            return new Car(
                licensePlate: new LicensePlate(car.Kenteken),
                carType: new CarType(car.Type),
                brand: new Brand(car.Merk),
                isStolen: false, // HardCoded Value for Demo Purposes
                weight: Int32.Parse(car.MassaRijklaar),
                apkExpiry: car.VervaldatumApkDt ?? throw new NullReferenceException("Vervaldatum is required"),
                firstAscription: car.DatumTenaamstellingDt ?? throw new NullReferenceException("Vervaldatum is required"),
                previousOwners: 0, // HardCoded Value for Demo Purposes
                catalogueValue: Int32.Parse(car.CatalogusPrijs)
            );
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}