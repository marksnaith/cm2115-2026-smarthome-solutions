namespace devices.speakers;

public class Speaker : Device, ISwitch, IPlay // extend device but also implements ISwitch because we can switch on and off
{
    private IConnection connection;
    private IAudioDriver audioDriver;
    private IPowerAdapter powerAdapter;

    public Speaker(IConnection connection, IAudioDriver audioDriver, IPowerAdapter powerAdapter)
    {
        this.connection = connection;
        this.audioDriver = audioDriver;
        this.powerAdapter = powerAdapter;
    }

    public void Play(string track)
    {
        this.audioDriver.PlayAudio(track);
    }

    public void Stop()
    {
        Console.WriteLine("Stopping playback");
    }

    public void ConnectNetwork()
    {
        this.connection.Connect();
    }

    public void SwitchOn()
    {
        this.powerAdapter.SwitchOn();
    }

    public void SwitchOff()
    {
        this.powerAdapter.SwitchOff();
    }
}