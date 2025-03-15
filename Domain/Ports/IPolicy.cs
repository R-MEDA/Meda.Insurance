namespace Domain.Ports;

using Domain.Policy;

public interface IPolicy
{
    Task Create(Policy policy);
    Task<List<Policy>> GetAll();
}