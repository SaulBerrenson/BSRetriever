namespace BSRetriever.Interfaces
{
    public interface IRetriverLocation
    {
        (double lat, double lon) Retrive((double lat, double lon) loc);
    }
}