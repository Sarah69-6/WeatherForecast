using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecast.Models
{
    public class Weather
    {
        public long Id { get; set; }
        public DateTime Applicable_date { get; set; }
        public string Weather_state_name { get; set; }
        public string Weather_state_abbr { get; set; }
        public string Icon { get; set; }
    }
   
}
