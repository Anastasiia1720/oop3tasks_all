

public abstract class Figure
{
    // Метод для вычисления площади (абстрактный)
    public abstract double CalculateArea();

    // Метод для вычисления периметра (абстрактный)
    public abstract double CalculatePerimeter();
}

public class Circle : Figure
{
    // Поле для радиуса круга
    public double Radius { get; set; }

    // Конструктор с параметром радиуса
    public Circle(double radius)
    {
        Radius = radius;
    }

    // Переопределение метода для вычисления площади круга
    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }

    // Переопределение метода для вычисления периметра круга
    public override double CalculatePerimeter()
    {
        return 2 * Math.PI * Radius;
    }
}

public class Rectangle : Figure
{
    // Поля для ширины и высоты прямоугольника
    public double Width { get; set; }
    public double Height { get; set; }

    // Конструктор с параметрами ширины и высоты
    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    // Переопределение метода для вычисления площади прямоугольника
    public override double CalculateArea()
    {
        return Width * Height;
    }

    // Переопределение метода для вычисления периметра прямоугольника
    public override double CalculatePerimeter()
    {
        return 2 * (Width + Height);
    }
}

class Program
{
    static void Main()
    {
        // Ввод данных для круга
        Console.Write("Введите радиус круга: ");
        double radius;
        while (!double.TryParse(Console.ReadLine(), out radius) || radius <= 0)
        {
            Console.WriteLine("Неверный ввод. Пожалуйста, введите положительное число.");
        }
        Circle circle = new Circle(radius);
        Console.WriteLine("\nКоло:");
        Console.WriteLine($"Радиус: {circle.Radius}");
        Console.WriteLine($"Площадь: {circle.CalculateArea()}");
        Console.WriteLine($"Периметр: {circle.CalculatePerimeter()}");

        // Ввод данных для прямоугольника
        Console.Write("\nВведите ширину прямоугольника: ");
        double width;
        while (!double.TryParse(Console.ReadLine(), out width) || width <= 0)
        {
            Console.WriteLine("Неверный ввод. Пожалуйста, введите положительное число.");
        }

        Console.Write("Введите высоту прямоугольника: ");
        double height;
        while (!double.TryParse(Console.ReadLine(), out height) || height <= 0)
        {
            Console.WriteLine("Неверный ввод. Пожалуйста, введите положительное число.");
        }
        Rectangle rectangle = new Rectangle(width, height);
        Console.WriteLine("\nПрямокутник:");
        Console.WriteLine($"Ширина: {rectangle.Width}, Высота: {rectangle.Height}");
        Console.WriteLine($"Площадь: {rectangle.CalculateArea()}");
        Console.WriteLine($"Периметр: {rectangle.CalculatePerimeter()}");
    }
}

