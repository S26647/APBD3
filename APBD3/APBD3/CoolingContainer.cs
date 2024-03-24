namespace APBD3;

public class CoolingContainer : Container, IHazadNotifier
{
    private Product _product;
    private double _temperature;
    public CoolingContainer(double maxLoad, bool isHazardous, Product product, double temperature) : base(maxLoad, isHazardous)
    {
        _product = product;
        _temperature = temperature;
    }

    public void NotifyAboutDanger(string serialNumber)
    {
        throw new NotImplementedException();
    }
}