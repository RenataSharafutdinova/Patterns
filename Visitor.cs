
public interface IElement
{
    void Accept(IVisitor visitor);
}


public class ElementA : IElement
{
    public void Accept(IVisitor visitor) => visitor.VisitElementA(this);
    public string OperationA() => "Операция A";
}

public class ElementB : IElement
{
    public void Accept(IVisitor visitor) => visitor.VisitElementB(this);
    public string OperationB() => "Операция B";
}


public interface IVisitor
{
    void VisitElementA(ElementA element);
    void VisitElementB(ElementB element);
}


public class Visitor : IVisitor
{
    public void VisitElementA(ElementA element) =>
        Console.WriteLine($"Посетитель работает с: {element.OperationA()}");

    public void VisitElementB(ElementB element) =>
        Console.WriteLine($"Посетитель работает с: {element.OperationB()}");
}

var elements = new IElement[] { new ElementA(), new ElementB() };
var visitor = new Visitor();

foreach (var element in elements)
    element.Accept(visitor);
