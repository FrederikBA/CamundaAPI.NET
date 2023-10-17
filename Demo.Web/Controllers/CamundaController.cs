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
    
    [HttpPost]
    [Route("deploy")]
    public async Task<IActionResult> DeployCamunda()
    {
        var response = await _deployService.Deploy();
        return Ok(response);
    }
}