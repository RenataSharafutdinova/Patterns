class Computer
{
    public string Processor { get; set; }
    public string RAM { get; set; }
    public string HardDrive { get; set; }
    public string GraphicsCard { get; set; }

    public void Display()
    {
        Console.WriteLine($"Processor: {Processor}");
        Console.WriteLine($"RAM: {RAM}");
        Console.WriteLine($"HardDrive: {HardDrive}");
        Console.WriteLine($"GraphicsCard: {GraphicsCard}");
    }

}
interface IComputerBuilder
{
    void SetProcessor(string processor);
    void SetRAM(string ram);
    void SetHardDrive(string hardDrive);
    void SetGraphicsCard(string graphicsCard);
    Computer GetComputer();
}
class ComputerBuilder: IComputerBuilder
{
    private Computer _computer=new Computer();
    public void SetProcessor(string processor)
    {
        _computer.Processor = processor;
    }
    public void SetRAM( string ram)
    {
        _computer.RAM = ram;
    }
    public void SetHardDrive( string hardDrive)
    {
        _computer.HardDrive = hardDrive;
    }
    public void SetGraphicsCard( string graphicsCard)
    {
        _computer.GraphicsCard = graphicsCard;
    }
    public Computer GetComputer()
    {
        return _computer;
    }
}
class Director
{
    private IComputerBuilder _builder;

    public Director(IComputerBuilder builder)
    {
        _builder = builder;
    }

    public void BuildGamingComputer()
    {
        _builder.SetProcessor("Intel Core i9");
        _builder.SetRAM("32GB");
        _builder.SetHardDrive("1TB SSD");
        _builder.SetGraphicsCard("NVIDIA RTX 3080");
    }

    public void BuildOfficeComputer()
    {
        _builder.SetProcessor("Intel Core i5");
        _builder.SetRAM("16GB");
        _builder.SetHardDrive("512GB SSD");
        _builder.SetGraphicsCard("Integrated");
    }
}
//class Program
//{
//    static void Main(string[] args)
//    {
//        IComputerBuilder builder = new ComputerBuilder();

//        Director director = new Director(builder);
//        director.BuildGamingComputer();
//        Computer gamingComputer = builder.GetComputer();
//        gamingComputer.Display();
//    }
//}
