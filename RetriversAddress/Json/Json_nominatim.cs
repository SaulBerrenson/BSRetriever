using System.Collections.Generic;
using Newtonsoft.Json;

namespace BSRetriever.RetriversAddress.Json
{
    internal class Json_nominatim
    {

        [JsonProperty("place_id")]
        public int PlaceId;

        [JsonProperty("licence")]
        public string Licence;

        [JsonProperty("osm_type")]
        public string OsmType;

        [JsonProperty("osm_id")]
        public int OsmId;

        [JsonProperty("lat")]
        public string Lat;

        [JsonProperty("lon")]
        public string Lon;

        [JsonProperty("display_name")]
        public string DisplayName;

        [JsonProperty("boundingbox")]
        public List<string> Boundingbox;

    }
}