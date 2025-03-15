namespace Domain.Ports;

using Domain.Application;

public interface IApplication
{
    Task Apply(Application application);
    Task<Application?> Find(ApplicationId applicationId);
    Task<List<Application>> All();
    Task Update(Application application);
}