
public abstract class Handler
{
    protected Handler _nextHandler;

    public void SetNext(Handler handler)
    {
        _nextHandler = handler;
    }

    public abstract void HandleRequest(int request);
}

public class ConcreteHandler1 : Handler
{
    public override void HandleRequest(int request)
    {
        if (request <= 10)
            Console.WriteLine($"ConcreteHandler1 обработал запрос {request}");
        else if (_nextHandler != null)
            _nextHandler.HandleRequest(request);
    }
}

public class ConcreteHandler2 : Handler
{
    public override void HandleRequest(int request)
    {
        if (request > 10 && request <= 20)
            Console.WriteLine($"ConcreteHandler2 обработал запрос {request}");
        else if (_nextHandler != null)
            _nextHandler.HandleRequest(request);
    }
}

public class DefaultHandler : Handler
{
    public override void HandleRequest(int request)
    {
        Console.WriteLine($"Запрос {request} никто не обработал!");
    }
}

var handler1 = new ConcreteHandler1();
var handler2 = new ConcreteHandler2();
var defaultHandler = new DefaultHandler();

handler1.SetNext(handler2);
handler2.SetNext(defaultHandler);

handler1.HandleRequest(5);  // Обработает handler1
handler1.HandleRequest(15); // Обработает handler2
handler1.HandleRequest(25); // Попадет в defaultHandler
