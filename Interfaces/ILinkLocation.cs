namespace BSRetriever.Interfaces
{
    public interface ILinkLocation
    {
        string GetLink((double lat, double lon) location);
    }
}