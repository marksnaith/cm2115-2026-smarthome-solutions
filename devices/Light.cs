namespace devices;

// light class now abstract and inherited by concrete lights in the factories
public abstract class Light : Device, ILight
{

    public bool On {get; private set;} = false;
    public int Level {get; private set
        {
            if(value > 100)
            {
                value = 100;
            }else if(value < 0)
            {
                value = 0;
            }

            field = value; // this sets the value of Level to the provided value

            if(value == 0)
            {
                this.SwitchOff(); // ensures the light is off if value = 0
            }
            else
            {
                this.SwitchOn(); // ensures the light is on
            }
        }
    }

    public void SwitchOn()
    {
        this.status = "light is on";
        this.On = true;
    }

    public void SwitchOff()
    {
        this.status = "light is off";
        this.On = false;
    }

    public void DimUp()
    {
        this.Level++;
    }

    public void DimDown()
    {
        this.Level--;
    }
}
