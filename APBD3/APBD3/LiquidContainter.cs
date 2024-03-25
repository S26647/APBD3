namespace APBD3;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardous;
    public LiquidContainer(double maxLoad, double height, double weight, double depth, bool isHazardous) : base(maxLoad, height, weight, depth)
    {
        IsHazardous = isHazardous;
    }

    public void NotifyAboutDanger(string serialNumber)
    {
        Console.WriteLine($"Warning container {serialNumber} has critical situation!");
    }

    public override void LoadContainer(double loadWeight)
    {
        base.LoadContainer(loadWeight);
        double allowedLoad;
        if (IsHazardous)
        {
            allowedLoad = MaxLoad * 0.5;
        }
        else
        {
            allowedLoad = MaxLoad * 0.9;
        }
        
        if (LoadWeight + loadWeight > allowedLoad && !IsHazardous)
        {
            throw new OverfillException("Load too heavy");
        }

        if (IsHazardous && LoadWeight + loadWeight > allowedLoad)
        {
            NotifyAboutDanger(SerialNumber);
        }
    }

    public override void PrintInfoAboutContainer()
    {
        base.PrintInfoAboutContainer();
        Console.WriteLine($"hazardous = {IsHazardous})");
    }
}