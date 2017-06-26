using Newtonsoft.Json;
using System.Collections.Generic;

namespace XamarinTutorial.src.model.domain
{
    public class Prediction
    {
        [JsonProperty]
        public string id { get; set; }

        [JsonProperty]
        public string place_id { get; set; }

        [JsonProperty]
        public string description { get; set; }

        [JsonProperty]
        public List<string> types { get; set; }
    }
}
