using BSRetriever.Links;
using BSRetriever.RetriversAddress;

namespace BSRetriever.Interfaces
{
    public abstract class BaseRetriver
    {
        protected BaseRetriver(IAddressRetriver retriverAddress, ILinkLocation linkLocation)
        {
            _retriverAddress = retriverAddress;
            _linkLocation = linkLocation;
        }

        public (double lat, double lon) Location { get; protected set; }
        public string Address { get; protected set; }
        public string Link => _linkLocation.GetLink(Location);
        public bool HasAddress => !string.IsNullOrWhiteSpace(Address);

        public bool HasLocation
        {
            get => _hasLocation;
            protected set => _hasLocation = value;
        }


        #region private
        protected IAddressRetriver _retriverAddress;
        protected ILinkLocation _linkLocation;
        protected bool _hasLocation;
        #endregion



        public abstract bool Retrive();
        public abstract bool RetriveAddress();

        #region Fluent


        #endregion
    }
}