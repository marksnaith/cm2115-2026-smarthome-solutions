namespace devices;

public class SmartPlug : Device, ISwitch
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
