using cm2115_2026_smarthome;
using devices;

SmartHomeHub hub = SmartHomeHub.GetInstance(new AppleDeviceFactory(), new ConsoleLogger());

hub.AddDevice("light", "living room");
hub.AddDevice("smartplug", "lamp");

hub.ExecuteCommand("switch on living room light");

Device? device = hub.GetDevice("living room");

if(device != null)
{
    Console.WriteLine(device.Status);
}

IDeviceVisitor diagnostic = new DiagnosticVisitor();

foreach(var d in hub.Devices)
{
    d.Value.Accept(diagnostic);
}