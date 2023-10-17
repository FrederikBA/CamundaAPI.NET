using Demo.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Web.Controllers;

[Route("[controller]")]
[ApiController]
public class CamundaController : ControllerBase
{
    private readonly DeployService _deployService;
    private readonly ProcessService _processService;

    public CamundaController(DeployService deployService, ProcessService processService)
    {
        _deployService = deployService;
        _processService = processService;
    }
    
    [HttpPost]
    [Route("deploy")]
    public async Task<IActionResult> DeployCamunda()
    {
        var response = await _deployService.Deploy();
        return Ok(response);
    }
    
    [HttpPost]
    [Route("process/start")]
    public async Task<IActionResult> StartCamundaProcess()
    {
        var response = await _processService.StartCamundaProcess();
        return Ok(response);
    }
}