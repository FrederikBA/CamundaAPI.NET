using Demo.Web.Models.Dto;
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
    [Route("deployment/deploy")]
    public async Task<IActionResult> DeployCamunda([FromBody] DeploymentDto dto)
    {
        var response = await _deployService.Deploy(dto.name);
        return Ok(response);
    }
    
    [HttpPost]
    [Route("deployment/delete")]
    public async Task<IActionResult> DeleteCamundaDeployment([FromBody] DeleteDeploymentDto dto)
    {
        var response = await _deployService.DeleteDeployment(dto.id);
        return Ok(response);
    }
    
    [HttpGet]
    [Route("deployment/list")]
    public async Task<IActionResult> GetCamundaDeployments()
    {
        var response = await _deployService.GetDeployments();
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