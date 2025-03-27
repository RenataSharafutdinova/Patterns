
public interface IHomeCommand
{
    void Execute();
    void Undo();
}

public class LightOnCommand : IHomeCommand
{
    private SmartLight _light;

    public LightOnCommand(SmartLight light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.TurnOn();
    }

    public void Undo()
    {
        _light.TurnOff();
    }
}

public class LightOffCommand : IHomeCommand
{
    private SmartLight _light;

    public LightOffCommand(SmartLight light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.TurnOff();
    }

    public void Undo()
    {
        _light.TurnOn();
    }
}

public class ThermostatSetCommand : IHomeCommand
{
    private SmartThermostat _thermostat;
    private int _temperature;
    private int _previousTemperature;

    public ThermostatSetCommand(SmartThermostat thermostat, int temperature)
    {
        _thermostat = thermostat;
        _temperature = temperature;
    }

    public void Execute()
    {
        _previousTemperature = _thermostat.CurrentTemperature;
        _thermostat.SetTemperature(_temperature);
    }

    public void Undo()
    {
        _thermostat.SetTemperature(_previousTemperature);
    }
}


public class SmartLight
{
    public void TurnOn()
    {
        Console.WriteLine("Свет включен");
    }

    public void TurnOff()
    {
        Console.WriteLine("Свет выключен");
    }
}

public class SmartThermostat
{
    public int CurrentTemperature { get; private set; } = 20;

    public void SetTemperature(int temperature)
    {
        CurrentTemperature = temperature;
        Console.WriteLine($"Термостат установлен на {temperature}°C");
    }
}

public class SmartRemoteControl
{
    private IHomeCommand _command;

    public void SetCommand(IHomeCommand command)
    {
        _command = command;
    }

    public void PressButton()
    {
        _command?.Execute();
    }

    public void PressUndo()
    {
        _command?.Undo();
    }
}

public class CommandExample
{
    public static void Run()
    {
        
        var remote = new SmartRemoteControl();
        var livingRoomLight = new SmartLight();
        var bedroomThermostat = new SmartThermostat();
        
      
        remote.SetCommand(new LightOnCommand(livingRoomLight));
        remote.PressButton();
        remote.PressUndo();
        
    
        remote.SetCommand(new ThermostatSetCommand(bedroomThermostat, 23));
        remote.PressButton();
        remote.PressUndo();
    }
}


class Program
{
    static void Main()
    {
        StrategyExample.Run();
        ObserverExample.Run();
        CommandExample.Run();
    }
}
