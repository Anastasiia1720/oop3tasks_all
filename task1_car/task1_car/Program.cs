````````````````````````````````````````````````````//

public class Car
{
    // Поля
    public string Name { get; set; }
    public string Color { get; set; }
    public double Price { get; set; }
    public const string CompanyName = "AutoCorp"; // Константа

    // Дефолтный конструктор
    public Car()
    {
        Name = "Unknown";
        Color = "Unknown";
        Price = 0.0;
    }

    // Конструктор с параметрами
    public Car(string name, string color, double price)
    {
        Name = name;
        Color = color;
        Price = price;
    }

    // Метод для ввода данных о машине
    public void Input()
    {
        Console.Write("Введите название автомобиля: ");
        Name = Console.ReadLine();

        Console.Write("Введите цвет автомобиля: ");
        Color = Console.ReadLine();

        Console.Write("Введите цену автомобиля: ");
        Price = Convert.ToDouble(Console.ReadLine());
    }

    // Метод для вывода данных о машине
    public void Print()
    {
        Console.WriteLine($"Название: {Name}, Цвет: {Color}, Цена: {Price}, Компания: {CompanyName}");
    }

    // Метод для изменения цены на x%
    public void ChangePrice(double x)
    {
        Price -= Price * (x / 100.0);
    }

    // Метод для получения информации о машине в виде строки
    public string PrintInfo()
    {
        return $"Название: {Name}, Цвет: {Color}, Цена: {Price}, Компания: {CompanyName}";
    }
}

class Program
{
    static void Main()
    {
        // Ввод данных о трех автомобилях
        Car[] cars = new Car[3];
        for (int i = 0; i < 3; i++)
        {
            cars[i] = new Car();
            Console.WriteLine($"\nВведите данные о машине {i + 1}:");
            cars[i].Input();
        }

        // Уменьшение цены на 10% и вывод данных о машинах
        Console.WriteLine("\nИнформация об автомобилях после уменьшения цены на 10%:");
        foreach (var car in cars)
        {
            car.ChangePrice(10); // уменьшить цену на 10%
            car.Print();
        }

        // Изменение цвета машин с белым цветом
        Console.Write("\nВведите новый цвет для автомобилей с белым цветом: ");
        string newColor = Console.ReadLine();
        foreach (var car in cars)
        {
            if (car.Color.ToLower() == "white")
            {
                car.Color = newColor;
            }
        }

        // Вывод окончательной информации о машинах
        Console.WriteLine("\nОкончательная информация об автомобилях:");
        foreach (var car in cars)
        {
            Console.WriteLine(car.PrintInfo());
        }
    }
}
