using System.Runtime.CompilerServices;

namespace cm2115_2026_smarthome;

public class LightSensor
{
    private List<ILightObserver> observers = new List<ILightObserver>();

    public void RegisterObserver(ILightObserver observer)
    {
        this.observers.Add(observer);
    }

    private void NotifyObservers(int lightLevel)
    {
        foreach(var observer in this.observers)
        {
            observer.Update(lightLevel);
        }
    }

    // method to emulate light level changing
    public void LightLevelChange(int newLevel)
    {
        Console.WriteLine("Ligh sensor detects light level at " + newLevel);
        this.NotifyObservers(newLevel);
    }
}
