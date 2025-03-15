namespace Infrastructure.Persistence.Car;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CarEntityConfiguration : IEntityTypeConfiguration<CarEntity>
{
    public void Configure(EntityTypeBuilder<CarEntity> builder)
    {
        builder.HasKey(c => c.LicensePlate);

        builder.HasIndex(c => c.LicensePlate)
                .IsUnique();

        builder.HasIndex(c => c.IsStolen);

        builder.HasIndex(c => new { c.CarType, c.Brand });

        builder.Property(c => c.LicensePlate).HasMaxLength(50);
        builder.Property(c => c.CarType).HasMaxLength(50);
        builder.Property(c => c.Brand).HasMaxLength(100);
    }
}