using System;
using Backend.Data;
using Backend.Models.Entities;
using Backend.Services.Exercises;
using Backend.Services.Shared;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly SetTrackerDbContext _context;
        public ExerciseService(SetTrackerDbContext context)
        {
            _context = context;
        }


        public async Task<bool> Exists(int id)
        {
            return await _context.Exercises.AnyAsync(e => e.Id == id);
        }

        public async Task<Exercise> CreateAsync(Exercise entity)
        {
            _context.Exercises.Add(entity);
            await _context.SaveChangesAsync();

            return await _context.Exercises
                .Include(e => e.MuscleGroup)
                .FirstAsync(e => e.Id == entity.Id);
        }

        public async Task<IEnumerable<Exercise>> GetAllAsync()
        {
            return await _context.Exercises.Include(e => e.MuscleGroup).ToListAsync();
        }

        public Task<Exercise> GetByIdAsync(int id)
        {
            return _context.Exercises.Include(e => e.MuscleGroup).FirstAsync(e => e.Id == id);
        }


        public async Task<Exercise> UpdateAsync(int id, Exercise entity)
        {
            var exercise = await _context.Exercises.FindAsync(id);
            if (exercise == null)
            {
                throw new KeyNotFoundException($"Exercise with id {id} was not found.");
            }
            exercise.Sets = entity.Sets;
            exercise.Reps = entity.Reps;

            await _context.SaveChangesAsync();
            return exercise;
        }

        public async Task DeleteAsync(int id)
        {
            var exercise = await _context.Exercises.FindAsync(id);
            if (exercise != null)
            {
                _context.Exercises.Remove(exercise);
                await _context.SaveChangesAsync();
            }
        }
    }
}
