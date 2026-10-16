namespace devices.speakers;

public class EthernetConnection : IConnection
{
    public void Connect()
    {
        Console.WriteLine("Connected via Ethernet");
    }
}