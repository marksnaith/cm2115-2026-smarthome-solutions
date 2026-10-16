namespace devices;

public abstract class Thermostat : Device, IThermostat
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
