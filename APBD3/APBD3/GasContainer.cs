namespace APBD3;

public class GasContainer : Container, IHazadNotifier
{
    private double _pressure;
    public GasContainer(double maxLoad, bool isHazardous, double pressure) : base(maxLoad, isHazardous)
    {
        _pressure = pressure;
    }

    public void NotifyAboutDanger(string serialNumber)
    {
        if (LoadWeight > MaxLoad)
        {
            Console.WriteLine($"Warning container {serialNumber} has critical situation!");
        }
    }
}