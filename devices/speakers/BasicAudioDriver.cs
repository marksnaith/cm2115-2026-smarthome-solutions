namespace devices.speakers;

public class BasicAudioDriver : IAudioDriver
{
    public void PlayAudio(string track)
    {
        Console.WriteLine("Playing " + track + " on a basic audio driver");
    }
}