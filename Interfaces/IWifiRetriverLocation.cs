namespace BSRetriever.Interfaces
{
    public interface IWifiRetriverLocation
    {
        (double lat, double lon) Retrive(string bssid);
    }
}