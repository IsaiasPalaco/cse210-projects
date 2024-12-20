using System;

class Program
{
    static void Main(string[] args)
    {
        Customer customer1 = new Customer("Isaiah Palaco", new Address("1 de Maio", "Dondo", "Sofala", "MZ"));
        Customer customer2 = new Customer("Ana Palaco", new Address("25 de Setembro", "Moatize", "Tete", "Mozambique"));

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "LPT045", 800m, 1));
        order1.AddProduct(new Product("Mouse", "MSE475", 20m, 2));

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