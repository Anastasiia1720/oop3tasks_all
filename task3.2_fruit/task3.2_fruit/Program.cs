class Fruit
{
    public string Name { get; set; }

    public Fruit(string name)
    {
        Name = name;
    }
}

class Apple : Fruit
{
    public string Variety { get; set; }
    public string Color { get; set; }

    public Apple(string name, string variety, string color) : base(name)
    {
        Variety = variety;
        Color = color;
    }
}

class Pear : Fruit
{
    public string Color { get; set; }

    public Pear(string name, string color) : base(name)
    {
        Color = color;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введіть назву яблука: ");
        string appleName = Console.ReadLine();
        Console.Write("Введіть сорт яблука: ");
        string appleVariety = Console.ReadLine();
        Console.Write("Введіть колір яблука: ");
        string appleColor = Console.ReadLine();
        Apple apple = new Apple(appleName, appleVariety, appleColor);

        Console.Write("Введіть назву груші: ");
        string pearName = Console.ReadLine();
        Console.Write("Введіть колір груші: ");
        string pearColor = Console.ReadLine();
        Pear pear = new Pear(pearName, pearColor);

        Console.WriteLine($"Фрукт: {apple.Name}, Сорт: {apple.Variety}, Колір: {apple.Color}");
        Console.WriteLine($"Фрукт: {pear.Name}, Колір: {pear.Color}");
    }
}
