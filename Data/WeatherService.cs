using System;
using System.Collections.Generic;
using nq_blazor_test.Models;

namespace nq_blazor_test.Data
{
    public class WeatherService
    {
        public List<WeatherCondition> GetWeatherData(int count = 50)
        {
            var rng = new Random();
            var locations = new[] { "New York", "Los Angeles", "Chicago", "Denver", "Miami", "Seattle", "Dallas", "Boston" };
            var summaries = (WeatherType[])Enum.GetValues(typeof(WeatherType));
            var data = new List<WeatherCondition>();
            for (int i = 0; i < count; i++)
            {
                var summary = summaries[rng.Next(summaries.Length)];
                data.Add(new WeatherCondition
                {
                    Location = locations[rng.Next(locations.Length)],
                    Date = DateTime.Now.AddDays(rng.Next(-5, 5)),
                    TemperatureC = rng.Next(-30, 45),
                    Summary = summary,
                });
            }
            data.Add(new WeatherCondition { Location = "Testville", Date = DateTime.Now, TemperatureC = -40, Summary = WeatherType.Freezing});
            data.Add(new WeatherCondition { Location = "Edge City", Date = DateTime.Now, TemperatureC = 50, Summary = WeatherType.Scorching});

            return data;
        }
    }
} 