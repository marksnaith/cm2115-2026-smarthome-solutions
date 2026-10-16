namespace devices;

public class GoogleDeviceFactory : IDeviceFactory
{
    public Light CreateLight()
    {
        return new GoogleLight();
    }

    public SmartPlug CreateSmartPlug()
    {
        return new GoogleSmartPlug();
    }

    public Thermostat CreateThermostat()
    {
        return new GoogleThermostat();
    }
}