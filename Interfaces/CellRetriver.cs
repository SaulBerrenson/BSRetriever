using BSRetriever.Links;
using BSRetriever.RetriversAddress;
using BSRetriever.RetriversLocation.RetriversLocation;

namespace BSRetriever.Interfaces
{
    public abstract class CellRetriver : BaseRetriver
    {
        #region Constructors
        protected CellRetriver((string MCC, string MNC, string LAC, string CID) data, IAddressRetriver retriverAddress, ILinkLocation linkLocation, IRetriverLocation retriverLocation, string apiKey) : base(retriverAddress, linkLocation)
        {
            Data = data;
            _retriverLocation = retriverLocation;
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
        protected IRetriverLocation _retriverLocation;
        #endregion

        #region Fluent
        public CellRetriver withLocationRetriver(IRetriverLocation retriverLocation)
        {
            this._retriverLocation = retriverLocation;
            return this;
        }


        public CellRetriver withRetriverAddress(IAddressRetriver addressRetriver)
        {
            this._retriverAddress = addressRetriver;
            return this;
        }

        public CellRetriver withLink(ILinkLocation linkLocation)
        {
            this._linkLocation = linkLocation;
            return this;
        }
        #endregion
    }
}