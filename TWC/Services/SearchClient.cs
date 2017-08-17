namespace TWC.Services
{
    using Newtonsoft.Json;
    using System;
    using System.Threading.Tasks;
    using TWC.Extensions;
    using TWC.Models;

    public class SearchClient
    {
        string template = "http://wxdata.weather.com/wxdata/obs/{0}.json?key=e88d3874-a740-102c-bafd-001321203584&locale={1}&units={2}";
        SettingsModel appSettings = null;

        public SearchClient(SettingsModel settings)
        {
            appSettings = settings;
        }

        public ResultsModel Search(string searchArgument)
        {
            return Task.Run(() => GetResults(searchArgument)).Result; 
        }

        internal ResultsModel GetResults(string searchArgument)
        {
            string url = string.Format(template, searchArgument, appSettings.Locale);
            string page = url.GetSource();

            if (page == null)
                throw new Exception("Error when loading results");

            return JsonConvert.DeserializeObject<ResultsModel>(page);
        }
    }
}
