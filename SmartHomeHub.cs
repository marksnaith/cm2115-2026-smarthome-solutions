using devices;
public class SmartHomeHub
{

    private static SmartHomeHub? instance = null;
    private IDeviceFactory factory;

    public static SmartHomeHub GetInstance(IDeviceFactory factory)
    {
        if (instance == null)
        {
            instance = new SmartHomeHub(factory);
        }
        return instance;
    }

    private Device[] devices;
    private int numDevices;

    private SmartHomeHub(IDeviceFactory factory)
    {
        this.devices = new Device[10];
        this.numDevices = 0;
        this.factory = factory;
    }

    // updated to accept a string paramter describing the device which is then obtained from the factory
    public void AddDevice(string deviceType)
    {

        Device? device = null;

        switch (deviceType)
        {
            case "light":
                device = this.factory.CreateLight();
                break;

            case "smartplug":
                device = this.factory.CreateSmartPlug();
                break;

            case "thermostat":
                device = this.factory.CreateThermostat();
                break;
        }

        if (device !=null && this.numDevices < devices.Length)
        {
            devices[this.numDevices] = device;
        }
    }

}
