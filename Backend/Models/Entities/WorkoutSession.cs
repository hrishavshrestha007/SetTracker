using System;

namespace Backend.Models.Entities
{
    public class WorkoutSession
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public DateTime Date { get; set; }
        
    }
}
