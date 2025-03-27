using System;
using System.Collections.Generic;

public class TreeType
{
    public string Name { get; }
    public string Color { get; }
    public string Texture { get; }

    public TreeType(string name, string color, string texture)
    {
        Name = name;
        Color = color;
        Texture = texture;
    }

    public void Draw(int x, int y)
    {
        Console.WriteLine($"Дерево типа '{Name}' (цвет: {Color}, текстура: {Texture}) нарисовано на координатах ({x}, {y})");
    }
}

public class TreeFactory
{
    private static Dictionary<string, TreeType> _treeTypes = new();

    public static TreeType GetTreeType(string name, string color, string texture)
    {
        string key = $"{name}_{color}_{texture}";
        if (!_treeTypes.ContainsKey(key))
        {
            _treeTypes[key] = new TreeType(name, color, texture);
            Console.WriteLine($"Создан новый тип дерева: {key}");
        }
        return _treeTypes[key];
    }
}

public class Tree
{
    private int _x, _y;
    private TreeType _type;

    public Tree(int x, int y, TreeType type)
    {
        _x = x;
        _y = y;
        _type = type;
    }

    public void Draw()
    {
        _type.Draw(_x, _y);
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("\n=== Паттерн 'Легковес' ===");
        
        var forest = new List<Tree>();
        
        forest.Add(new Tree(1, 2, TreeFactory.GetTreeType("Дуб", "Зеленый", "Кора1")));
        forest.Add(new Tree(3, 4, TreeFactory.GetTreeType("Сосна", "Темно-зеленый", "Кора2")));
        forest.Add(new Tree(5, 6, TreeFactory.GetTreeType("Дуб", "Зеленый", "Кора1"))); 
  
        foreach (var tree in forest)
        {
            tree.Draw();
        }
    }
}
