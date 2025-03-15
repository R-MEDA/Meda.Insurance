namespace Domain.Ports.Mocks;

using Domain.Application;

public class ApplicationMock : IApplication
{
    private List<Application> Applications = [
    ];

    public Task<List<Application>> All()
    {
        return Task.Run(() => Applications);
    }

    public Task Apply(Application application)
    {
        return Task.Run(() => Applications.Add(application));
    }

    public Task<Application?> Find(ApplicationId applicationId)
    {
        return Task.Run(() => Applications.Find(a => a.Id == applicationId));
    }

    public Task Update(Application newApplication)
    {
        return Task.Run(() =>
        {
            Application? oldApplication = Applications.Find(a => a.Id == newApplication.Id) ?? throw new ArgumentException("Application can't be found");
            oldApplication = newApplication;
        });
    }
}