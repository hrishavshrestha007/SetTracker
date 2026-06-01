using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Backend.Models.Entities
{
    public class Exercise
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int MuscleGroupId { get; set; }
        [JsonIgnore]
        public MuscleGroup? MuscleGroup { get; set; }
        public string? Icon { get; set; }
        public string? Color { get; set; }
        public string? Bg { get; set; }
        public int? Sets { get; set; }
        public int? Reps { get; set; }
    }
}
