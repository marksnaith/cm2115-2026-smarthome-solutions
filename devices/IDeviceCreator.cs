using devices;

namespace cm2115_2026_smarthome;

public interface IDeviceCreator
{
    Device? CreateDevice(string type, string name, IDeviceFactory factory, out Dictionary<string, SmartHomeCommand> commands);
}
