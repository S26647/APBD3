namespace APBD3;

public class Product
{
    private string _name { get; }
    private double _temperature { get; }

    public Product(string name, double temperature)
    {
        _name = name;
        _temperature = temperature;
    }
}