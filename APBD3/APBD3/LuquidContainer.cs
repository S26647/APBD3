namespace APBD3;

public class LuquidContainer : Container, IHazadNotifier
{
    public LuquidContainer(double loadWeight)
    {
        base.LoadWeight = loadWeight;
        SerialNumber = "KON" + "L" + Number.ToString();
    }
    
}