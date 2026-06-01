using System;

namespace Backend.Models.DTOs
{
    public class MuscleGroupDto
    {
        public int Id { get; set; }
        public required List<ExerciseDto> Exercises { get; set; }
    }
}