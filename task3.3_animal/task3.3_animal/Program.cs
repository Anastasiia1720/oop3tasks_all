

// Абстрактний клас Animal
public abstract class Animal
{
    // Автовластивості для ваги та кольору
    public float Weight { get; set; }
    public string Color { get; set; }

    // Конструктор, що приймає колір та вагу
    public Animal(string color, float weight)
    {
        Color = color;
        Weight = weight;
    }

    // Абстрактний метод для створення звуку
    public abstract string MakeSound();
}

// Абстрактний клас AnimalWithTail, що успадковує Animal
public abstract class AnimalWithTail : Animal
{
    // Автовластивість для довжини хвоста
    public float TailLength { get; set; }

    // Конструктор, що приймає колір, вагу та довжину хвоста, викликає конструктор базового класу
    public AnimalWithTail(string color, float weight, float tailLength) : base(color, weight)
    {
        TailLength = tailLength;
    }
}

// Клас Cat, що успадковує AnimalWithTail
public class Cat : AnimalWithTail
{
    // Конструктор, що приймає колір, вагу та довжину хвоста, викликає конструктор базового класу
    public Cat(string color, float weight, float tailLength) : base(color, weight, tailLength) { }

    // Приватний метод для муркотіння
    private string Purr()
    {
        return "purrrrrrrr";
    }

    // Приватний метод для нявкання
    private string Meow()
    {
        return "Meow";
    }

    // Перевизначення методу MakeSound для кота
    public override string MakeSound()
    {
        return Purr() + " " + Meow();
    }

    // Перевизначення методу ToString
    public override string ToString()
    {
        return $"Це кіт, Колір = {Color}, Вага = {Weight}, Довжина хвоста = {TailLength}";
    }
}

// Клас Dog, що успадковує AnimalWithTail
public class Dog : AnimalWithTail
{
    // Конструктор, що приймає колір, вагу та довжину хвоста, викликає конструктор базового класу
    public Dog(string color, float weight, float tailLength) : base(color, weight, tailLength) { }

    // Перевизначення методу MakeSound для собаки
    public override string MakeSound()
    {
        return "Woof";
    }

    // Перевизначення методу ToString
    public override string ToString()
    {
        return $"Це собака, Колір = {Color}, Вага = {Weight}, Довжина хвоста = {TailLength}";
    }
}

class Program
{
    static void Main()
    {
        // Введення даних для створення об'єкта Cat
        Console.WriteLine("Створення об'єкта Cat:");
        Console.Write("Введіть колір кота: ");
        string catColor = Console.ReadLine();

        Console.Write("Введіть вагу кота (наприклад, 4.5): ");
        float catWeight;
        while (!float.TryParse(Console.ReadLine(), out catWeight) || catWeight <= 0)
        {
            Console.Write("Неправильне значення. Введіть додатнє число для ваги кота: ");
        }

        Console.Write("Введіть довжину хвоста кота (наприклад, 30): ");
        float catTailLength;
        while (!float.TryParse(Console.ReadLine(), out catTailLength) || catTailLength <= 0)
        {
            Console.Write("Неправильне значення. Введіть додатнє число для довжини хвоста кота: ");
        }

        Cat cat = new Cat(catColor, catWeight, catTailLength);
        Console.WriteLine("\n" + cat.ToString());
        Console.WriteLine("Звук кота: " + cat.MakeSound());

        // Введення даних для створення об'єкта Dog
        Console.WriteLine("\nСтворення об'єкта Dog:");
        Console.Write("Введіть колір собаки: ");
        string dogColor = Console.ReadLine();

        Console.Write("Введіть вагу собаки (наприклад, 10.2): ");
        float dogWeight;
        while (!float.TryParse(Console.ReadLine(), out dogWeight) || dogWeight <= 0)
        {
            Console.Write("Неправильне значення. Введіть додатнє число для ваги собаки: ");
        }

        Console.Write("Введіть довжину хвоста собаки (наприклад, 40): ");
        float dogTailLength;
        while (!float.TryParse(Console.ReadLine(), out dogTailLength) || dogTailLength <= 0)
        {
            Console.Write("Неправильне значення. Введіть додатнє число для довжини хвоста собаки: ");
        }

        Dog dog = new Dog(dogColor, dogWeight, dogTailLength);
        Console.WriteLine("\n" + dog.ToString());
        Console.WriteLine("Звук собаки: " + dog.MakeSound());
    }
}

