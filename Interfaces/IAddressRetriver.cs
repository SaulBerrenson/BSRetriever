namespace BSRetriever.Interfaces
{
    public interface IAddressRetriver
    {
        string Retrive((double lat, double lon) location, string lang = "en-US");
    }
}