
public interface IComponent
{
    string Operation();
}


public class ConcreteComponent : IComponent
{
    public string Operation() => "Базовая операция";
}


public abstract class Decorator : IComponent
{
    protected IComponent _component;

    public Decorator(IComponent component) => _component = component;

    public virtual string Operation() => _component.Operation();
}


public class ConcreteDecoratorA : Decorator
{
    public ConcreteDecoratorA(IComponent component) : base(component) { }

    public override string Operation() => $"Декоратор A ({base.Operation()})";
}

public class ConcreteDecoratorB : Decorator
{
    public ConcreteDecoratorB(IComponent component) : base(component) { }

    public override string Operation() => $"Декоратор B ({base.Operation()})";
}


IComponent component = new ConcreteComponent();
component = new ConcreteDecoratorA(component);
component = new ConcreteDecoratorB(component);

Console.WriteLine(component.Operation()); 
