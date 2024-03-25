namespace APBD3;

public class CoolingContainer : Container
{
    public double ContainerTemperature;
    public string ProductType;
    public CoolingContainer(double maxLoad, double height, double weight, double depth, String productType, double containerTemperature) : base(maxLoad, height, weight, depth)
    {
        ProductType = productType;
        ContainerTemperature = containerTemperature;
    }

    public void LoadContainer(double loadWeight, string productType, double productTemperature)
    {
        base.LoadContainer(loadWeight);
        if (ProductType != productType && ProductType != null)
        {
            throw new ProductException("Can't put different products in one container!");
        }
        if (ProductType != null && ContainerTemperature < productTemperature)
        {
            throw new ProductException("Can't put that product in this container due to temperature!");
        }
        
        ProductType = productType;
        LoadWeight += loadWeight;
    }

    public override void PrintInfoAboutContainer()
    {
        base.PrintInfoAboutContainer();
        Console.WriteLine($"product = {ProductType}, container temperature = {ContainerTemperature})");
    }
}