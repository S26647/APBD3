namespace APBD3;

public class Product
{
    public string Name { get; }
    public double Temperature { get; }

    public Product(string name, double temperature)
    {
        Name = name;
        Temperature = temperature;
    }

    public Product(string name)
    {
        Name = name;
    }
}