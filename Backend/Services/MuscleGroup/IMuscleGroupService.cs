using Backend.Models.Entities;

namespace Backend.Services.MuscleGroups;

public interface IMuscleGroupService
{
    Task<List<MuscleGroup>> GetMuscleGroups();
    Task<MuscleGroup?> GetMuscleGroupById(int id);
}