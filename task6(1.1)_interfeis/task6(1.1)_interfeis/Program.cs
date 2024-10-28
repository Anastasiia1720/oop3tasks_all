
// Інтерфейс IVehicle для транспортних засобів
interface IVehicle
{
    void Start(); // Запуск транспортного засобу
    void Stop();  // Зупинка транспортного засобу
    void Drive(); // Рух транспортного засобу
}

// Клас автомобіля Car
class Car : IVehicle
{
    public string Brand { get; set; }
    public int PassengerCapacity { get; set; }

    public Car(string brand, int passengerCapacity)
    {
        Brand = brand;
        PassengerCapacity = passengerCapacity;
    }

    public void Start()
    {
        Console.WriteLine($"{Brand} автомобіль запущено.");
    }

    public void Stop()
    {
        Console.WriteLine($"{Brand} автомобіль зупинено.");
    }

    public void Drive()
    {
        Console.WriteLine($"{Brand} автомобіль рухається, місткість: {PassengerCapacity} пасажирів.");
    }
}

// Клас мотоцикла Motorcycle
class Motorcycle : IVehicle
{
    public string Brand { get; set; }
    public bool HasSidecar { get; set; }

    public Motorcycle(string brand, bool hasSidecar)
    {
        Brand = brand;
        HasSidecar = hasSidecar;
    }

    public void Start()
    {
        Console.WriteLine($"{Brand} мотоцикл запущено.");
    }

    public void Stop()
    {
        Console.WriteLine($"{Brand} мотоцикл зупинено.");
    }

    public void Drive()
    {
        string sidecarInfo = HasSidecar ? "з коляскою" : "без коляски";
        Console.WriteLine($"{Brand} мотоцикл рухається ({sidecarInfo}).");
    }
}

// Клас вантажівки Truck
class Truck : IVehicle
{
    public string Brand { get; set; }
    public double LoadCapacity { get; set; }

    public Truck(string brand, double loadCapacity)
    {
        Brand = brand;
        LoadCapacity = loadCapacity;
    }

    public void Start()
    {
        Console.WriteLine($"{Brand} вантажівка запущена.");
    }

    public void Stop()
    {
        Console.WriteLine($"{Brand} вантажівка зупинена.");
    }

    public void Drive()
    {
        Console.WriteLine($"{Brand} вантажівка рухається з вантажопідйомністю {LoadCapacity} тонн.");
    }
}

class Program
{
    static void Main()
    {
        // Створення транспортних засобів з введенням даних вручну
        Console.Write("Введіть марку автомобіля: ");
        string carBrand = Console.ReadLine();
        Console.Write("Введіть місткість пасажирів для автомобіля: ");
        int carCapacity = int.Parse(Console.ReadLine());
        Car car = new Car(carBrand, carCapacity);

        Console.Write("Введіть марку мотоцикла: ");
        string motoBrand = Console.ReadLine();
        Console.Write("Чи є коляска у мотоцикла? (true/false): ");
        bool hasSidecar = bool.Parse(Console.ReadLine());
        Motorcycle motorcycle = new Motorcycle(motoBrand, hasSidecar);

        Console.Write("Введіть марку вантажівки: ");
        string truckBrand = Console.ReadLine();
        Console.Write("Введіть вантажопідйомність вантажівки (в тоннах): ");
        double loadCapacity = double.Parse(Console.ReadLine());
        Truck truck = new Truck(truckBrand, loadCapacity);

        // Запуск методів для кожного транспортного засобу
        Console.WriteLine("\nКерування автопарком:\n");

        car.Start();
        car.Drive();
        car.Stop();

        motorcycle.Start();
        motorcycle.Drive();
        motorcycle.Stop();

        truck.Start();
        truck.Drive();
        truck.Stop();
    }
}

