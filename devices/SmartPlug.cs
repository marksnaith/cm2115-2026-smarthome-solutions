using cm2115_2026_smarthome;

namespace devices;

public abstract class SmartPlug : Device
{
    public void SwitchOn()
    {
        Console.WriteLine("Smart plug switched on");
    }

    public void SwitchOff()
    {
        Console.WriteLine("Smart plug switched off");
    }

    public override void Accept(IDeviceVisitor visitor)
    {
        visitor.Visit(this);
    }
}
