using System;
using System.Net;
using System.Xml.Linq;

namespace BSRetriever.RetriversLocation.RetriversLocation
{
    internal static class YandexExtantions
    {
        internal static (double lat, double lon) Get(string link)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    //
                    var rez = client.DownloadString(link);

                    if (rez.Contains("Not found")) return (0, 0);

                    var doc = XElement.Parse(rez)?.Element("coordinates");

                    var lat = doc?.Attribute("latitude")?.Value;
                    var lon = doc?.Attribute("longitude")?.Value;

                    return (double.Parse(lat, System.Globalization.CultureInfo.InvariantCulture),
                        double.Parse(lon, System.Globalization.CultureInfo.InvariantCulture));
                }
            }
            catch (Exception)
            {
                return (0, 0);
            }
        }
    }
}