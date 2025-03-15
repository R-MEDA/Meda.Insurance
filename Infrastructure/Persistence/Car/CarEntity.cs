using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Car;

[EntityTypeConfiguration(typeof(CarEntityConfiguration))]
public class CarEntity
{
    public required string LicensePlate { get; set; }
    public required string CarType { get; set; }
    public required string Brand { get; set; }
    public bool IsStolen { get; set; }
    public int Weight { get; set; }
    public DateTime ApkExpiry { get; set; }
    public DateTime FirstAscription { get; set; }
    public int PreviousOwners { get; set; }
    public int CatalogueValue { get; set; }
}
