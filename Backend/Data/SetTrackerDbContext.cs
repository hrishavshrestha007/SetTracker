using System;
using Backend.Models.Entities;
using Microsoft.EntityFrameworkCore;
using static Backend.Models.Entities.UserExercise;

namespace Backend.Data
{
    public class SetTrackerDbContext : DbContext
    {
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<MuscleGroup> MuscleGroups { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserExercise> UserExercises { get; set; }

        public SetTrackerDbContext(DbContextOptions<SetTrackerDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Exercise>()
                .HasOne(e => e.MuscleGroup)
                .WithMany(mg => mg.Exercises)
                .HasForeignKey(e => e.MuscleGroupId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MuscleGroup>().HasData(
                new MuscleGroup { Id = 1, Name = "chest" },
                new MuscleGroup { Id = 2, Name = "back" },
                new MuscleGroup { Id = 3, Name = "legs" },
                new MuscleGroup { Id = 4, Name = "shoulders" },
                new MuscleGroup { Id = 5, Name = "arms" },
                new MuscleGroup { Id = 6, Name = "core" }
            );

            //Seed data for exercises
            modelBuilder.Entity<Exercise>().HasData(
            // Chest
                new Exercise { Id = 1, Name = "Bench Press", MuscleGroupId = 1, Icon = "fa-arrow-up", Color = "text-orange-400", Bg = "bg-orange-500/15", Sets = null, Reps = null },
                new Exercise { Id = 2, Name = "Incline DB Press", MuscleGroupId = 1, Icon = "fa-angle-double-up", Color = "text-orange-300", Bg = "bg-orange-400/15", Sets = null, Reps = null },
                new Exercise { Id = 3, Name = "Cable Fly", MuscleGroupId = 1, Icon = "fa-expand-alt", Color = "text-orange-400", Bg = "bg-orange-500/15", Sets = null, Reps = null },
                new Exercise { Id = 4, Name = "Push-Ups", MuscleGroupId = 1, Icon = "fa-arrow-up", Color = "text-orange-300", Bg = "bg-orange-400/15", Sets = null, Reps = null },

             // Back
                new Exercise { Id = 5, Name = "Pull-Ups", MuscleGroupId = 2, Icon = "fa-arrow-down", Color = "text-blue-400", Bg = "bg-blue-500/15", Sets = null, Reps = null },
                new Exercise { Id = 6, Name = "Barbell Row", MuscleGroupId = 2, Icon = "fa-minus", Color = "text-blue-400", Bg = "bg-blue-500/15", Sets = null, Reps = null },
                new Exercise { Id = 7, Name = "Lat Pulldown", MuscleGroupId = 2, Icon = "fa-arrow-down", Color = "text-blue-300", Bg = "bg-blue-400/15", Sets = null, Reps = null },
                new Exercise { Id = 8, Name = "Seated Cable Row", MuscleGroupId = 2, Icon = "fa-compress-alt", Color = "text-blue-400", Bg = "bg-blue-500/15", Sets = null, Reps = null },

            // Legs
                new Exercise { Id = 9, Name = "Squat", MuscleGroupId = 3, Icon = "fa-sort-amount-down", Color = "text-green-400", Bg = "bg-green-500/15", Sets = null, Reps = null },
                new Exercise { Id = 10, Name = "Romanian DL", MuscleGroupId = 3, Icon = "fa-long-arrow-alt-down", Color = "text-green-400", Bg = "bg-green-500/15", Sets = null, Reps = null },
                new Exercise { Id = 11, Name = "Leg Press", MuscleGroupId = 3, Icon = "fa-chevron-down", Color = "text-green-300", Bg = "bg-green-400/15", Sets = null, Reps = null },
                new Exercise { Id = 12, Name = "Walking Lunges", MuscleGroupId = 3, Icon = "fa-shoe-prints", Color = "text-green-400", Bg = "bg-green-500/15", Sets = null, Reps = null },

            // Shoulders
                new Exercise { Id = 13, Name = "Shoulder Press", MuscleGroupId = 4, Icon = "fa-angle-double-up", Color = "text-purple-400", Bg = "bg-purple-500/15", Sets = null, Reps = null },
                new Exercise { Id = 14, Name = "Lateral Raises", MuscleGroupId = 4, Icon = "fa-arrows-alt-h", Color = "text-purple-400", Bg = "bg-purple-500/15", Sets = null, Reps = null },
                new Exercise { Id = 15, Name = "Face Pulls", MuscleGroupId = 4, Icon = "fa-compress-alt", Color = "text-purple-300", Bg = "bg-purple-400/15", Sets = null, Reps = null },

            // Arms
                new Exercise { Id = 16, Name = "Barbell Curl", MuscleGroupId = 5, Icon = "fa-dumbbell", Color = "text-pink-400", Bg = "bg-pink-500/15", Sets = null, Reps = null },
                new Exercise { Id = 17, Name = "Tricep Pushdown", MuscleGroupId = 5, Icon = "fa-arrow-down", Color = "text-pink-400", Bg = "bg-pink-500/15", Sets = null, Reps = null },
                new Exercise { Id = 18, Name = "Hammer Curl", MuscleGroupId = 5, Icon = "fa-dumbbell", Color = "text-pink-300", Bg = "bg-pink-400/15", Sets = null, Reps = null },
                new Exercise { Id = 19, Name = "Skull Crushers", MuscleGroupId = 5, Icon = "fa-minus", Color = "text-pink-400", Bg = "bg-pink-500/15", Sets = null, Reps = null },

            // Core
                new Exercise { Id = 20, Name = "Plank", MuscleGroupId = 6, Icon = "fa-minus", Color = "text-yellow-400", Bg = "bg-yellow-500/15", Sets = null, Reps = null },
                new Exercise { Id = 21, Name = "Cable Crunch", MuscleGroupId = 6, Icon = "fa-angle-down", Color = "text-yellow-400", Bg = "bg-yellow-500/15", Sets = null, Reps = null },
                new Exercise { Id = 22, Name = "Hanging Leg Raise", MuscleGroupId = 6, Icon = "fa-sort-amount-up", Color = "text-yellow-300", Bg = "bg-yellow-400/15", Sets = null, Reps = null }
);

            //Seed data for admin user
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Role = "Admin",
                    Name = "Admin User",
                    Email = "admin@example.com",
                    PasswordHash = "@Admin123"
                }
            );

            modelBuilder.Entity<UserExercise>()
    .HasKey(x => new { x.UserId, x.ExerciseId });

modelBuilder.Entity<UserExercise>()
    .HasOne(x => x.User)
    .WithMany(x => x.UserExercises)
    .HasForeignKey(x => x.UserId)
    .OnDelete(DeleteBehavior.Cascade);

modelBuilder.Entity<UserExercise>()
    .HasOne(x => x.Exercise)
    .WithMany(x => x.UserExercises)
    .HasForeignKey(x => x.ExerciseId)
    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
