using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using BSRetriever.Interfaces;

namespace BSRetriever.RetriversLocation.RetriversLocation
{
    public class RetriverCell2Gps : IRetriverLocation
    {
        private const string pattern = @"location is \((.*),(.*)\) Accuracy:.* m";
        public (double lat, double lon) Retrive((string MCC, string MNC, string LAC, string CID) data)
        {
            try
            {
                using (HttpClient client = new HttpClient() { })
                {
                    //mcc=250&mnc=1&mobile_type=1&lac=17807&cellid=51525398&sid=&nid=&bid=
                    var postData = new FormUrlEncodedContent(new Dictionary<string, string>
                    {
                        { "mcc", data.MCC },
                        { "mnc", data.MNC},
                        { "mobile_type", "1" },
                        { "lac", data.LAC },
                        { "cellid", data.CID},
                        { "sid",  string.Empty},
                        { "nid", string.Empty },
                        { "bid", string.Empty },
                    });

                    var response = client.PostAsync("http://www.cell2gps.com/", postData).Result?.Content.ReadAsStringAsync()?.Result;
                    if (string.IsNullOrWhiteSpace(response)) return (0, 0);

                    var rexpParser = new Regex(pattern);
                    if(!rexpParser.IsMatch(response)) return (0, 0);

                    var match = rexpParser.Match(response);
                    return (double.Parse(match.Groups[1].Value, CultureInfo.InvariantCulture), double.Parse(match.Groups[2].Value, CultureInfo.InvariantCulture));
                }
            }
            catch (Exception e)
            {
                return (0, 0);
            }
           
        }
    }
}