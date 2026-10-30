using cm2115_2026_smarthome;
using devices;
using Microsoft.VisualBasic;
public class SmartHomeHub
{
    private static SmartHomeHub? instance = null;
    private IDeviceFactory factory;
    private Dictionary<string, SmartHomeCommand> commands = new Dictionary<string, SmartHomeCommand>();
    private ILoggingStrategy logger;

    public static SmartHomeHub GetInstance(IDeviceFactory factory, ILoggingStrategy logger)
    {
        if (instance == null)
        {
            instance = new SmartHomeHub(factory, logger);
        }
        return instance;
    }

    // changed to use a dictionary - more extendible and allows for mapping of names to devices
    //private Device[] devices;
    public Dictionary<string, Device> Devices {get;}

    private LightSensor lightSensor = new LightSensor();

    private int numDevices;

    private SmartHomeHub(IDeviceFactory factory, ILoggingStrategy logger)
    {
        //this.devices = new Device[10];
        this.Devices = new Dictionary<string, Device>();
        //this.numDevices = 0;
        this.factory = factory;
        this.logger = logger;
    }


    // an alternative version of AddDevice that delegates the device creation to a provided class
    // this means that new device types can be added (assuming relevant updates to AbstractFactory)
    // without needing to modify this class - thus adhering to the open-closed principle

    public void AddDevice(string deviceType, string name, IDeviceCreator creator)
    {
        if (creator != null)
        {
            Device? device = creator.CreateDevice(deviceType, name, this.factory, out var commands);

            if (device != null)
            {
                this.Devices[name] = device;
                foreach(var command in commands)
                {
                    this.commands[command.Key] = command.Value; // this will overwrite duplicate keys rather than raising an exception
                }

                // a little bit hack-y for registering a device of type light with a sensor - check if type is light then cast it to register
                // there's more elegant solutions - see if you can come up with one
                if(device is Light)
                {
                    this.lightSensor.RegisterObserver((Light)device);
                }
            }
        }
    }

    // updated to accept a string paramter describing the device which is then obtained from the factory
    // updated in lab 5 to store commands associated with devices
    //      - add a new parameter to give the device a name which is used in commands
    //      - change how each device is obtained from the factory, assigning it to its concrete type
    //      - use the concrete type to map commands
    //      - assign the concrete type into the generic Device variable for adding to the array
    public void AddDevice(string deviceType, string name)
    {
        Device? device = null;

        switch (deviceType)
        {
            case "light":
                Light tempLight = this.factory.CreateLight();

                // add the commands associated with this light
                this.commands["switch on " + name + " light"] = tempLight.SwitchOn;
                this.commands["switch off " + name + " light"] = tempLight.SwitchOff;
                this.commands["dim up " + name + " light"] = tempLight.DimUp;
                this.commands["dim down " + name + " light"] = tempLight.DimDown;

                device = tempLight;

                this.lightSensor.RegisterObserver(tempLight);
                break;

            case "smartplug":
                SmartPlug tempPlug = this.factory.CreateSmartPlug();
                name += " plug";

                // add the commands associated with this plug
                this.commands["turn on " + name + " plug"] = tempPlug.SwitchOn;
                this.commands["turn off " + name + " plug"] = tempPlug.SwitchOff;

                device = tempPlug;
                break;

            case "thermostat":
                Thermostat tempThermostat = this.factory.CreateThermostat();
                name += " thermostat";

                // add the commands associated with this thermostat
                this.commands["turn up " + name + " thermostat"] = tempThermostat.TurnUp;
                this.commands["turn down " + name + " thermostat"] = tempThermostat.TurnDown;

                device = tempThermostat;
                break;
        }

        if (device != null)
        {
            this.Devices[name] = device;
        }
    }

    // added in Lab 5 for executing commands
    public void ExecuteCommand(string label)
    {
        if (this.commands.ContainsKey(label))
        {
            this.commands[label](); // executes the command
            this.logger.Log("Executed command " + label);
        }
    }

    public Device? GetDevice(string name)
    {
        return this.Devices[name];
    }
}

// delegate for modelling commands
public delegate void SmartHomeCommand();