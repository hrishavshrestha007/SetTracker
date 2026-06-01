using System;
using Backend.Models.Entities;
using Backend.Services.Shared;

namespace Backend.Services.Exercises
{
    public interface IExerciseService : ICrudService<Exercise, int>
    {
        Task<bool> Exists(int id);
    }
}
