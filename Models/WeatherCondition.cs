using System;

namespace nq_blazor_test.Models
{
    public enum WeatherType
    {
        Freezing,
        Bracing,
        Sweltering,
        Scorching,
        Mild,
        Warm,
        Cool,
        Hot,
        Cold
    }

    public class WeatherCondition
    {
        public string? Location { get; set; }
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        public WeatherType Summary { get; set; }
        public int Severity { get; set; } // 1-5 scale
        public string? SeverityLabel { get; set; } // e.g., Dangerous, Harsh, Normal, Pleasant
        public string? SeverityEmoji { get; set; } // e.g., 🔴, 🟡, ⚪, ✅
        public bool IsHarsh => Summary == WeatherType.Freezing || Summary == WeatherType.Bracing || Summary == WeatherType.Sweltering || Summary == WeatherType.Scorching;
        public bool IsDangerous => Summary == WeatherType.Freezing || Summary == WeatherType.Scorching;
    }
} 