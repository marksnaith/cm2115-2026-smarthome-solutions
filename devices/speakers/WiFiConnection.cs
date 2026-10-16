namespace devices.speakers;

public class WiFiConnection : IConnection
{
    public void Connect()
    {
        Console.WriteLine("Connected via WiFi");
    }
}