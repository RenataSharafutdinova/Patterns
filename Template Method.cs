
public abstract class BeverageMaker
{

    public void PrepareBeverage()
    {
        BoilWater();
        Brew();
        PourInCup();
        if (CustomerWantsCondiments())
        {
            AddCondiments();
        }
        Console.WriteLine("Напиток готов!\n");
    }

  
    private void BoilWater()
    {
        Console.WriteLine("Кипятим воду");
    }

    private void PourInCup()
    {
        Console.WriteLine("Наливаем в чашку");
    }


    protected abstract void Brew();
    protected abstract void AddCondiments();


    protected virtual bool CustomerWantsCondiments()
    {
        return true;
    }
}


public class CoffeeMaker : BeverageMaker
{
    protected override void Brew()
    {
        Console.WriteLine("Завариваем кофе");
    }

    protected override void AddCondiments()
    {
        Console.WriteLine("Добавляем сахар и молоко");
    }

    protected override bool CustomerWantsCondiments()
    {
        Console.Write("Хотите добавить сахар и молоко в кофе? (y/n): ");
        string input = Console.ReadLine();
        return input.ToLower() == "y";
    }
}

public class TeaMaker : BeverageMaker
{
    protected override void Brew()
    {
        Console.WriteLine("Завариваем чайные листья");
    }

    protected override void AddCondiments()
    {
        Console.WriteLine("Добавляем лимон");
    }
}

public class HerbalTeaMaker : BeverageMaker
{
    protected override void Brew()
    {
        Console.WriteLine("Завариваем травяной сбор");
    }

    protected override void AddCondiments()
    {
        Console.WriteLine("Добавляем мед");
    }

    protected override bool CustomerWantsCondiments()
    {
        Console.Write("Хотите добавить мед в травяной чай? (y/n): ");
        string input = Console.ReadLine();
        return input.ToLower() == "y";
    }
}

// Пример использования
class Program
{
    static void Main()
    {
     
        BeverageMaker coffeeMaker = new CoffeeMaker();
        coffeeMaker.PrepareBeverage();

     
        BeverageMaker teaMaker = new TeaMaker();
        teaMaker.PrepareBeverage();

      
        BeverageMaker herbalTeaMaker = new HerbalTeaMaker();
        herbalTeaMaker.PrepareBeverage();
    }
}
