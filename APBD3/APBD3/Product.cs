namespace APBD3;

public class Product
{
    public string Name { get; set; }
    public bool Dangerous { get; set; }
    public double Temperature { get; set; }

    public Product(string name, bool dangerous, double temperature)
    {
        Name = name;
        Dangerous = dangerous;
        Temperature = temperature;
    }
}