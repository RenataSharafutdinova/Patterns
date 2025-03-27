
public interface IRenderer
{
    void RenderCircle(float radius);
    void RenderSquare(float side);
}

public class VectorRenderer : IRenderer
{
    public void RenderCircle(float radius)
    {
        Console.WriteLine($"Отрисовка круга радиусом {radius} в векторном формате");
    }

    public void RenderSquare(float side)
    {
        Console.WriteLine($"Отрисовка квадрата со стороной {side} в векторном формате");
    }
}

public class RasterRenderer : IRenderer
{
    public void RenderCircle(float radius)
    {
        Console.WriteLine($"Отрисовка круга радиусом {radius} в растровом формате (пиксели)");
    }

    public void RenderSquare(float side)
    {
        Console.WriteLine($"Отрисовка квадрата со стороной {side} в растровом формате (пиксели)");
    }
}


public abstract class Shape
{
    protected IRenderer renderer;
    
    protected Shape(IRenderer renderer)
    {
        this.renderer = renderer;
    }
    
    public abstract void Draw();
    public abstract void Resize(float factor);
}

public class Circle : Shape
{
    private float radius;
    
    public Circle(IRenderer renderer, float radius) : base(renderer)
    {
        this.radius = radius;
    }
    
    public override void Draw()
    {
        renderer.RenderCircle(radius);
    }
    
    public override void Resize(float factor)
    {
        radius *= factor;
        Console.WriteLine($"Круг масштабирован. Новый радиус: {radius}");
    }
}

public class Square : Shape
{
    private float side;
    
    public Square(IRenderer renderer, float side) : base(renderer)
    {
        this.side = side;
    }
    
    public override void Draw()
    {
        renderer.RenderSquare(side);
    }
    
    public override void Resize(float factor)
    {
        side *= factor;
        Console.WriteLine($"Квадрат масштабирован. Новая сторона: {side}");
    }
}


class Program
{
    static void Main()
    {
        

        IRenderer vectorRenderer = new VectorRenderer();
        Shape circle = new Circle(vectorRenderer, 5);
        circle.Draw();
        circle.Resize(2);
        
 
        IRenderer rasterRenderer = new RasterRenderer();
        Shape square = new Square(rasterRenderer, 10);
        square.Draw();
        square.Resize(0.5f);
    }
}
