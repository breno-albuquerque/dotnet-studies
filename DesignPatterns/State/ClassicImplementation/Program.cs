var switcher = new LightSwitcher(new OffState());

switcher.On();
switcher.Off();
switcher.Off();

// Context
public class LightSwitcher
{
    private LightState _lightState = null!;

    public LightSwitcher(LightState lightState)
    {
        TransitionTo(lightState);
    }
    
    public void TransitionTo(LightState lightState)
    {
        _lightState = lightState;
        _lightState.SetContext(this);
    }
    
    public void On()  
    {  
        _lightState.On();  
    }  
	  
    public void Off()  
    {  
        _lightState.Off();  
    }
}

// State
public abstract class LightState  
{  
    protected LightSwitcher LightSwitcher = null!;

    public void SetContext(LightSwitcher lightSwitcher) 
    {
        LightSwitcher = lightSwitcher;
    }

    public virtual void On()  
    {  
        Console.WriteLine("Light is already on.");  
    }  
	  
    public virtual void Off()  
    {  
        Console.WriteLine("Light is already off.");  
    }  
}

// Concrete State
public class OnState : LightState  
{  
    public OnState()  
    {  
        Console.WriteLine("Light turned on.");  
    }  
	  
    public override void Off()  
    {  
        Console.WriteLine("Turning light off...");
        LightSwitcher.TransitionTo(new OffState());
    }  
}

// Concrete State
public class OffState : LightState  
{  
    public OffState()  
    {  
        Console.WriteLine("Light turned off.");  
    }  
	  
    public override void On()  
    {  
        Console.WriteLine("Turning light on...");  
        LightSwitcher.TransitionTo(new OnState());
    }  
}