using System.Text.Json.Serialization;

namespace Backend.Models.Entities;

public class UserExercise
{
    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public int ExerciseId { get; set; }
    public Exercise Exercise { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public ICollection<UserExerciseSet> ExerciseSets { get; set; } = [];
}
