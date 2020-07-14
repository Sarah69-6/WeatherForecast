using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecast.Models
{
    public class Weather
    {
        public DateTime applicable_date { get; set; }
        public string weather_state_name { get; set; }
        public string Image { get; set; }
    }
   
}
