using System;
using System.Collections.Generic;
using nq_blazor_test.Models;

namespace nq_blazor_test.Data
{
    public class WeatherService
    {
        private (int min, int max, int severity, string severityLabel, string severityEmoji) GetWeatherTypeInfo(WeatherType summary)
        {
            return summary switch
            {
                WeatherType.Freezing => (int.MinValue, 0, 5, "Dangerous", "🔴"),
                WeatherType.Bracing => (1, 5, 4, "Harsh", "🟡"),
                WeatherType.Cold => (6, 10, 3, "Normal", "⚪"),
                WeatherType.Cool => (11, 17, 3, "Normal", "⚪"),
                WeatherType.Mild => (18, 22, 2, "Pleasant", "✅"),
                WeatherType.Warm => (23, 27, 2, "Pleasant", "✅"),
                WeatherType.Hot => (28, 34, 3, "Normal", "⚪"),
                WeatherType.Sweltering => (35, 39, 4, "Harsh", "🟡"),
                WeatherType.Scorching => (40, int.MaxValue, 5, "Dangerous", "🔴"),
                _ => (0, 30, 3, "Normal", "⚪")
            };
        }

        public List<WeatherCondition> GetWeatherData(int count = 50)
        {
            var rng = new Random();
            var locations = new[] { "New York", "Los Angeles", "Chicago", "Denver", "Miami", "Seattle", "Dallas", "Boston" };
            var summaries = (WeatherType[])Enum.GetValues(typeof(WeatherType));
            var data = new List<WeatherCondition>();
            for (int i = 0; i < count; i++)
            {
                var summary = summaries[rng.Next(summaries.Length)];
                var (minTemp, maxTemp, severity, severityLabel, severityEmoji) = GetWeatherTypeInfo(summary);
                int temp;
                if (minTemp == int.MinValue && maxTemp == 0) // Freezing
                    temp = rng.Next(-40, 1);
                else if (minTemp == 40 && maxTemp == int.MaxValue) // Scorching
                    temp = rng.Next(40, 51);
                else
                    temp = rng.Next(minTemp, maxTemp + 1);
                data.Add(new WeatherCondition
                {
                    Location = locations[rng.Next(locations.Length)],
                    Date = DateTime.Now.AddDays(rng.Next(-5, 5)),
                    TemperatureC = temp,
                    Summary = summary,
                    Severity = severity,
                    SeverityLabel = severityLabel,
                    SeverityEmoji = severityEmoji
                });
            }
            // Add edge cases
            data.Add(new WeatherCondition { Location = "Testville", Date = DateTime.Now, TemperatureC = -40, Summary = WeatherType.Freezing, Severity = 5, SeverityLabel = "Dangerous", SeverityEmoji = "🔴" });
            data.Add(new WeatherCondition { Location = "Edge City", Date = DateTime.Now, TemperatureC = 50, Summary = WeatherType.Scorching, Severity = 5, SeverityLabel = "Dangerous", SeverityEmoji = "🔴" });
            return data;
        }
    }
} 