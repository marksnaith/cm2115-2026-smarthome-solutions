namespace devices.speakers;

public class DCPowerAdapter : IPowerAdapter
{
    public void SwitchOff()
    {
        Console.WriteLine("Switched on DC power adapter");
    }

    public void SwitchOn()
    {
        Console.WriteLine("Switched off DC power adapter");
    }
}