using System;

class Program
{
    static void Main()
    {
        Address address = new Address("123 Main St", "Rexburg", "ID", "USA");
        Customer customer = new Customer("Jane Smith", address);

        Product product1 = new Product("Notebook", "P001", 3.50, 2);
        Product product2 = new Product("Pen", "P002", 1.25, 5);

        Order order = new Order(customer);
        order.AddProduct(product1);
        order.AddProduct(product2);

        Console.WriteLine("Packing Label:");
        Console.WriteLine(order.GetPackingLabel());

        Console.WriteLine("\nShipping Label:");
        Console.WriteLine(order.GetShippingLabel());

        Console.WriteLine($"\nTotal Cost: ${order.GetTotalCost():0.00}");
    }
}
