

// Клас для представлення товару
class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Product(string name, decimal price)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Назва товару не може бути порожньою.");
        if (price < 0)
            throw new ArgumentException("Ціна не може бути від'ємною.");

        Name = name;
        Price = price;
    }
}

// Клас для представлення замовлення
class Order
{
    public int OrderNumber { get; set; }
    public List<Product> Products { get; set; } = new List<Product>();
    public decimal TotalAmount { get; private set; }
    public string Status { get; private set; }

    // Делегат для обробки зміни статусу
    public delegate void StatusChangedHandler(string status);
    public event StatusChangedHandler OnStatusChanged;

    public Order(int orderNumber)
    {
        OrderNumber = orderNumber;
        Status = "Новий";
    }

    // Метод для обчислення загальної вартості замовлення
    public void CalculateTotalAmount()
    {
        TotalAmount = 0;
        foreach (var product in Products)
        {
            TotalAmount += product.Price;
        }
    }

    // Метод для оновлення статусу замовлення
    public void UpdateStatus(string newStatus)
    {
        Status = newStatus;
        OnStatusChanged?.Invoke(Status);  // Викликає делегат при зміні статусу
    }
}

// Клас для обробки замовлення
class OrderProcessor
{
    public void ProcessOrder(Order order)
    {
        // Обробка замовлення (розрахунок загальної вартості)
        order.CalculateTotalAmount();
        Console.WriteLine($"Замовлення #{order.OrderNumber} оброблено. Загальна вартість: {order.TotalAmount} грн.");

        // Зміна статусу на "Готове до відправлення"
        order.UpdateStatus("Готове до відправлення");
    }
}

// Клас для відправки сповіщень
class NotificationService
{
    public void SendNotification(string status)
    {
        Console.WriteLine($"[Сповіщення] Статус замовлення змінено: {status}");
    }
}

// Головний клас програми
class Program
{
    static void Main()
    {
        try
        {
            // Створення замовлення
            Console.Write("Введіть номер замовлення: ");
            int orderNumber = int.Parse(Console.ReadLine());
            var order = new Order(orderNumber);

            // Додавання товарів до замовлення
            while (true)
            {
                Console.Write("Введіть назву товару (або 'вихід' для завершення): ");
                string productName = Console.ReadLine();
                if (productName.ToLower() == "вихід")
                    break;

                decimal productPrice;
                Console.Write("Введіть ціну товару: ");
                while (!decimal.TryParse(Console.ReadLine(), out productPrice) || productPrice < 0)
                {
                    Console.WriteLine("Ціна повинна бути невід'ємним числом. Спробуйте ще раз.");
                }

                // Додаємо товар до списку замовлення
                order.Products.Add(new Product(productName, productPrice));
            }

            // Створення NotificationService та підписка на подію зміни статусу замовлення
            var notificationService = new NotificationService();
            order.OnStatusChanged += notificationService.SendNotification;

            // Обробка замовлення
            var processor = new OrderProcessor();
            processor.ProcessOrder(order);

            // Виведення інформації про статус замовлення
            Console.WriteLine($"Фінальний статус замовлення #{order.OrderNumber}: {order.Status}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Помилка: введіть коректні числові значення.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Помилка: " + ex.Message);
        }
    }
}
