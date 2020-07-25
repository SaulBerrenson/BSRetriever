using BSRetriever.Extantions;
using BSRetriever.Interfaces;

namespace BSRetriever.Links
{
    public class OpenStreetMapLink : ILinkLocation
    {
        
        public string GetLink((double lat, double lon) location)
        {
            return $"https://www.openstreetmap.org/directions?from={location.lat.DoubleWithDot()}%2C{location.lon.DoubleWithDot()}";
        }
    }
}