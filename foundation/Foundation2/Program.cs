using System;
using System.Collections.Generic;

// Define the Product class
public class Product
{
    // Private member variables for encapsulation (information hiding)
    private string _name;
    private string _productId;
    private double _price;
    private int _quantity;

    // Constructor to initialize product attributes
    public Product(string name, string productId, double price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    // Method to calculate the total cost of the product
    public double GetTotalCost()
    {
        return _price * _quantity;
    }

    // Method to get the product's name and ID (for packing label)
    public string GetProductDetails()
    {
        return $"{_name} (ID: {_productId})";
    }
}

// Define the Address class
public class Address
{
    // Private member variables for encapsulation
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    // Constructor to initialize address attributes
    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }

    // Method to check if the address is in the USA
    public bool IsInUSA()
    {
        return _country.ToLower() == "usa";
    }

    // Method to return the full address as a string
    public string GetFullAddress()
    {
        return $"{_street}\n{_city}, {_state}\n{_country}";
    }
}

// Define the Customer class
public class Customer
{
    // Private member variables for encapsulation
    private string _name;
    private Address _address;

    // Constructor to initialize customer attributes
    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    // Method to check if the customer is in the USA (calls Address class method)
    public bool IsInUSA()
    {
        return _address.IsInUSA();
    }

    // Method to get the customer's name and address (for shipping label)
    public string GetShippingDetails()
    {
        return $"{_name}\n{_address.GetFullAddress()}";
    }
}

// Define the Order class
public class Order
{
    // Private member variables for encapsulation
    private List<Product> _products;
    private Customer _customer;

    // Constructor to initialize order with a list of products and a customer
    public Order(List<Product> products, Customer customer)
    {
        _products = products;
        _customer = customer;
    }

    // Method to calculate the total cost of the order (includes shipping cost)
    public double GetTotalCost()
    {
        double totalCost = 0;

        // Add the total cost of each product
        foreach (var product in _products)
        {
            totalCost += product.GetTotalCost();
        }

        // Add shipping cost (USA: $5, International: $35)
        totalCost += _customer.IsInUSA() ? 5 : 35;

        return totalCost;
    }

    // Method to generate the packing label (lists product names and IDs)
    public string GetPackingLabel()
    {
        string packingLabel = "Packing Label:\n";
        foreach (var product in _products)
        {
            packingLabel += product.GetProductDetails() + "\n";
        }
        return packingLabel;
    }

    // Method to generate the shipping label (includes customer name and address)
    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{_customer.GetShippingDetails()}";
    }
}

// Main Program
class Program
{
    static void Main(string[] args)
    {
        // Create two customers with addresses
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Customer customer1 = new Customer("John Doe", address1);

        Address address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Jane Smith", address2);

        // Create products for each order
        List<Product> products1 = new List<Product>
        {
            new Product("Laptop", "P001", 999.99, 1),
            new Product("Mouse", "P002", 49.99, 2),
        };

        List<Product> products2 = new List<Product>
        {
            new Product("Desk Chair", "P003", 199.99, 1),
            new Product("Monitor", "P004", 299.99, 2),
        };

        // Create two orders with the products and customers
        Order order1 = new Order(products1, customer1);
        Order order2 = new Order(products2, customer2);

        // Display packing label, shipping label, and total cost for each order
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost():F2}\n");

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost():F2}\n");
    }
}
