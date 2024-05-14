using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class DailyActivityTrackModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime InfoDate { get; set; }
        public decimal Weight { get; set; }
        public decimal BodyFat { get; set; }
        public decimal MuscleMass { get; set; }
        public int WorkoutFrequency { get; set; } 
        public string? Status { get; set; }
    }

    public class WeightTrackerModel
    { 
        public int UserId { get; set; }
        public DateTime InfoDate { get; set; }
        public decimal Weight { get; set; }

    }

    public class BodyFatTrackerModel
    {
        public int UserId { get; set; }
        public DateTime InfoDate { get; set; }
        public decimal BodyFat { get; set; }

    }

    public class MuscleMassTrackerModel
    {
        public int UserId { get; set; }
        public DateTime InfoDate { get; set; }
        public decimal MuscleMass { get; set; }

    }
}
