namespace TWC.Models
{
    using Newtonsoft.Json;

    public class ResultsModel
    {
        [JsonProperty("results")]
        public WxLocationModel[] Results { get; set; }
    }
}
