using Backend.Data;
using Backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.UserExercises;

public class UserExerciseService : IUserExerciseService
{
    private readonly SetTrackerDbContext _context;

    public UserExerciseService(SetTrackerDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Exists(int userId, int exerciseId)
    {
        return await _context.UserExercises.AnyAsync(ue => ue.UserId == userId && ue.ExerciseId == exerciseId && !ue.IsDeleted);
    }

    public async Task<UserExercise> CreateAsync(UserExercise entity)
    {
        _context.UserExercises.Add(entity);
        await _context.SaveChangesAsync();

        return await _context.UserExercises
            .Include(ue => ue.User)
            .Include(ue => ue.Exercise)
            .FirstAsync(ue => ue.UserId == entity.UserId && ue.ExerciseId == entity.ExerciseId);
    }

    public async Task<UserExercise?> GetAsync(int userId, int exerciseId)
    {
        return await _context.UserExercises
            .Include(ue => ue.User)
            .Include(ue => ue.Exercise)
            .FirstOrDefaultAsync(ue => ue.UserId == userId && ue.ExerciseId == exerciseId && !ue.IsDeleted);
    }

    public async Task<IReadOnlyList<UserExercise>> GetAllAsync(int userId)
    {
        return await _context.UserExercises
            .Where(ue => ue.UserId == userId && !ue.IsDeleted)
            .Include(ue => ue.Exercise)
            .ThenInclude(exercise => exercise.MuscleGroup)
            .OrderBy(ue => ue.Exercise.Name)
            .ToListAsync();
    }

    public async Task<UserExercise> UpsertAsync(int userId, int exerciseId, int sets, int reps)
    {
        if (!await _context.Users.AnyAsync(user => user.Id == userId))
        {
            throw new InvalidOperationException($"User with id {userId} was not found.");
        }

        if (!await _context.Exercises.AnyAsync(exercise => exercise.Id == exerciseId))
        {
            throw new InvalidOperationException($"Exercise with id {exerciseId} was not found.");
        }

        var userExercise = await _context.UserExercises
            .FirstOrDefaultAsync(ue => ue.UserId == userId && ue.ExerciseId == exerciseId);

        if (userExercise == null)
        {
            userExercise = new UserExercise
            {
                UserId = userId,
                ExerciseId = exerciseId
            };

            _context.UserExercises.Add(userExercise);
        }

        userExercise.Sets = sets;
        userExercise.Reps = reps;
        userExercise.IsDeleted = false;

        await _context.SaveChangesAsync();
        return userExercise;
    }

    public async Task<bool> SoftDeleteAsync(int userId, int exerciseId)
    {
        var userExercise = await _context.UserExercises
            .FirstOrDefaultAsync(ue => ue.UserId == userId && ue.ExerciseId == exerciseId && !ue.IsDeleted);

        if (userExercise == null)
        {
            return false;
        }

        userExercise.IsDeleted = true;
        await _context.SaveChangesAsync();
        return true;
    }
}
