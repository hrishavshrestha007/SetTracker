namespace Backend.Models.Entities;

public class UserExerciseSet
{
    public int UserId { get; set; }
    public int ExerciseId { get; set; }
    public int SetNumber { get; set; }

    public int Reps { get; set; }
    public int? Weight { get; set; }

    public UserExercise UserExercise { get; set; } = null!;
}