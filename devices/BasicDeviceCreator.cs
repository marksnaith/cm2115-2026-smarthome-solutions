namespace cm2115_2026_smarthome;

using System.Data;
using devices;

public class BasicDeviceCreator : IDeviceCreator
{
    public Device? CreateDevice(string deviceType, string name, IDeviceFactory factory, out Dictionary<string, SmartHomeCommand> commands)
    {
        commands = new Dictionary<string, SmartHomeCommand>();

        switch (deviceType)
        {
            case "light":
                Light tempLight = factory.CreateLight();
                name += " light";

                // add the commands associated with this light
                commands["turn on " + name] = tempLight.SwitchOn;
                commands["turn off " + name] = tempLight.SwitchOff;
                commands["dim up " + name] = tempLight.DimUp;
                commands["dim down " + name] = tempLight.DimDown;

                return tempLight;

            case "smartplug":
                SmartPlug tempPlug = factory.CreateSmartPlug();
                name += " plug";

                // add the commands associated with this plug
                commands["turn on " + name] = tempPlug.SwitchOn;
                commands["turn off " + name] = tempPlug.SwitchOff;

                return tempPlug;

            case "thermostat":
                Thermostat tempThermostat = factory.CreateThermostat();
                name += " thermostat";

                // add the commands associated with this thermostat
                commands["turn up " + name] = tempThermostat.TurnUp;
                commands["turn down " + name] = tempThermostat.TurnDown;

                return tempThermostat;
        }

        return null;
    }

}
