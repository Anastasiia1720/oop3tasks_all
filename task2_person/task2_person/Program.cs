

public class Person
{
    // Приватные поля
    private string name;
    private DateTime birthYear;

    // Свойства для доступа к полям (только get)
    public string Name => name;
    public DateTime BirthYear => birthYear;

    // Конструктор по умолчанию
    public Person()
    {
        name = "Unknown";
        birthYear = DateTime.Now;
    }

    // Конструктор с параметрами
    public Person(string name, DateTime birthYear)
    {
        this.name = name;
        this.birthYear = birthYear;
    }

    // Метод для вычисления возраста
    public int Age()
    {
        int age = DateTime.Now.Year - birthYear.Year;
        if (DateTime.Now.DayOfYear < birthYear.DayOfYear)
        {
            age--;
        }
        return age;
    }

    // Метод для изменения имени
    public void ChangeName(string newName)
    {
        name = newName;
    }

    // Метод ToString для получения строки с данными об объекте
    public override string ToString()
    {
        return $"Имя: {name}, Год рождения: {birthYear.Year}, Возраст: {Age()}";
    }

    // Метод для вывода информации об объекте
    public void Output()
    {
        Console.WriteLine(ToString());
    }

    // Переопределение оператора равенства для сравнения по имени
    public static bool operator ==(Person p1, Person p2)
    {
        return p1?.name == p2?.name;
    }

    public static bool operator !=(Person p1, Person p2)
    {
        return !(p1 == p2);
    }

    // Переопределение методов Equals и GetHashCode (рекомендуется при перегрузке ==)
    public override bool Equals(object obj)
    {
        if (obj is Person otherPerson)
        {
            return this == otherPerson;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return name.GetHashCode();
    }

    // Метод для ввода данных с консоли
    public void Input()
    {
        Console.Write("Введите имя: ");
        name = Console.ReadLine();

        Console.Write("Введите год рождения (в формате ГГГГ-ММ-ДД): ");
        while (!DateTime.TryParse(Console.ReadLine(), out birthYear))
        {
            Console.WriteLine("Неверный формат. Попробуйте снова (ГГГГ-ММ-ДД): ");
        }
    }
}

class Program
{
    static void Main()
    {
        // Создание массива из 6 объектов Person
        Person[] persons = new Person[6];

        // Ввод информации о каждом человеке
        for (int i = 0; i < 6; i++)
        {
            Console.WriteLine($"\nВведите данные для человека {i + 1}:");
            persons[i] = new Person();
            persons[i].Input();
        }

        // Вычисление возраста и вывод имени и возраста каждого человека
        Console.WriteLine("\nВозраст каждой персоны:");
        foreach (var person in persons)
        {
            Console.WriteLine($"Имя: {person.Name}, Возраст: {person.Age()}");
        }

        // Изменение имени на "Very Young" для лиц младше 16 лет
        foreach (var person in persons)
        {
            if (person.Age() < 16)
            {
                person.ChangeName("Very Young");
            }
        }

        // Вывод информации о всех объектах
        Console.WriteLine("\nИнформация о всех персонажах после изменений:");
        foreach (var person in persons)
        {
            person.Output();
        }

        // Поиск и вывод информации о людях с одинаковыми именами
        Console.WriteLine("\nЛюди с одинаковыми именами:");
        for (int i = 0; i < persons.Length; i++)
        {
            for (int j = i + 1; j < persons.Length; j++)
            {
                if (persons[i] == persons[j])
                {
                    Console.WriteLine($"Совпадают по имени: {persons[i].ToString()} и {persons[j].ToString()}");
                }
            }
        }
    }
}
