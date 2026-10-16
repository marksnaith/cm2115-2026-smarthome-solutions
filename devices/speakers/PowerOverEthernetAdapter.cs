namespace devices.speakers;

public class PowerOverEthernetAdapter : IPowerAdapter
{
    public void SwitchOff()
    {
        Console.WriteLine("Switched on PoE adapter");
    }

    public void SwitchOn()
    {
        Console.WriteLine("Switched off PoE adapter");
    }
}