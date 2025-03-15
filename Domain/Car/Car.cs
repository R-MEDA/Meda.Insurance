namespace Domain.Car;

public class Car
{
    public LicensePlate LicensePlate { get; private set; }
    public CarType CarType { get; private set; }
    public Brand Brand { get; private set; }
    public bool IsStolen { get; private set; }
    public int Weight { get; private set; }
    public DateTime ApkExpiry { get; private set; }
    public DateTime FirstAscription { get; private set; }
    public int PreviousOwners { get; private set; }
    public int CatalogueValue { get; private set; }

    public Car(
        LicensePlate licensePlate,
        CarType carType,
        Brand brand,
        bool isStolen,
        int weight,
        DateTime apkExpiry,
        DateTime firstAscription,
        int previousOwners,
        int catalogueValue
    )
    {
        LicensePlate = licensePlate ?? throw new ArgumentNullException(nameof(licensePlate));
        CarType = carType;
        Brand = brand ?? throw new ArgumentNullException(nameof(brand));
        IsStolen = isStolen;
        Weight = weight;
        ApkExpiry = apkExpiry;
        FirstAscription = firstAscription;
        PreviousOwners = previousOwners;
        CatalogueValue = catalogueValue;
    }

    public static Car Rehydrate(
        LicensePlate licensePlate, CarType carType, Brand brand, bool isStolen,
        int weight, DateTime apkExpiry, DateTime firstAscription, int previousOwners, int catalogueValue)
    {
        return new Car(licensePlate, carType, brand, isStolen, weight, apkExpiry, firstAscription, previousOwners, catalogueValue);
    }

    public bool HasValidApk()
    {
        return DateTime.UtcNow <= ApkExpiry;
    }

    public bool IsRoadworthy()
    {
        return !IsStolen && HasValidApk();
    }

    public void MarkAsStolen()
    {
        IsStolen = true;
    }

    public void RecoverCar()
    {
        IsStolen = false;
    }

    public void UpdateApkExpiry(DateTime newExpiryDate)
    {
        if (newExpiryDate <= DateTime.UtcNow)
        {
            throw new ArgumentException("APK expiry date must be in the future.");
        }
        ApkExpiry = newExpiryDate;
    }
}
