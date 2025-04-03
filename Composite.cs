using System;
using System.Collections.Generic;

public abstract class Component
{
    public string Name { get; }

    protected Component(string name) => Name = name;

    public abstract void Display(int depth = 0);
}


public class Leaf : Component
{
    public Leaf(string name) : base(name) { }

    public override void Display(int depth = 0) =>
        Console.WriteLine(new string('-', depth) + Name);
}


public class Composite : Component
{
    private List<Component> _children = new List<Component>();

    public Composite(string name) : base(name) { }

    public void Add(Component component) => _children.Add(component);
    public void Remove(Component component) => _children.Remove(component);

    public override void Display(int depth = 0)
    {
        Console.WriteLine(new string('-', depth) + Name);
        foreach (var child in _children)
            child.Display(depth + 2);
    }
}


var root = new Composite("Root");
root.Add(new Leaf("Leaf A"));
root.Add(new Leaf("Leaf B"));

var composite = new Composite("Composite X");
composite.Add(new Leaf("Leaf XA"));
composite.Add(new Leaf("Leaf XB"));

root.Add(composite);
root.Display();
