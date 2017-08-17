namespace TWC.Extensions
{
    using System.Net.Http;
    using System.Net;
    using System;

    public static class Extensions
    {
        public static string GetSource(this string url)
        {
            if (!url.Contains("http://") || !url.Contains("https://") || !url.Contains("ftp://") || !url.Contains("ftps://"))
                return null;

            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(url);

                if (response.Result.StatusCode == HttpStatusCode.OK)
                {
                    return response.Result.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
