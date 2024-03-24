namespace APBD3;

public class LuquidContainer : Container, IHazadNotifier
{
    public LuquidContainer(double maxLoad, bool isHazardous) : base(maxLoad, isHazardous)
    {
    }

    public void NotifyAboutDanger(string serialNumber)
    {
        throw new NotImplementedException();
    }
}