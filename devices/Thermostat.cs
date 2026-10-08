namespace devices;

public class Thermostat : Device, IAdjust
{

    private int temperature = 15;

    public void TurnUp()
    {
        temperature += 1;
        this.status = "Temperature is set to " + temperature;
        Console.WriteLine("Thermostat turned up");
    }

    public void TurnDown()
    {
        temperature -= 1;
        this.status = "Temperature is set to " + temperature;
        Console.WriteLine("Thermostate turned down");
    }
}
