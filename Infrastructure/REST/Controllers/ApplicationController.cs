namespace Infrastructure.Rest.Controllers;

using Domain.Application;
using Domain.Car;
using Domain.Customer;
using Domain.Ports;
using Domain.UseCases;
using Infrastructure.REST.Resources;
using Microsoft.AspNetCore.Mvc;
using REST.Request;

[ApiController]
[Route("applications")]
public class ApplicationController : ControllerBase
{
    private readonly IApplyForPolicy _applyForPolicy;
    private readonly IProcessApplication _processApplication;
    private readonly IApplication _applications;
    
    public ApplicationController(
        IApplyForPolicy applyForPolicy,
        IProcessApplication processApplication,
        IApplication applications
    )
    {
        _applyForPolicy = applyForPolicy;
        _processApplication = processApplication;
        _applications = applications;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApplicationResource>> GetById(Guid id)
    {
        var application = await _applications.Find(new ApplicationId(id));

        if (application == null)
        {
            return NotFound();
        }

        return Ok(new ApplicationResource(application));
    }


    [HttpPost("apply")]
    public async Task<ActionResult> Apply([FromBody] ApplyForPolicyRequest request)
    {
        await _applyForPolicy.Apply(
            new CustomerId(request.CustomerId),
            new LicensePlate(request.LicensePlate)
        );

        return Created();
    }

    [HttpPost("process")]
    public async Task<ActionResult> ProcessApplication([FromBody] ProcessApplicationRequest request)
    {
        await _processApplication.Process(
            new ApplicationId(request.ApplicationId), 
            request.ApplicationDecision
        );
        
        return Created();
    }

    [HttpGet]
    public async Task<ActionResult<ApplicationResource>> GetAll()
    {
        List<Application> applications = await _applications.All();
        return Ok(applications.Select(a => new ApplicationResource(a)));
    }
}
