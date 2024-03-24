namespace APBD3;

public class GasContainer : Container, IHazadNotifier
{
    public GasContainer(double maxLoad, bool isHazardous) : base(maxLoad, isHazardous)
    {
    }

    public void NotifyAboutDanger(string serialNumber)
    {
        if (LoadWeight > MaxLoad)
        {
            throw new OverfillException("Load");
        }
    }
}