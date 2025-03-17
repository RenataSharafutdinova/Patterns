interface ICar
{
    ICar Clone();
    void GetInfo();
}
class HondaCar1:ICar
{
    public int Id {  get; set; }
    public string Color { get; set; }
    public string Name = "Honda";
    public HondaCar1(int id, string color)
    {
        Id = id;
        Color = color;
    }
    public ICar Clone()
    {
        return new HondaCar1(Id, Color);
    }
    public void GetInfo()
    {
        Console.WriteLine($"Created {Name} car with {Color}. Id = {Id}");
    }
}
class ToyotaCar1:ICar
{
    public int Id { get; set; }
    public string Color { get; set; }
    public string Name = "Toyota";

    public ToyotaCar1(int id, string color)
    {
        Id = id;
        Color = color;
    }

    public ICar Clone()
    {
        return new ToyotaCar1(Id, Color);
    }
    public void GetInfo()
    {
        Console.WriteLine($"Created {Name} car with {Color}. Id = {Id}");
    }
}
class Program
{
    static void Main(string[] args)
    {
        ICar carH = new HondaCar1(1, "Blue");
        carH.GetInfo();

        ICar cloneCarH = carH.Clone();
        cloneCarH.GetInfo();

        ICar carT = new ToyotaCar1(2, "Red");
        carT.GetInfo();

        ICar cloneCarT= carT.Clone();
        cloneCarT.GetInfo();
    }
}
