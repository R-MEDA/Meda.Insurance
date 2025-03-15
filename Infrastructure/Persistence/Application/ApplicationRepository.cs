namespace Infrastructure.Persistence.Application;

using Domain.Application;
using Domain.Ports;
using Microsoft.EntityFrameworkCore;

public class ApplicationRepository : IApplication
{
    private readonly PolicyContext _context;

    public ApplicationRepository(PolicyContext context)
    {
        _context = context;
    }

    public async Task<List<Application>> All()
    {
        List<ApplicationEntity> allApplications = await _context.Applications.ToListAsync();
        return allApplications.Select(ApplicationMapper.ToDomain).ToList();
    }

    public async Task Apply(Application application)
    {
        ApplicationEntity applicationEntity = ApplicationMapper.ToEntity(application);
        await _context.Applications.AddAsync(applicationEntity);
        await _context.SaveChangesAsync();
    }

    public async Task<Application?> Find(ApplicationId applicationId)
    {
        ApplicationEntity? savedApplication = await _context.Applications.Where(a => a.Id == applicationId.Id).FirstOrDefaultAsync();

        return ApplicationMapper.ToDomain(savedApplication);
    }

public async Task Update(Application application)
{ 
    var existingEntity = await _context.Applications.FindAsync(application.Id.Id);
    if (existingEntity == null)
    {
        throw new InvalidOperationException($"Application with id {application.Id.Id} not found");
    }

    var updatedEntity = ApplicationMapper.ToEntity(application);
    _context.Entry(existingEntity).CurrentValues.SetValues(updatedEntity);
    
    await _context.SaveChangesAsync();
}
}