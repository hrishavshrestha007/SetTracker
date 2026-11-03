using Backend.Models.DTOs;
using Backend.Services.UserExercises;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Backend.Controllers;

[ApiController]
[Route("api/user-exercises")]
[Authorize]
public class UserExercisesController : ControllerBase
{
    private readonly IUserExerciseService _userExerciseService;

    public UserExercisesController(IUserExerciseService userExerciseService)
    {
        _userExerciseService = userExerciseService;
    }

    [HttpGet]
    public async Task<IActionResult> GetMine()
    {
        var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (!int.TryParse(userIdClaim, out var userId) || userId <= 0)
        {
            return Unauthorized();
        }

        var savedExercises = await _userExerciseService.GetAllAsync(userId);

        return Ok(savedExercises.Select(userExercise => new
        {
            ExerciseId = userExercise.ExerciseId,
            Name = userExercise.Exercise.Name,
            Muscle = userExercise.Exercise.MuscleGroup?.Name,
            Sets = userExercise.ExerciseSets
                .OrderBy(set => set.SetNumber)
                .Select(set => new
                {
                    set.SetNumber,
                    set.Reps,
                    set.Weight,
                    set.IsCompleted
                })
        }));
    }

    [HttpPut("{exerciseId:int}")]
    public async Task<IActionResult> Save(
        int exerciseId,
        [FromBody] SaveUserExerciseDto request)
    {
        if (exerciseId != request.ExerciseId)
        {
            return BadRequest("Exercise ID in the URL does not match the request body.");
        }

        if (request.Sets == null || request.Sets.Count == 0)
        {
            return BadRequest("At least one exercise set is required.");
        }

        if (request.Sets.Any(set =>
            set.SetNumber <= 0 ||
            set.Reps <= 0 ||
            set.Weight < 0))
        {
            return BadRequest("Set number, reps, and weight must be valid values.");
        }

        var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!int.TryParse(userIdClaim, out var userId) || userId <= 0)
        {
            return Unauthorized();
        }

        try
        {
            var userExercise = await _userExerciseService.UpsertAsync(
                userId,
                request.ExerciseId,
                request.Sets);

            return Ok(new
            {
                userExercise.UserId,
                userExercise.ExerciseId,
                Sets = userExercise.ExerciseSets
                    .OrderBy(set => set.SetNumber)
                    .Select(set => new
                    {
                        set.SetNumber,
                        set.Reps,
                        set.Weight,
                        set.IsCompleted
                    })
            });
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpDelete("{exerciseId:int}")]
    public async Task<IActionResult> Delete(int exerciseId)
    {
        var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!int.TryParse(userIdClaim, out var userId) || userId <= 0)
        {
            return Unauthorized();
        }

        var deleted = await _userExerciseService.SoftDeleteAsync(userId, exerciseId);
        return deleted ? NoContent() : NotFound();
    }
}
