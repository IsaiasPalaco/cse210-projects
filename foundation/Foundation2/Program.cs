using System;

class Program
{
    static void Main(string[] args)
    {
        Customer customer1 = new Customer("John Doe", new Address("123 Main St", "Springfield", "IL", "USA"));
        Customer customer2 = new Customer("Jane Smith", new Address("456 Elm St", "Toronto", "ON", "Canada"));

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "LPT123", 800m, 1));
        order1.AddProduct(new Product("Mouse", "MSE456", 20m, 2));

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Desk", "DSK789", 200m, 1));
        order2.AddProduct(new Product("Chair", "CHR101", 150m, 1));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.CalculateTotalCost()}\n");

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.CalculateTotalCost()}\n");
    }
}