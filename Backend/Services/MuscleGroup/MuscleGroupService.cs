using Backend.Data;
using Backend.Models.Entities;
using Backend.Services.Shared;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.MuscleGroups;

public class MuscleGroupService : IMuscleGroupService
{
    private readonly SetTrackerDbContext _context;

    public MuscleGroupService(SetTrackerDbContext context)
    {
        _context = context;
    }

    public async Task<List<MuscleGroup>> GetMuscleGroups()
    {
        return await _context.MuscleGroups.ToListAsync();
    }

    public async Task<MuscleGroup> GetMuscleGroupById(int id)
    {
        var muscleGroup = await _context.MuscleGroups.FindAsync(id);
        if (muscleGroup == null)
        {
            throw new Exception($"Muscle group with ID {id} not found.");
        }
        return muscleGroup;
    }
}