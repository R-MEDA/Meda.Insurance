using Domain.Car;

namespace Infrastructure.REST.Resources;

public class CarResource
{
    public string LicensePlate { get; set; }
    public string CarType { get; set; }
    public string Brand { get; set; }
    public bool IsStolen { get; set; }
    public int Weight { get; set; }
    public DateTime ApkExpiry { get; set; }
    public DateTime FirstAscription { get; set; }
    public int PreviousOwners { get; set; }
    public int CatalogueValue { get; set; }

    public CarResource(Car car)
    {
        LicensePlate = car.LicensePlate.Plate;
        CarType = car.CarType.Type;
        Brand = car.Brand.BrandName;
        IsStolen = car.IsStolen;
        Weight = car.Weight;
        ApkExpiry = car.ApkExpiry;
        FirstAscription = car.FirstAscription;
        PreviousOwners = car.PreviousOwners;
        CatalogueValue = car.CatalogueValue;
    }
}