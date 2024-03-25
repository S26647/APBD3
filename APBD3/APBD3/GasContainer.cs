namespace APBD3;

public class GasContainer : Container, IHazardNotifier
{
    private double _pressure;
    public GasContainer(double maxLoad, double height, double weight, double depth, double pressure) : base(maxLoad, height, weight, depth)
    {
        _pressure = pressure;
    }

    public override void EmptyLoad()
    {
        LoadWeight *= 0.05;
    }

    public override void LoadContainer(double loadWeight)
    {
        try
        {
            base.LoadContainer(loadWeight);
            if (LoadWeight + loadWeight > MaxLoad)
            {
                NotifyAboutDanger(SerialNumber);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public void NotifyAboutDanger(string serialNumber)
    {
        if (LoadWeight > MaxLoad)
        {
            Console.WriteLine($"Warning container {serialNumber} has critical situation!");
        }
    }

    public override void PrintInfoAboutContainer()
    {
        base.PrintInfoAboutContainer();
        Console.WriteLine($"pressure = {_pressure})");
    }
}