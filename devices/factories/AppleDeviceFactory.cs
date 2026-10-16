namespace devices;

public class AppleDeviceFactory : IDeviceFactory
{
    public Light CreateLight()
    {
        return new AppleLight();
    }

    public SmartPlug CreateSmartPlug()
    {
        return new AppleSmartPlug();
    }

    public Thermostat CreateThermostat()
    {
        return new AppleThermostat();
    }
}