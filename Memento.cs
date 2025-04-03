
public class Originator
{
    public string State { get; set; }

    public Memento CreateMemento() => new Memento(State);
    public void RestoreMemento(Memento memento) => State = memento.State;
}


public class Memento
{
    public string State { get; }

    public Memento(string state) => State = state;
}


public class Caretaker
{
    public Memento Memento { get; set; }
}

var originator = new Originator { State = "Состояние 1" };
var caretaker = new Caretaker { Memento = originator.CreateMemento() };

originator.State = "Состояние 2";
Console.WriteLine($"Текущее состояние: {originator.State}"); // Состояние 2

originator.RestoreMemento(caretaker.Memento);
Console.WriteLine($"Восстановленное состояние: {originator.State}"); // Состояние 1
