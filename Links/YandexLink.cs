using BSRetriever.Extantions;
using BSRetriever.Interfaces;

namespace BSRetriever.Links
{
    public class YandexLink : ILinkLocation
    {
        private int _zoom;
        public YandexLink(int zoom = 15)
        {
            _zoom = zoom;
        }

        public string GetLink((double lat, double lon) location)
        {
            return
                $"https://yandex.ru/maps/?ll={location.lon.DoubleWithDot()}&{location.lat.DoubleWithDot()}&mode=search&sll={location.lon.DoubleWithDot()}&{location.lat.DoubleWithDot()}&text={location.lat.DoubleWithDot()}%2C{location.lon.DoubleWithDot()}&z={_zoom}";
        }
    }
}