using devices;
using devices.speakers;

namespace cm2115_2026_smarthome;

public class DiagnosticVisitor : IDeviceVisitor
{
    public void Visit(Light light)
    {
        Console.WriteLine("Diagnostics for light");
        light.SwitchOn();
        light.DimUp();
        light.DimDown();
        light.SwitchOff();
    }

    public void Visit(SmartPlug plug)
    {
        Console.WriteLine("Diagnostics for plug");
        plug.SwitchOn();
        plug.SwitchOff();
    }

    public void Visit(Thermostat thermostat)
    {
        Console.WriteLine("Diagnostics for thermostat");
        thermostat.TurnUp();
        thermostat.TurnDown();
    }

    public void Visit(Speaker speaker)
    {
        Console.WriteLine("Diagnostics for speaker");
        speaker.ConnectNetwork();
        speaker.Play("Track");
        speaker.Stop();
    }
}
