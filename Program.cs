using cm2115_2026_smarthome;
using devices;

SmartHomeHub hub = SmartHomeHub.GetInstance(new AppleDeviceFactory(), new ConsoleLogger());

hub.AddDevice("light", "living room");
hub.AddDevice("smartplug", "lamp");
hub.AddDevice("light", "living room 2");
hub.AddDevice("smartplug", "living room lamp");

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

foreach(var d in hub.Devices)
{
    Console.WriteLine((d.Value is Light));
}


// searching stuff from lab 6

Dictionary<char, SmartHomeSearchCommand> searchCommands = new Dictionary<char, SmartHomeSearchCommand>();

searchCommands['1'] = SearchByName;
searchCommands['2'] = SearchByType;

Console.WriteLine("====Smart Home Console====");

Console.WriteLine("1. Search by device name");
Console.WriteLine("2. Search by device type");
Console.Write("Please select an option: ");

var input = Console.ReadKey();

if (searchCommands.Keys.Contains(input.KeyChar))
{
    searchCommands[input.KeyChar]();
}

void SearchByName()
{
    Console.Clear();
    Console.WriteLine("====Search by name====");
    Console.Write("Please enter a search term: ");
    var input = Console.ReadLine();

    if(input == null)
    {
        input = "";
    }

    var devices = (from deviceName in hub.Devices.Keys
                    where deviceName.StartsWith(input)
                    select deviceName + " (" + hub.Devices[deviceName].GetType() + ")").ToList();


    devices.ForEach(Console.WriteLine);

    Console.WriteLine("1 = sort ascending; 2 = sort descending");

    var sortInput = Console.ReadKey();

    if(sortInput.KeyChar == '1')
    {
        Console.Clear();
        
        (from device in devices
        orderby device ascending
        select device).ToList().ForEach(Console.WriteLine);
    }else if(sortInput.KeyChar == '2')
    {
        Console.Clear();

        (from device in devices
        orderby device descending
        select device).ToList().ForEach(Console.WriteLine);
    }
}

void SearchByType()
{

    // this one is a bit more complicated - we need to maintain a mapping of strings to types
    // it's also better to use method syntax because we can dynamically swap in a lambda depending on the type

    // this is...painful. Our mapping is a user entered query (string) to a Func that accepts a key-value pair (i.e. single dictionary entry) and returns a bool
    Dictionary<string, Func<KeyValuePair<string, Device>, bool>> types = new Dictionary<string, Func<KeyValuePair<string, Device>, bool>>();

    // each individual mapping is the user query to a lambda that checks if the value in the key-value pair (i.e. the Device object) is of that more specific type
    types["light"] = d => d.Value is Light;
    types["smartplug"] = d => d.Value is SmartPlug;
    types["thermostat"] = d => d.Value is Thermostat;

    Console.Clear();
    Console.WriteLine("====Search by type====");
    Console.Write("Please enter a search term: ");
    var input = Console.ReadLine();

    if(input != null)
    {
        input = input.ToLower();
        if (types.ContainsKey(input))
        {
            hub.Devices.Where(types[input]).ToList().ForEach(d=>Console.WriteLine(d.Key));
        }
    }
}


public delegate void SmartHomeSearchCommand();

