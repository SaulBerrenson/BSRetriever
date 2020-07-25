namespace BSRetriever.Interfaces
{
    public abstract class BaseRetriver
    {
        public (string MCC, string MNC, string LAC, string CID) Data { get; protected set; }
        public (double lat, double lon) Location { get; protected set; }
        public string Address { get; protected set; }
        public bool HasLocation => Location.lat > 0;
        public bool HasAddress => !string.IsNullOrWhiteSpace(Address);

        private IAddressRetriver _retriverAddress;
        private IRetriverLocation _retriverLocation;
       
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
        #endregion
    }
}