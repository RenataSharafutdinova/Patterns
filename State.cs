using System;

public interface IState
{
    void Handle(Context context);
}

public class StateA : IState
{
    public void Handle(Context context)
    {
        Console.WriteLine("Состояние A: переход в StateB");
        context.State = new StateB();
    }
}

public class StateB : IState
{
    public void Handle(Context context)
    {
        Console.WriteLine("Состояние B: переход в StateA");
        context.State = new StateA();
    }
}

public class Context
{
    public IState State { get; set; }

    public Context(IState state)
    {
        State = state;
    }

    public void Request()
    {
        State.Handle(this);
    }
}

var context = new Context(new StateA());
context.Request(); 
context.Request(); 
