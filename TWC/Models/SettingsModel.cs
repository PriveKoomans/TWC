namespace TWC.Models
{
    using Newtonsoft.Json;
    using System.IO;

    public class SettingsModel
    {
        [JsonProperty("DayCount")]
        public int DayCount { get; set; }

        [JsonProperty("Units")]
        public string Units { get; set; }

        [JsonProperty("Locale")]
        public string Locale { get; set; }

        [JsonProperty("Location")]
        public WxLocationModel Location { get; set; }

        public SettingsModel Load(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                return JsonConvert.DeserializeObject<SettingsModel>(reader.ReadToEnd());
            }
        }

        public void Save(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.Write(JsonConvert.SerializeObject(this));
            }
        }

        public static SettingsModel InitializeNew(int dayCount, string units, string locale)
        {
            SettingsModel settings = new SettingsModel();
            settings.DayCount = dayCount;
            settings.Units = units;
            settings.Locale = locale;
            return settings;
        }
    }
}
