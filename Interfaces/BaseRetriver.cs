using BSRetriever.Links;
using BSRetriever.RetriversAddress;
using BSRetriever.RetriversLocation.RetriversLocation;

namespace BSRetriever.Interfaces
{
    public abstract class BaseRetriver
    {
        #region Constructors
        protected BaseRetriver((string MCC, string MNC, string LAC, string CID) data, IAddressRetriver retriverAddress = null, IRetriverLocation retriverLocation = null, ILinkLocation linkLocation = null, string apiKey = null)
        {
            Data = data;
            _retriverAddress = retriverAddress ?? new Nominatim();
            _retriverLocation = retriverLocation ?? new RetriverMyinakov();
            _linkLocation = linkLocation ?? new YandexLink(17);
            ApiKey = apiKey;
        }

        #endregion

        public string ApiKey { get; protected set; }
        public (string MCC, string MNC, string LAC, string CID) Data { get; protected set; }
        public (double lat, double lon) Location { get; protected set; }
        public string Address { get; protected set; }
        public string Link => _linkLocation.GetLink(Location);

        public bool HasLocation
        {
            get => _hasLocation;
            protected set => _hasLocation = value;
        }

        public bool HasAddress => !string.IsNullOrWhiteSpace(Address);


        #region privates
        protected IAddressRetriver _retriverAddress;
        protected IRetriverLocation _retriverLocation;
        protected ILinkLocation _linkLocation;
        private bool _hasLocation;

        #endregion

        public abstract bool Retrive();
        public abstract bool RetriveAddress();

        #region Fluent
        public BaseRetriver withRetriverLocation(IRetriverLocation retriverLocation)
        {
            this._retriverLocation = retriverLocation;
            return this;
        }

        public BaseRetriver withRetriverAddress(IAddressRetriver addressRetriver)
        {
            this._retriverAddress = addressRetriver;
            return this;
        }

        public BaseRetriver withLink(ILinkLocation linkLocation)
        {
            this._linkLocation = linkLocation;
            return this;
        }
        #endregion
    }
}