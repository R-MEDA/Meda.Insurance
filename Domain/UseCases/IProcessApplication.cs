namespace Domain.UseCases;

using Domain.Application;

public interface IProcessApplication
{
    Task Process(ApplicationId applicationId, ApplicationStatus applicationDecision);
}