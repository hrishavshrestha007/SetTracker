using System;

namespace Backend.Models.DTOs
{
    
public class ExerciseDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Muscle { get; set; } 
    public string? Icon { get; set; }
    public string? Color { get; set; }
    public string? Bg { get; set; }
    public int? Sets { get; set; }
    public int? Reps { get; set; }
}

}
