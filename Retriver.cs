using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using BSRetriever.Interfaces;
using BSRetriever.RetriversAddress;
using BSRetriever.RetriversAddress.Json.Myinkov;

namespace BSRetriever.RetriversLocation
{
    public class Retriver : CellRetriver
    {
        public Retriver((string MCC, string MNC, string LAC, string CID) data, IAddressRetriver retriverAddress = null, ILinkLocation linkLocation = null, IRetriverLocation retriverLocation = null, string apiKey = null) : base(data,retriverAddress, linkLocation, retriverLocation, apiKey)
        {
        }

        public override bool Retrive()
        {
            var retrived= _retriverLocation.Retrive(Data);
            Location = retrived;
            if (retrived == (0, 0))
            {
                HasLocation = false;
                return false;
            }
            HasLocation = true;
            return true;

        }

        public override bool RetriveAddress()
        {
            if (HasLocation)
            {
                _retriverAddress = _retriverAddress ?? new Nominatim();

                Address = _retriverAddress.Retrive(location: Location);
                return true;
            }

            return false;
        }

       

    }
}