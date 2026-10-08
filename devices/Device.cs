namespace devices;

public abstract class Device
{
    public string Status
    {
        get => status;
    }

    protected string status;
    public Device()
    {
        this.status = "Unknown";
    }
}