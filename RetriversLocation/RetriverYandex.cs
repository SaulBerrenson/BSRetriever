using System;
using System.Net;
using System.Xml;
using System.Xml.Linq;
using BSRetriever.Interfaces;
using BSRetriever.RetriversAddress.Json.Myinkov;

namespace BSRetriever.RetriversLocation.RetriversLocation
{
    public class RetriverYandex : IRetriverLocation
    {
        public (double lat, double lon) Retrive((string MCC, string MNC, string LAC, string CID) data)
        {
            return YandexExtantions.Retrive(
                $"http://mobile.maps.yandex.net/cellid_location/?countrycode={data.MCC}&operatorid={data.MNC}&lac={data.LAC}&cellid={data.CID}");

        }
    }
}