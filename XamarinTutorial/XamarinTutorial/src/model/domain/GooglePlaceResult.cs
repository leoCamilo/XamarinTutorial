using Newtonsoft.Json;
using System.Collections.Generic;

namespace XamarinTutorial.src.model.domain
{
    public class GooglePlaceResult
    {
        [JsonProperty]
        public List<Prediction> predictions { get; set; }
    }
}
