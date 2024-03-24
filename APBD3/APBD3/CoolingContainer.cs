namespace APBD3;

public class CoolingContainer : Container, IHazadNotifier
{
    public CoolingContainer(double maxLoad, bool isHazardous) : base(maxLoad, isHazardous)
    {
    }

    public void NotifyAboutDanger(string serialNumber)
    {
        throw new NotImplementedException();
    }
}