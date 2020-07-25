using System;
using System.Collections.Generic;
using System.Net;
using BSRetriever.Interfaces;
using BSRetriever.RetriversAddress.Json;
using Newtonsoft.Json;

namespace BSRetriever.RetriversAddress
{
    public class Nominatim : IAddressRetriver
    {
        public string Retrive((double lat, double lon) location)
        {
            try
            {
               // https://nominatim.openstreetmap.org/reverse?format=json&lat=52.5487429714954&lon=-1.81602098644987&zoom=18&addressdetails=0

               using (WebClient clientHttp = new WebClient(){Headers = new WebHeaderCollection()
               {
                   {HttpRequestHeader.UserAgent,"Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:78.0) Gecko/20100101 Firefox/78.0"},
                   {HttpRequestHeader.ContentLanguage, "ru"},
                   {HttpRequestHeader.ContentType, "application/json; charset=UTF-8"},

               }})
               {
                   try
                   {
                       var json_data = clientHttp.DownloadString(
                           "https://openexchangerates.org/api/latest.json?app_id=4be3cf28d6954df2b87bf1bb7c2ba47b ");

                       if (string.IsNullOrWhiteSpace(json_data)) return String.Empty;

                       var addressData = JsonConvert.DeserializeObject<Json_nominatim>(json_data);

                       if(addressData==null) return String.Empty;

                       return addressData?.DisplayName;
                   }
                   catch (Exception)
                   {
                       return String.Empty;
                   }
                   
                }


            }
            catch (Exception e)
            {
                throw e;
            }

            
        }
    }

   
}