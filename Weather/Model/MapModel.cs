using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Weather
{
    public class MapModel
    {
        [JsonProperty("coord")]
        public cordinateData coordData { get; set; }

        [JsonProperty("weather")]
        public List<WeatherInfo> weatherInfo { get; set;}

        [JsonProperty("message")]
        public string message { get; set;}

        public MapModel()
        {
        }

        public class cordinateData
        {
        	[JsonProperty("lon")]
            public Double lon { get; set; }

        	[JsonProperty("lat")]
            public Double lat { get; set; }
        
        }

        public class WeatherInfo
        { 
            [JsonProperty("main")]
            public string title { get; set; }

            [JsonProperty("description")]
            public string desc { get; set; }
            
        }

    }


}
