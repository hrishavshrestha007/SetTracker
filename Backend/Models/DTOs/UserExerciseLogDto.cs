namespace Backend.Models.DTOs;

public class UserExerciseLogDto
{
    public int ExerciseId { get; set; }
    public string? Name { get; set; }
    public string? Muscle { get; set; }
    public int? Sets { get; set; }
    public int? Reps { get; set; }
}