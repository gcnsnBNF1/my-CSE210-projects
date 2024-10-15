using System;

public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;
    private double _shippingCost;

    public Order(List<Product> products, Customer customer)
    {
        _products = products;
        _customer = customer;
        if (_customer.IsInUSA())
        {
            _shippingCost = 5.0;
        }
        else
        {
            _shippingCost = 35.0;
        }
    }

    public double CalculateTotalCost()
    {
        double totalCost = 0.0;
        foreach (var product in _products)
        {
            totalCost += product.GetTotalCost();
        }
        totalCost += _shippingCost;
        return totalCost;
    }

    public string GetPackingLabel()
    {
        string label = $"Packing List:\n";
        foreach (var product in _products)
        {
            label += $"- {product.GetName()} (x{product.GetQuantity()})\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Ship To:\n{_customer.GetAddress()}";
    }
}