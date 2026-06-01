using System;
using System.Text.Json.Serialization;

namespace Backend.Models.Entities
{
    public class MuscleGroup
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [JsonIgnore]
        public ICollection<Exercise>? Exercises { get; set; }
    }
}
