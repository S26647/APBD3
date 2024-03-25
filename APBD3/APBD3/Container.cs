namespace APBD3;

public abstract class Container
{
    private static int _number = 1;
    public double LoadWeight { get; set; }
    public double Height { get; }
    public double Weight { get; }
    public double Depth { get; }
    public string SerialNumber { get; }
    public double MaxLoad { get; }

    public Container(double maxLoad, double height, double weight, double depth)
    {
        MaxLoad = maxLoad;
        Height = height;
        Weight = weight;
        Depth = depth;
        MaxLoad = maxLoad;
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

    public virtual void EmptyLoad()
    {
        LoadWeight = 0.0;
    }
    
    public virtual void LoadContainer(double loadWeight)
    {
        LoadWeight += loadWeight;
        
        if (LoadWeight + loadWeight > MaxLoad)
        {
            throw new OverfillException("Load too heavy!");
        }
    }

    public virtual void PrintInfoAboutContainer()
    {
        Console.Write($"{SerialNumber} (maxLoad = {MaxLoad}, load weight = {LoadWeight} height = {Height}, weight = {Weight}, depth = {Depth}, ");
    }
}