namespace APBD3;

public class LiquidContainer : Container, IHazadNotifier
{
    public LiquidContainer(double maxLoad, bool isHazardous) : base(maxLoad, isHazardous)
    {
    }

    public void NotifyAboutDanger(string serialNumber)
    {
        Console.WriteLine($"Warning container {serialNumber} has critical situation!");
    }
}