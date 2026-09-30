using System;
using System.ComponentModel.DataAnnotations.Schema;
using static Backend.Models.Entities.UserExercises;

namespace Backend.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string Email { get; set; } = string.Empty;

        [Column("Password")]
        public string PasswordHash { get; set; } = string.Empty;

        public string? Role { get; set; } = "User";

        [NotMapped]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // User.cs
public ICollection<UserExercise> UserExercises { get; set; } = new List<UserExercise>();
    }
}
