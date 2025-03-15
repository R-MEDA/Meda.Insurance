using Domain.Application;

namespace Infrastructure.REST.Request;

public class ProcessApplicationRequest
{
   public Guid ApplicationId { get; set; }
   public ApplicationStatus ApplicationDecision { get; set; }
}