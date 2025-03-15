namespace Infrastructure.Persistence.Car;

using Domain.Car;

public static class CarMapper
{
    public static CarEntity ToEntity(Car car)
    {
        return new CarEntity
        {
            LicensePlate = car.LicensePlate.Plate,
            CarType = car.CarType.ToString(),
            Brand = car.Brand.BrandName,
            IsStolen = car.IsStolen,
            Weight = car.Weight,
            ApkExpiry = car.ApkExpiry,
            FirstAscription = car.FirstAscription,
            PreviousOwners = car.PreviousOwners,
            CatalogueValue = car.CatalogueValue
        };
    }

    public static Car ToDomain(CarEntity entity)
    {
        return Car.Rehydrate(
            new LicensePlate(entity.LicensePlate),
            new CarType(entity.CarType),
            new Brand(entity.Brand),
            entity.IsStolen,
            entity.Weight,
            entity.ApkExpiry,
            entity.FirstAscription,
            entity.PreviousOwners,
            entity.CatalogueValue
        );
    }
}
