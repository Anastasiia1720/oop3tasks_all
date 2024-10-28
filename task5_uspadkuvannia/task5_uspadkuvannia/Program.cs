

abstract class Shape
{
    public string Name { get; private set; }

    protected Shape(string name)
    {
        Name = name;
    }

    public abstract double Area();
    public abstract double Perimeter();
}

class Circle : Shape
{
    public double Radius { get; private set; }

    public Circle(double radius) : base("Коло")
    {
        Radius = radius;
    }

    public override double Area()
    {
        return Math.PI * Radius * Radius;
    }

    public override double Perimeter()
    {
        return 2 * Math.PI * Radius;
    }
}

class Square : Shape
{
    public double Side { get; private set; }

    public Square(double side) : base("Квадрат")
    {
        Side = side;
    }

    public override double Area()
    {
        return Side * Side;
    }

    public override double Perimeter()
    {
        return 4 * Side;
    }
}

class Program
{
    static void Main()
    {
        // Створення екземплярів з введенням даних вручну
        Console.Write("Введіть радіус для першого кола: ");
        double radius1 = Convert.ToDouble(Console.ReadLine());
        Circle circle1 = new Circle(radius1);

        Console.Write("Введіть радіус для другого кола: ");
        double radius2 = Convert.ToDouble(Console.ReadLine());
        Circle circle2 = new Circle(radius2);

        Console.Write("Введіть сторону для першого квадрата: ");
        double side1 = Convert.ToDouble(Console.ReadLine());
        Square square1 = new Square(side1);

        Console.Write("Введіть сторону для другого квадрата: ");
        double side2 = Convert.ToDouble(Console.ReadLine());
        Square square2 = new Square(side2);

        // Виведення інформації про фігури
        Shape[] shapes = { circle1, circle2, square1, square2 };

        foreach (var shape in shapes)
        {
            Console.WriteLine($"{shape.Name}: Площа = {shape.Area():F2}, Периметр = {shape.Perimeter():F2}");
        }

        // Знаходження найбільшого кола та квадрата за площею
        double maxCircleArea = Math.Max(circle1.Area(), circle2.Area());
        double maxSquareArea = Math.Max(square1.Area(), square2.Area());

        Console.WriteLine($"\nНайбільша площа серед кіл: {maxCircleArea:F2}");
        Console.WriteLine($"Найбільша площа серед квадратів: {maxSquareArea:F2}");
    }
}

