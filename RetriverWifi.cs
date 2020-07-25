using BSRetriever.Links;
using BSRetriever.RetriversAddress;

namespace BSRetriever.Interfaces
{
    public class RetriverWifi : BaseRetriver
    {
        public RetriverWifi(string data, IAddressRetriver retriverAddress = null, ILinkLocation linkLocation = null) : base(retriverAddress, linkLocation)
        {
            Data = data;
            retriverAddress = retriverAddress ?? new Nominatim();
            linkLocation = linkLocation ?? new YandexLink();
        }

        public string Data { get; protected set; }


        #region private

        private IWifiRetriverLocation _retriverLocation;
        #endregion

        public override bool Retrive()
        {
            var retrived = _retriverLocation.Retrive(Data);
            Location = retrived;
            if (retrived == (0, 0))
            {
                HasLocation = false;
                return false;
            }
            HasLocation = true;
            return true;
        }

        #region Fluent

        public RetriverWifi setData(string data)
        {
            Data = data;
            return this;
        }
        public RetriverWifi withLocationRetriver(IWifiRetriverLocation retriverLocation)
        {
            this._retriverLocation = retriverLocation;
            return this;
        }


        public RetriverWifi withRetriverAddress(IAddressRetriver addressRetriver)
        {
            this._retriverAddress = addressRetriver;
            return this;
        }

        public RetriverWifi withLink(ILinkLocation linkLocation)
        {
            this._linkLocation = linkLocation;
            return this;
        }
        #endregion
    }
}