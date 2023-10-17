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
    private readonly TaskService _taskService;

    public CamundaController(DeployService deployService, ProcessService processService, TaskService taskService)
    {
        _deployService = deployService;
        _processService = processService;
        _taskService = taskService;
    }
    
    [HttpPost]
    [Route("deployment/deploy")]
    public async Task<IActionResult> DeployCamunda([FromBody] DeploymentDto dto)
    {
        var response = await _deployService.Deploy(dto.Name);
        return Ok(response);
    }
    
    [HttpPost]
    [Route("deployment/delete")]
    public async Task<IActionResult> DeleteCamundaDeployment([FromBody] DeploymentDto dto)
    {
        var response = await _deployService.DeleteDeployment(dto.Id);
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
    public async Task<IActionResult> StartCamundaProcess([FromBody] ProcessDto dto)
    {
        var response = await _processService.StartCamundaProcess(dto.ProcessKey);
        return Ok(response);
    }
    
    [HttpGet]
    [Route("task/{id}")]
    public async Task<IActionResult> GetCamundaTask(string id)
    {
        var response = await _taskService.GetTask(id);
        return Ok(response);
    }
    
    [HttpGet]
    [Route("tasks")]
    public async Task<IActionResult> GetCamundaTasks()
    {
        var response = await _taskService.GetTasks();
        return Ok(response);
    }
}