using devices;
using devices.speakers;

namespace cm2115_2026_smarthome;

public interface IDeviceVisitor
{
    void Visit(Light light);
    void Visit(SmartPlug plug);
    void Visit(Thermostat thermostat);
    void Visit(Speaker speaker);
}
