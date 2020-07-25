using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using BSRetriever.Interfaces;
using BSRetriever.RetriversAddress;
using BSRetriever.RetriversAddress.Json.Myinkov;

namespace BSRetriever.RetriversLocation
{
    public class Retriver : BaseRetriver
    {
        public Retriver((string MCC, string MNC, string LAC, string CID) data, IAddressRetriver retriverAddress = null, IRetriverLocation retriverLocation = null, ILinkLocation linkLocation = null, string apiKey = null) : base(data, retriverAddress, retriverLocation, linkLocation, apiKey)
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