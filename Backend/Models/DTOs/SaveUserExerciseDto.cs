namespace Backend.Models.DTOs;

public class SaveUserExerciseDto
{
    public int ExerciseId { get; set; }
    public List<ExerciseSetDto> Sets { get; set; } = [];
}

public class ExerciseSetDto
{
    public int SetNumber { get; set; }
    public int Reps { get; set; }
    public int? Weight { get; set; }
    public int? PreviousWeight { get; set; }
    public bool IsCompleted { get; set; }
}
