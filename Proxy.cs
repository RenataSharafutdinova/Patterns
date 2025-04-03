using System;


public interface ISubject
{
    void Request();
}


public class RealSubject : ISubject
{
    public void Request() => Console.WriteLine("RealSubject: Обработка запроса");
}


public class Proxy : ISubject
{
    private RealSubject _realSubject;

    public void Request()
    {
        if (_realSubject == null)
            _realSubject = new RealSubject();

        Console.WriteLine("Proxy: Проверка доступа...");
        _realSubject.Request();
        Console.WriteLine("Proxy: Логирование запроса...");
    }
}

ISubject proxy = new Proxy();
proxy.Request();
