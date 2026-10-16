namespace devices;

public interface IPlay // new IPlay interface for things that can be played and stopped
{
    void Play(string track);
    void Stop();
}