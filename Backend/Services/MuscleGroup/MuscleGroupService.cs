using Backend.Data;
using Backend.Models.Entities;
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
        return await _context.MuscleGroups
            .Include(m => m.Exercises)
            .ToListAsync();
    }

    public async Task<MuscleGroup?> GetMuscleGroupById(int id)
    {
        return await _context.MuscleGroups
            .Include(m => m.Exercises)
            .FirstOrDefaultAsync(m => m.Id == id);  
    }
}