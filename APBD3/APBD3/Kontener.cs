namespace APBD3;

public abstract class Container
{
    private static int _number = 1;
    public Product LoadProduct { get; set; }
    public double LoadWeight { get; set; }
    public double Height { get; set; }
    public double Weight { get; set; }
    public double Depth { get; set; }
    private bool IsHazardous { get; set; }
    public string SerialNumber { get; set; }
    public double MaxLoad { get; set; }

    public Container(double maxLoad, bool isHazardous)
    {
        MaxLoad = maxLoad;
        IsHazardous = isHazardous;
        LoadWeight = 0;
        SerialNumber = GenerateSerialNumber();
    }

    private string GenerateSerialNumber()
    {
        string type = GetType().Name switch
        {
            nameof(LiquidContainer) => "L",
            nameof(GasContainer) => "G",
            nameof(CoolingContainer) => "C",
            _ => "D"
        } + "-";
        return "CON-" + type + _number++;
    }

    public void EmptyLoad()
    {
        if (GetType() == typeof(GasContainer))
        {
            LoadWeight *= 0.05;
        }
        else
        {
            LoadWeight = 0.0;
        }
    }

    public void LoadContainer(Product product, double loadWeight)
    {
        double allowedLoad = MaxLoad;
        if (GetType() == typeof(LiquidContainer))
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
        
        if (LoadWeight + loadWeight > allowedLoad && !IsHazardous)
        {
            Console.WriteLine(allowedLoad + " ," + loadWeight + " " + LoadWeight);
            throw new OverfillException("Load too heavy");
        }

        if (IsHazardous && LoadWeight + loadWeight > allowedLoad)
        {
            (this as LiquidContainer)?.NotifyAboutDanger(SerialNumber);
        }

        LoadProduct = product;
        LoadWeight += loadWeight;
    }
}