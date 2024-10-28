
// Інтерфейс для виведення інформації про об'єкт
interface IPrintable
{
    void Print();
}

// Інтерфейс для управління статусом доступності книги
interface IBorrowable
{
    void BorrowItem();      // Позначає книгу як взяту
    void ReturnItem();      // Позначає книгу як повернену
    bool IsAvailable();     // Перевіряє, чи доступна книга
}

// Клас книги, що реалізує інтерфейси IPrintable та IBorrowable
class Book : IPrintable, IBorrowable
{
    public string Title { get; private set; }
    public string Author { get; private set; }
    public int PublicationYear { get; private set; }
    private bool isBorrowed;

    public Book(string title, string author, int publicationYear)
    {
        Title = title;
        Author = author;
        PublicationYear = publicationYear;
        isBorrowed = false; // За замовчуванням книга доступна
    }

    public void Print()
    {
        Console.WriteLine($"Назва: {Title}, Автор: {Author}, Рік видання: {PublicationYear}");
        Console.WriteLine(IsAvailable() ? "Статус: Доступна" : "Статус: Недоступна");
    }

    public void BorrowItem()
    {
        if (IsAvailable())
        {
            isBorrowed = true;
            Console.WriteLine($"Книга '{Title}' позичена.");
        }
        else
        {
            Console.WriteLine($"Книга '{Title}' вже недоступна.");
        }
    }

    public void ReturnItem()
    {
        if (!IsAvailable())
        {
            isBorrowed = false;
            Console.WriteLine($"Книга '{Title}' повернута до бібліотеки.");
        }
        else
        {
            Console.WriteLine($"Книга '{Title}' вже знаходиться в бібліотеці.");
        }
    }

    public bool IsAvailable()
    {
        return !isBorrowed;
    }
}

class Program
{
    static void Main()
    {
        // Створення книг з введенням даних вручну
        Console.Write("Введіть назву першої книги: ");
        string title1 = Console.ReadLine();
        Console.Write("Введіть автора першої книги: ");
        string author1 = Console.ReadLine();
        Console.Write("Введіть рік видання першої книги: ");
        int year1 = int.Parse(Console.ReadLine());
        Book book1 = new Book(title1, author1, year1);

        Console.Write("Введіть назву другої книги: ");
        string title2 = Console.ReadLine();
        Console.Write("Введіть автора другої книги: ");
        string author2 = Console.ReadLine();
        Console.Write("Введіть рік видання другої книги: ");
        int year2 = int.Parse(Console.ReadLine());
        Book book2 = new Book(title2, author2, year2);

        // Використання методів для книг
        Console.WriteLine("\nІнформація про книги:");
        book1.Print();
        book2.Print();

        Console.WriteLine("\nПозичення першої книги:");
        book1.BorrowItem();
        book1.Print();

        Console.WriteLine("\nСпроба позичити першу книгу знову:");
        book1.BorrowItem();

        Console.WriteLine("\nПовернення першої книги:");
        book1.ReturnItem();
        book1.Print();

        Console.WriteLine("\nПозичення другої книги:");
        book2.BorrowItem();
        book2.Print();
    }
}
