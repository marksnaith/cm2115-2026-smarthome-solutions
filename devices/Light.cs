namespace devices;

public class Light : Device, ISwitch, IDim
{
    public void SwitchOn()
    {
        Console.WriteLine("Light switched on");
        this.status = "light is on";
    }

    public void SwitchOff()
    {
        Console.WriteLine("Light switched off");
        this.status = "light is off";
    }

    public void DimUp()
    {
        Console.WriteLine("Light dimmed up");
        this.status = "light is dimmed up";
    }

    public void DimDown()
    {
        Console.WriteLine("Light dimmed down");
        this.status = "light is dimmed down";
    }

}
