
public interface ITemperatureStrategy
{
    void AdjustTemperature();
}

public class EconomyTemperatureStrategy : ITemperatureStrategy
{
    public void AdjustTemperature()
    {
        Console.WriteLine("Установлен экономичный режим: +18°C днем, +16°C ночью");
    }
}

public class ComfortTemperatureStrategy : ITemperatureStrategy
{
    public void AdjustTemperature()
    {
        Console.WriteLine("Установлен комфортный режим: +22°C днем, +20°C ночью");
    }
}

public class AwayTemperatureStrategy : ITemperatureStrategy
{
    public void AdjustTemperature()
    {
        Console.WriteLine("Установлен режим 'Нет дома': +15°C постоянно");
    }
}

public class TemperatureController
{
    private ITemperatureStrategy _strategy;

    public void SetStrategy(ITemperatureStrategy strategy)
    {
        _strategy = strategy;
    }

    public void ExecuteTemperatureControl()
    {
        _strategy?.AdjustTemperature();
    }
}

public class StrategyExample
{
    public static void Run()
    {
        
        var controller = new TemperatureController();
        
        controller.SetStrategy(new ComfortTemperatureStrategy());
        controller.ExecuteTemperatureControl();
        
        controller.SetStrategy(new EconomyTemperatureStrategy());
        controller.ExecuteTemperatureControl();
    }
}
