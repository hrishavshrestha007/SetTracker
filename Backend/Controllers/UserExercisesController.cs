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

        return Ok(savedExercises.Select(userExercise => new UserExerciseLogDto
        {
            ExerciseId = userExercise.ExerciseId,
            Name = userExercise.Exercise.Name,
            Muscle = userExercise.Exercise.MuscleGroup?.Name,
            Sets = userExercise.Sets,
            Reps = userExercise.Reps
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

        if (request.Sets <= 0 || request.Reps <= 0)
        {
            return BadRequest("Sets and reps must be valid values.");
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
                request.Sets,
                request.Reps);

            return Ok(new
            {
                userExercise.UserId,
                userExercise.ExerciseId,
                userExercise.Sets,
                userExercise.Reps
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
