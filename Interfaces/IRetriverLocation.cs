namespace BSRetriever.Interfaces
{
    public interface IRetriverLocation
    {
        (double lat, double lon) Retrive((string MCC, string MNC, string LAC, string CID) data);
    }
}