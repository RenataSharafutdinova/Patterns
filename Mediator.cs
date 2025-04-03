using System;


public interface IChatMediator
{
    void SendMessage(string message, User user);
    void AddUser(User user);
}

public class ChatMediator : IChatMediator
{
    private List<User> _users = new List<User>();

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public void SendMessage(string message, User sender)
    {
        foreach (var user in _users)
        {
            if (user != sender) 
                user.Receive(message);
        }
    }
}

public class User
{
    private IChatMediator _mediator;
    public string Name { get; }

    public User(string name, IChatMediator mediator)
    {
        Name = name;
        _mediator = mediator;
    }

    public void Send(string message)
    {
        Console.WriteLine($"{Name} отправляет: {message}");
        _mediator.SendMessage(message, this);
    }

    public void Receive(string message)
    {
        Console.WriteLine($"{Name} получил: {message}");
    }
}


var mediator = new ChatMediator();
var user1 = new User("Алексей", mediator);
var user2 = new User("Мария", mediator);
var user3 = new User("Иван", mediator);

mediator.AddUser(user1);
mediator.AddUser(user2);
mediator.AddUser(user3);

user1.Send("Привет всем!");
