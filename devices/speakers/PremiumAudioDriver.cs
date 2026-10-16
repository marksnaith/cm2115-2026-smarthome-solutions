namespace devices.speakers;

public class PremiumAudioDriver : IAudioDriver
{
    public void PlayAudio(string track)
    {
        Console.WriteLine("Playing " + track + " on a premium audio driver");
    }
}