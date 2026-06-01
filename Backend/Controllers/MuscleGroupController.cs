using Backend.Services.MuscleGroups;
using Microsoft.AspNetCore.Mvc;
using Backend.Models.Entities;

namespace Backend.Controllers;

[ApiController]
[Route("api/musclegroups")]
public class MuscleGroupController : ControllerBase
{
    private readonly IMuscleGroupService _muscleGroupService;
    public MuscleGroupController(IMuscleGroupService muscleGroupService)
    {
        _muscleGroupService = muscleGroupService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var muscleGroups = await _muscleGroupService.GetMuscleGroups();
        return Ok(muscleGroups);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var muscleGroup = await _muscleGroupService.GetMuscleGroupById(id);
        return Ok(muscleGroup);
    }
}
