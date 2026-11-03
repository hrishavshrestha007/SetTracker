using Backend.Models.DTOs;
using Backend.Models.Entities;

namespace Backend.Services.UserExercises;

public interface IUserExerciseService
{
	Task<UserExercise> UpsertAsync(
		int userId,
		int exerciseId,
		List<ExerciseSetDto> sets);
	Task<IReadOnlyList<UserExercise>> GetAllAsync(int userId);
	Task<bool> SoftDeleteAsync(int userId, int exerciseId);
}
