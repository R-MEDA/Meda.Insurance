using Domain.Ports;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Policy;

public class PolicyRepository : IPolicy
{
    private readonly PolicyContext _context;

    public PolicyRepository(PolicyContext context)
    {
        _context = context;
    }

    public async Task Create(Domain.Policy.Policy policy)
    {
        PolicyEntity policyEntity = PolicyMapper.ToEntity(policy);
        await _context.Policies.AddAsync(policyEntity);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Domain.Policy.Policy>> GetAll()
    {
        List<PolicyEntity> allPolicies = await _context.Policies.ToListAsync();
        return [.. allPolicies.Select(PolicyMapper.ToDomain)];
    }
}