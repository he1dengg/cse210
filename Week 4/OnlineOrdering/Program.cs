using System;
using System.Collections.Generic;
using System.Text;

public class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }

    public bool IsInUSA()
    {
        return _country.ToLower() == "usa" || _country.ToLower() == "united states";
    }

    public string GetFullAddress()
    {
        return $"{_street}\n{_city}, {_state}\n{_country}";
    }
}

public class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public bool LivesInUSA()
    {
        return _address.IsInUSA();
    }

    public string GetName()
    {
        return _name;
    }

    public Address GetAddress()
    {
        return _address;
    }
}

public class Product
{
    private string _name;
    private string _productId;
    private double _price;
    private int _quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public double GetTotalCost()
    {
        return _price * _quantity;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetProductId()
    {
        return _productId;
    }
}

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double CalculateTotalPrice()
    {
        double total = 0;
        foreach (var product in _products)
        {
            total += product.GetTotalCost();
        }

        double shippingCost = _customer.LivesInUSA() ? 5.0 : 35.0;
        return total + shippingCost;
    }

    public string GetPackingLabel()
    {
        StringBuilder label = new StringBuilder();
        label.AppendLine("Packing Label:");
        foreach (var product in _products)
        {
            label.AppendLine($"- {product.GetName()} (ID: {product.GetProductId()})");
        }
        return label.ToString();
    }

    public string GetShippingLabel()
    {
        StringBuilder label = new StringBuilder();
        label.AppendLine("Shipping Label:");
        label.AppendLine(_customer.GetName());
        label.AppendLine(_customer.GetAddress().GetFullAddress());
        return label.ToString();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Rexburg", "ID", "USA");
        Customer customer1 = new Customer("John Doe", address1);
        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Laptop", "LPT-001", 899.99, 1));
        order1.AddProduct(new Product("Wireless Mouse", "MS-002", 25.50, 2));

        Address address2 = new Address("456 Maple Dr", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Jane Smith", address2);
        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Mechanical Keyboard", "KB-003", 45.00, 1));
        order2.AddProduct(new Product("Monitor", "MN-004", 150.00, 2));
        order2.AddProduct(new Product("HDMI Cable", "CBL-005", 10.00, 3));

        Console.WriteLine("========================================");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.CalculateTotalPrice():0.00}");

        Console.WriteLine("\n========================================");

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.CalculateTotalPrice():0.00}");
        Console.WriteLine("========================================");
    }
}