using Demo.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Web.Controllers;

[Route("[controller]")]
[ApiController]
public class CamundaController : ControllerBase
{
    private readonly DeployService _deployService;

    public CamundaController(DeployService deployService)
    {
        _deployService = deployService;
    }
    
    [HttpGet]
    [Route("deploy")]
    public async Task<IActionResult> DeployCamunda()
    {
        await _deployService.Deploy();
        return Ok("Deployed");
    }
}