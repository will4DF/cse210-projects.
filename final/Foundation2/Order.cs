using System.Collections.Generic;

public class Order
{
    private List<Product> products = new List<Product>();
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public double GetTotalCost()
    {
        double total = 0;
        foreach (var p in products)
            total += p.GetTotalPrice();

        total += customer.GetAddress().IsUSA() ? 5 : 35;
        return total;
    }

    public string GetPackingLabel()
    {
        string label = "";
        foreach (var p in products)
            label += $"{p.GetName()} (ID: {p.GetProductId()}) x {p.GetQuantity()}\n";
        return label;
    }

    public string GetShippingLabel()
    {
        return $"{customer.GetName()}\n{customer.GetAddress().GetAddressString()}";
    }
}
