using Backend.Models.Entities;

namespace Backend.Services.UserExercises;

public interface IUserExerciseService
{
	Task<UserExercise> UpsertAsync(int userId, int exerciseId, int sets, int reps);
	Task<IReadOnlyList<UserExercise>> GetAllAsync(int userId);
}
