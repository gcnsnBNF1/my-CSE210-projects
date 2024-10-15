using System;

class Program
{
    static void Main(string[] args)
    {
        List<Order> orders = new List<Order>();

        Address address1 = new Address("123 Longhorn Way", "Houston", "TX", "USA");
        Customer customer1 = new Customer("Allan Nelson", address1);
        List<Product> products1 = new List<Product>
        {
            new Product("MacBook Pro Laptop", 1, 1999.99, 1),
            new Product("Wireless Mouse", 2, 14.99, 2),
            new Product("E7 Bluetooth Headphones", 3, 69.99, 1)
        };
        orders.Add(new Order(products1, customer1));

        Address address2 = new Address("42 Wallaby Way", "Sydney", "NSW", "Australia");
        Customer customer2 = new Customer("Paula Sherman", address2);
        List<Product> products2 = new List<Product>
        {
            new Product("Alienware Aurora R16 PC", 4, 2699.99, 1),
            new Product("Cherry MX RGB Keyboard", 5, 85.99, 1),
            new Product("Wireless Mouse", 6, 14.99, 1),
            new Product("Amazon Basics Monitor", 7, 129.99, 3)
        };
        orders.Add(new Order(products2, customer2));

        for(int i = 0; i < orders.Count; i++)
        {
            Console.WriteLine($"Order {i + 1} Details:");
            PrintOrderDetails(orders[i]);
        }
    }

    static void PrintOrderDetails(Order order)
    {
        Console.WriteLine($"{order.GetPackingLabel()}\n{order.GetShippingLabel()}\nTotal Cost: ${order.CalculateTotalCost():0.00}\n");
    }
}