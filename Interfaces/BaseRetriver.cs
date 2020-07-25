namespace BSRetriever.Interfaces
{
    public abstract class BaseRetriver
    {
        #region Constructors
        protected BaseRetriver((string MCC, string MNC, string LAC, string CID) data)
        {
            Data = data;
        }

        protected BaseRetriver(IRetriverLocation retriverLocation, (string MCC, string MNC, string LAC, string CID) data)
        {
            _retriverLocation = retriverLocation;
            Data = data;
        }

        protected BaseRetriver(IAddressRetriver retriverAddress, IRetriverLocation retriverLocation, (string MCC, string MNC, string LAC, string CID) data)
        {
            _retriverAddress = retriverAddress;
            _retriverLocation = retriverLocation;
            Data = data;
        }

        protected BaseRetriver(IAddressRetriver retriverAddress, (string MCC, string MNC, string LAC, string CID) data)
        {
            _retriverAddress = retriverAddress;
            Data = data;
        }
        #endregion

        public (string MCC, string MNC, string LAC, string CID) Data { get; protected set; }
        public (double lat, double lon) Location { get; protected set; }
        public string Address { get; protected set; }
        public string Link => _linkLocation.GetLink(Location);
        public bool HasLocation => Location.lat > 0;
        public bool HasAddress => !string.IsNullOrWhiteSpace(Address);


        #region privates
        private IAddressRetriver _retriverAddress;
        private IRetriverLocation _retriverLocation;
        private ILinkLocation _linkLocation;
        #endregion

        public abstract bool Retrive();
        public abstract bool GetAddress();

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