namespace Domain.Ports.Mocks;

using Domain.Policy;

public class PolicyMock : IPolicy
{
    private List<Policy> Policies = [];

    public Task Create(Policy policy)
    {
        return Task.Run(() => Policies.Add(policy));
    }

    public Task<List<Policy>> GetAll()
    {
        return Task.Run(() => Policies);
    }
}