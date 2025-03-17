abstract class Car {
    public abstract void Drive();

}
abstract class Motorcycle {
    public abstract void Ride();
}
class ToyotaCar: Car {
    public override void Drive()
    {
        Console.WriteLine("Driving a Toyota car");
    }
}
class HondaCar : Car {
    public override void Drive()
    {
        Console.WriteLine("Driving a Honda car");
    }
}
class ToyotaMotorcycle : Motorcycle
{
    public override void Ride()
    {
        Console.WriteLine("Riding a Toyota motorcycle");
    }
}
class HondaMotorcycle : Motorcycle {
    public override void Ride()
    {
        Console.WriteLine("Riding a Honda motorcycle");
    }
}

abstract class VehicleFactory
{
    public abstract Car CreateCar();
    public abstract Motorcycle CreateMotorcycle();
}
class ToyotaFactory: VehicleFactory
{
    public override Car CreateCar()
    {
        return new ToyotaCar();
    }
    public override Motorcycle CreateMotorcycle()
    {
        return new ToyotaMotorcycle();
    }

}
class HondaFactory : VehicleFactory
{
    public override Car CreateCar()
    {
        return new HondaCar();
    }
    public override Motorcycle CreateMotorcycle()
    {
        return new HondaMotorcycle();
    }
}

class Progrm
{
    //static void Main(string[] args)
    //{
    //    VehicleFactory toyotaFactory = new ToyotaFactory();
    //    VehicleFactory hondaFactory = new HondaFactory();

    //    Car toyotaCar = toyotaFactory.CreateCar();
    //    Motorcycle toyotaMotorcycle = toyotaFactory.CreateMotorcycle();

    //    Car hondaCar = hondaFactory.CreateCar();
    //    Motorcycle hondaMotorcycle = hondaFactory.CreateMotorcycle();

    //    toyotaCar.Drive();
    //    hondaCar.Drive();

    //    toyotaMotorcycle.Ride();
    //    hondaMotorcycle.Ride();
    //}
}
