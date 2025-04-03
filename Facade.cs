
public class SubsystemA
{
    public void OperationA() => Console.WriteLine("SubsystemA: OperationA");
}

public class SubsystemB
{
    public void OperationB() => Console.WriteLine("SubsystemB: OperationB");
}

public class SubsystemC
{
    public void OperationC() => Console.WriteLine("SubsystemC: OperationC");
}


public class Facade
{
    private SubsystemA _a = new SubsystemA();
    private SubsystemB _b = new SubsystemB();
    private SubsystemC _c = new SubsystemC();

    public void Operation1()
    {
        _a.OperationA();
        _b.OperationB();
    }

    public void Operation2()
    {
        _b.OperationB();
        _c.OperationC();
    }
}

var facade = new Facade();
facade.Operation1(); 
facade.Operation2(); 
