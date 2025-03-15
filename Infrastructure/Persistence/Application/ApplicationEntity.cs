namespace Infrastructure.Persistence.Application;

public class ApplicationEntity
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public required string CarPlates { get; set; }
    public required string ApplicationStatus { get; set; }
}
