namespace Infrastructure.Rest.Controllers;

using Domain.Policy;
using Domain.Ports;
using Infrastructure.REST.Resources;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("policies")]
public class PolicyController : ControllerBase
{
    private readonly IPolicy _policies;
    
    public PolicyController(IPolicy policies)
    {
        _policies = policies;
    }

    [HttpGet]
    public async Task<ActionResult<List<PolicyResource>>> GetAllPolicies()
    {
        List<Policy> policies = await _policies.GetAll();
        
        return Ok(policies.Select(p => new PolicyResource(p)));
    }
}