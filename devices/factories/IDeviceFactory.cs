namespace devices;

public interface IDeviceFactory
{
    // note that we're *not* using interfaces - we're using abstract versions of the original device classes
    // this is perfectly valid 
    Light CreateLight();
    SmartPlug CreateSmartPlug();
    Thermostat CreateThermostat();

}