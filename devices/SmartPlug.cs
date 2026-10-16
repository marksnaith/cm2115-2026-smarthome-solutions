namespace devices;

public abstract class SmartPlug : Device, ISmartPlug
{
    public void SwitchOn()
    {
        Console.WriteLine("Smart plug switched on");
    }

    public void SwitchOff()
    {
        Console.WriteLine("Smart plug switched off");
    }
}
