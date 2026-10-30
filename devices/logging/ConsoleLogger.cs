namespace cm2115_2026_smarthome;

public class ConsoleLogger : ILoggingStrategy
{
    public void Log(string message)
    {
        Console.WriteLine("Logged: " + message);
    }
}
