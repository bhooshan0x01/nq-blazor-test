using nq_blazor_test.Models;

namespace nq_blazor_test.Components
{
    public class WeatherRoleService
    {
        public bool IsRelevantForRole(string role, WeatherCondition condition)
        {
            return role switch
            {
                "Firefighter" => condition.Summary == WeatherType.Scorching,
                "SnowGroomer" => condition.Summary == WeatherType.Freezing || condition.Summary == WeatherType.Bracing,
                _ => false // Default user cannot review
            };
        }

        public bool IsDeemphasizedForRole(string role, WeatherCondition condition)
        {
            return role switch
            {
                "Firefighter" => condition.Summary == WeatherType.Freezing || condition.Summary == WeatherType.Bracing || condition.Summary == WeatherType.Cold || condition.Summary == WeatherType.Cool,
                "SnowGroomer" => condition.Summary == WeatherType.Sweltering || condition.Summary == WeatherType.Scorching || condition.Summary == WeatherType.Hot || condition.Summary == WeatherType.Warm,
                _ => false
            };
        }

        public string GetRowClass(string role, WeatherCondition condition)
        {
            if (role == "Default")
            {
                if (condition.IsDangerous) return "dangerous-weather";
                if (condition.IsHarsh) return "harsh-weather";
                return string.Empty;
            }
            if (role == "Firefighter")
            {
                if (condition.Summary == WeatherType.Scorching) return "dangerous-weather";
                if (IsDeemphasizedForRole(role, condition)) return "deemphasized-row";
                return string.Empty;
            }
            if (role == "SnowGroomer")
            {
                if (condition.Summary == WeatherType.Freezing || condition.Summary == WeatherType.Bracing) return "dangerous-weather";
                if (IsDeemphasizedForRole(role, condition)) return "deemphasized-row";
                return string.Empty;
            }
            return string.Empty;
        }
    }
} 