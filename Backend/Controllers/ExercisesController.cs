using Backend.Models.DTOs;
using Backend.Models.Entities;
using Backend.Services.Exercises;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/exercises")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly IExerciseService _exerciseService;
        public ExercisesController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var exercises = await _exerciseService.GetAllAsync();

            var exerciseDtos = exercises.Select(e => new ExerciseDto
            {
                Id = e.Id,
                Name = e.Name,
                Muscle = e.MuscleGroup?.Name,
                Icon = e.Icon,
                Color = e.Color,
                Bg = e.Bg,
                Sets = e.Sets,
                Reps = e.Reps
            }).ToList();
            return Ok(exerciseDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var exercise = await _exerciseService.GetByIdAsync(id);
            if (exercise == null)
            {
                return NotFound();
            }
            var exerciseDto = new ExerciseDto
            {
                Id = exercise.Id,
                Name = exercise.Name,
                Muscle = exercise.MuscleGroup?.Name,
                Icon = exercise.Icon,
                Color = exercise.Color,
                Bg = exercise.Bg,
                Sets = exercise.Sets,
                Reps = exercise.Reps
            };
            return Ok(exerciseDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Exercise exercise)
        {
            await _exerciseService.CreateAsync(exercise);
            return CreatedAtAction(nameof(GetById), new { id = exercise.Id }, exercise);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Exercise exercise)
        {
            if (id != exercise.Id)
            {
                return BadRequest("ID in URL does not match ID in body.");
            }
            await _exerciseService.UpdateAsync(id, exercise);
            return Ok(exercise);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await _exerciseService.Exists(id))
            {
                return NotFound();
            }
            await _exerciseService.DeleteAsync(id);
            return NoContent();
        }
    }
}
