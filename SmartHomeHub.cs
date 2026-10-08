using devices;
public class SmartHomeHub
{
    private Device[] devices;
    private int numDevices;

    public SmartHomeHub()
    {
        this.devices = new Device[10];
        this.numDevices = 0;
    }

    public void AddDevice(Device device)
    {
        if(this.numDevices < devices.Length)
        {
            devices[this.numDevices] = device;
        }
    }

}
