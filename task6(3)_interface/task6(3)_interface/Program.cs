

// Інтерфейс для виведення інформації про продукт
interface IProduct
{
    void DisplayInfo();
}

// Інтерфейс для додавання продукту до кошика
interface IShoppable
{
    void AddToCart();
}

// Базовий клас ElectronicDevice, що реалізує інтерфейс IProduct
class ElectronicDevice : IProduct
{
    public string Name { get; private set; }
    public string Manufacturer { get; private set; }
    public decimal Price { get; private set; }

    public ElectronicDevice(string name, string manufacturer, decimal price)
    {
        Name = name;
        Manufacturer = manufacturer;
        Price = price;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Назва: {Name}, Виробник: {Manufacturer}, Ціна: {Price} грн");
    }
}

// Клас Smartphone, що успадковує ElectronicDevice та реалізує IShoppable
class Smartphone : ElectronicDevice, IShoppable
{
    public string OperatingSystem { get; private set; }
    public int StorageCapacity { get; private set; } // у ГБ

    public Smartphone(string name, string manufacturer, decimal price, string operatingSystem, int storageCapacity)
        : base(name, manufacturer, price)
    {
        OperatingSystem = operatingSystem;
        StorageCapacity = storageCapacity;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Операційна система: {OperatingSystem}, Пам'ять: {StorageCapacity} ГБ");
    }

    public void AddToCart()
    {
        Console.WriteLine($"Смартфон '{Name}' додано до кошика.");
    }
}

// Клас Laptop, що успадковує ElectronicDevice та реалізує IShoppable
class Laptop : ElectronicDevice, IShoppable
{
    public string Processor { get; private set; }
    public int RAM { get; private set; } // у ГБ

    public Laptop(string name, string manufacturer, decimal price, string processor, int ram)
        : base(name, manufacturer, price)
    {
        Processor = processor;
        RAM = ram;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Процесор: {Processor}, Оперативна пам'ять: {RAM} ГБ");
    }

    public void AddToCart()
    {
        Console.WriteLine($"Ноутбук '{Name}' додано до кошика.");
    }
}

class Program
{
    static void Main()
    {
        // Введення даних для смартфона вручну
        Console.Write("Введіть назву смартфона: ");
        string smartphoneName = Console.ReadLine();
        Console.Write("Введіть виробника смартфона: ");
        string smartphoneManufacturer = Console.ReadLine();
        Console.Write("Введіть ціну смартфона: ");
        decimal smartphonePrice = decimal.Parse(Console.ReadLine());
        Console.Write("Введіть операційну систему смартфона: ");
        string smartphoneOS = Console.ReadLine();
        Console.Write("Введіть обсяг пам'яті смартфона (у ГБ): ");
        int smartphoneStorage = int.Parse(Console.ReadLine());

        Smartphone smartphone = new Smartphone(smartphoneName, smartphoneManufacturer, smartphonePrice, smartphoneOS, smartphoneStorage);

        // Введення даних для ноутбука вручну
        Console.Write("\nВведіть назву ноутбука: ");
        string laptopName = Console.ReadLine();
        Console.Write("Введіть виробника ноутбука: ");
        string laptopManufacturer = Console.ReadLine();
        Console.Write("Введіть ціну ноутбука: ");
        decimal laptopPrice = decimal.Parse(Console.ReadLine());
        Console.Write("Введіть процесор ноутбука: ");
        string laptopProcessor = Console.ReadLine();
        Console.Write("Введіть обсяг оперативної пам'яті ноутбука (у ГБ): ");
        int laptopRAM = int.Parse(Console.ReadLine());

        Laptop laptop = new Laptop(laptopName, laptopManufacturer, laptopPrice, laptopProcessor, laptopRAM);

        // Виведення інформації про продукти та додавання їх до кошика
        Console.WriteLine("\nІнформація про смартфон:");
        smartphone.DisplayInfo();
        smartphone.AddToCart();

        Console.WriteLine("\nІнформація про ноутбук:");
        laptop.DisplayInfo();
        laptop.AddToCart();
    }
}

