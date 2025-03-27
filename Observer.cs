using System.Collections.Generic;

public interface IHomeEventObserver
{
    void Update(string eventMessage);
}


public interface IHomeEventSubject
{
    void RegisterObserver(IHomeEventObserver observer);
    void RemoveObserver(IHomeEventObserver observer);
    void NotifyObservers();
}


public class HomeSecuritySystem : IHomeEventSubject
{
    private List<IHomeEventObserver> _observers = new List<IHomeEventObserver>();
    private string _lastEvent;

    public void RegisterObserver(IHomeEventObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IHomeEventObserver observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.Update(_lastEvent);
        }
    }

    public void SecurityEventOccurred(string eventMessage)
    {
        _lastEvent = eventMessage;
        Console.WriteLine($"Произошло событие безопасности: {eventMessage}");
        NotifyObservers();
    }
}

public class MobileApp : IHomeEventObserver
{
    private string _userName;

    public MobileApp(string userName)
    {
        _userName = userName;
    }

    public void Update(string eventMessage)
    {
        Console.WriteLine($"[Мобильное приложение для {_userName}] Получено уведомление: {eventMessage}");
    }
}

public class SmartSpeaker : IHomeEventObserver
{
    public void Update(string eventMessage)
    {
        Console.WriteLine($"[Умная колонка] Озвучиваю уведомление: {eventMessage}");
    }
}

public class ObserverExample
{
    public static void Run()
    {
        
        var securitySystem = new HomeSecuritySystem();
        var userApp = new MobileApp("Иван Иванов");
        var speaker = new SmartSpeaker();
        
        securitySystem.RegisterObserver(userApp);
        securitySystem.RegisterObserver(speaker);
        
        securitySystem.SecurityEventOccurred("Обнаружено движение у входной двери");
        
        securitySystem.RemoveObserver(speaker);
        securitySystem.SecurityEventOccurred("Окно в гостиной открыто");
    }
}
