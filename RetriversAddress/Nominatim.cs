using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using BSRetriever.Extantions;
using BSRetriever.Interfaces;
using BSRetriever.RetriversAddress.Json;
using Newtonsoft.Json;

namespace BSRetriever.RetriversAddress
{
    public class Nominatim : IAddressRetriver
    {
        public string Retrive((double lat, double lon) location, string lang = "en-US")
        {
            try
            {
               // 

               using (WebClient clientHttp = new WebClient(){Headers = new WebHeaderCollection()
               {
                   {HttpRequestHeader.UserAgent,"Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:78.0) Gecko/20100101 Firefox/78.0"},
                   {HttpRequestHeader.Accept,"application/json; charset=UTF-8"},
                   {HttpRequestHeader.AcceptLanguage, lang},

               }})
               {
                   try
                   {
                       var link =
                           $"https://nominatim.openstreetmap.org/reverse?format=json&lat={location.lat.DoubleWithDot()}&lon={location.lon.DoubleWithDot()}&zoom=18&addressdetails=0";
                       var json_data = clientHttp.DownloadString(
                           link);

                       if (string.IsNullOrWhiteSpace(json_data)) return String.Empty;

                       var addressData = JsonConvert.DeserializeObject<Json_nominatim>(json_data);

                       if(addressData==null) return String.Empty;

                       return addressData?.DisplayName;
                   }
                   catch (Exception exception) 
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