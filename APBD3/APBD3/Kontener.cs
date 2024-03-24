namespace APBD3;

public abstract class Container
{
    public Product LoadProduct { get; set; }
    public double LoadWeight { get; set; }
    public double Height { get; set; }
    public double Weight { get; set; }
    public double Depth { get; set; }
    public bool IsHazardous { get; set; }
    public string SerialNumber { get; set; }
    private static int Number = 1;
    public double MaxLoad { get; set; }

    public Container(double maxLoad, bool isHazardous)
    {
        MaxLoad = maxLoad;
        IsHazardous = isHazardous;
        SerialNumber = GenerateSerialNumber();
    }

    private string GenerateSerialNumber()
    {
        string type = GetType().Name switch
        {
            nameof(LuquidContainer) => "L",
            nameof(GasContainer) => "G",
            nameof(CoolingContainer) => "C",
            _ => "D"
        } + "-";
        return "CON-" + type + Number++;
    }

    public void EmptyLoad()
    {
        if (GetType() == typeof(GasContainer))
        {
            LoadWeight *= 0.05;
        }
        LoadWeight = 0.0;
    }

    public void LoadContainer(Product product, double loadWeight)
    {
        double allowedLoad = MaxLoad;
        if (GetType() == typeof(LuquidContainer))
        {
            if (IsHazardous)
            {
                allowedLoad = MaxLoad * 0.5;
            }
            else
            {
                allowedLoad = MaxLoad * 0.9;
            }
        }
        
        if (LoadWeight + loadWeight > allowedLoad)
        {
            throw new OverfillException("Load too heavy");
        }

        LoadProduct = product;
        LoadWeight = loadWeight;
    }
}