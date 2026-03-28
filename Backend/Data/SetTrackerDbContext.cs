using System;
using Backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class SetTrackerDbContext : DbContext
    {
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<User> Users { get; set; }

        public SetTrackerDbContext(DbContextOptions<SetTrackerDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed data for exercises
            modelBuilder.Entity<Exercise>().HasData(
            // Chest
             new Exercise { Id = 1, Name = "Bench Press", Muscle = "chest", Icon = "fa-arrow-up", Color = "text-orange-400", Bg = "bg-orange-500/15", Sets = 4, Reps = 8 },
    new Exercise { Id = 2, Name = "Incline DB Press", Muscle = "chest", Icon = "fa-angle-double-up", Color = "text-orange-300", Bg = "bg-orange-400/15", Sets = 3, Reps = 10 },
    new Exercise { Id = 3, Name = "Cable Fly", Muscle = "chest", Icon = "fa-expand-alt", Color = "text-orange-400", Bg = "bg-orange-500/15", Sets = 3, Reps = 12 },
    new Exercise { Id = 4, Name = "Push-Ups", Muscle = "chest", Icon = "fa-arrow-up", Color = "text-orange-300", Bg = "bg-orange-400/15", Sets = 4, Reps = 20 },

    // Back
    new Exercise { Id = 5, Name = "Pull-Ups", Muscle = "back", Icon = "fa-arrow-down", Color = "text-blue-400", Bg = "bg-blue-500/15", Sets = 4, Reps = 8 },
    new Exercise { Id = 6, Name = "Barbell Row", Muscle = "back", Icon = "fa-minus", Color = "text-blue-400", Bg = "bg-blue-500/15", Sets = 4, Reps = 8 },
    new Exercise { Id = 7, Name = "Lat Pulldown", Muscle = "back", Icon = "fa-arrow-down", Color = "text-blue-300", Bg = "bg-blue-400/15", Sets = 3, Reps = 12 },
    new Exercise { Id = 8, Name = "Seated Cable Row", Muscle = "back", Icon = "fa-compress-alt", Color = "text-blue-400", Bg = "bg-blue-500/15", Sets = 3, Reps = 12 },

    // Legs
    new Exercise { Id = 9, Name = "Squat", Muscle = "legs", Icon = "fa-sort-amount-down", Color = "text-green-400", Bg = "bg-green-500/15", Sets = 4, Reps = 6 },
    new Exercise { Id = 10, Name = "Romanian DL", Muscle = "legs", Icon = "fa-long-arrow-alt-down", Color = "text-green-400", Bg = "bg-green-500/15", Sets = 3, Reps = 10 },
    new Exercise { Id = 11, Name = "Leg Press", Muscle = "legs", Icon = "fa-chevron-down", Color = "text-green-300", Bg = "bg-green-400/15", Sets = 3, Reps = 12 },
    new Exercise { Id = 12, Name = "Walking Lunges", Muscle = "legs", Icon = "fa-shoe-prints", Color = "text-green-400", Bg = "bg-green-500/15", Sets = 3, Reps = 16 },

    // Shoulders
    new Exercise { Id = 13, Name = "Shoulder Press", Muscle = "shoulders", Icon = "fa-angle-double-up", Color = "text-purple-400", Bg = "bg-purple-500/15", Sets = 3, Reps = 10 },
    new Exercise { Id = 14, Name = "Lateral Raises", Muscle = "shoulders", Icon = "fa-arrows-alt-h", Color = "text-purple-400", Bg = "bg-purple-500/15", Sets = 4, Reps = 15 },
    new Exercise { Id = 15, Name = "Face Pulls", Muscle = "shoulders", Icon = "fa-compress-alt", Color = "text-purple-300", Bg = "bg-purple-400/15", Sets = 3, Reps = 15 },

    // Arms
    new Exercise { Id = 16, Name = "Barbell Curl", Muscle = "arms", Icon = "fa-dumbbell", Color = "text-pink-400", Bg = "bg-pink-500/15", Sets = 3, Reps = 10 },
    new Exercise { Id = 17, Name = "Tricep Pushdown", Muscle = "arms", Icon = "fa-arrow-down", Color = "text-pink-400", Bg = "bg-pink-500/15", Sets = 3, Reps = 12 },
    new Exercise { Id = 18, Name = "Hammer Curl", Muscle = "arms", Icon = "fa-dumbbell", Color = "text-pink-300", Bg = "bg-pink-400/15", Sets = 3, Reps = 12 },
    new Exercise { Id = 19, Name = "Skull Crushers", Muscle = "arms", Icon = "fa-minus", Color = "text-pink-400", Bg = "bg-pink-500/15", Sets = 3, Reps = 10 },

    // Core
    new Exercise { Id = 20, Name = "Plank", Muscle = "core", Icon = "fa-minus", Color = "text-yellow-400", Bg = "bg-yellow-500/15", Sets = 3, Reps = 60 },
    new Exercise { Id = 21, Name = "Cable Crunch", Muscle = "core", Icon = "fa-angle-down", Color = "text-yellow-400", Bg = "bg-yellow-500/15", Sets = 3, Reps = 15 },
    new Exercise { Id = 22, Name = "Hanging Leg Raise", Muscle = "core", Icon = "fa-sort-amount-up", Color = "text-yellow-300", Bg = "bg-yellow-400/15", Sets = 3, Reps = 12 }
);

            //Seed data for admin user
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Role = "Admin", Name = "Admin", Username = "Admin", Password = "@Admin123" }
            );
        }
    }
}
