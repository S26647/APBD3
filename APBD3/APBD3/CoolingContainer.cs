namespace APBD3;

public class CoolingContainer : Container
{
    public double ContainerTemperature;
    public Product LoadProduct;
    public CoolingContainer(double maxLoad, double height, double weight, double depth, bool isHazardous, Product product, double containerTemperature) : base(maxLoad, height, weight, depth)
    {
        try
        {
            LoadProduct = product;
            ContainerTemperature = containerTemperature;
            
            if (ContainerTemperature < product.Temperature)
            {
                throw new ProductException("Container's temperature too low for this product");
            }
        }
        catch (ProductException e)
        {
            Console.WriteLine(e);
        }
    }
    
    public void LoadContainer(double loadWeight, Product product)
    {
        base.LoadContainer(loadWeight);
        if (LoadProduct != product && LoadProduct != null)
        {
            throw new ProductException("Can't put different products in one container!");
        }
        if (LoadProduct != null && LoadProduct.Temperature < product.Temperature)
        {
            throw new ProductException("Can't put that product in this container due to temperature!");
        }
        
        LoadProduct = product;
        LoadWeight += loadWeight;
        
    }

    public override void PrintInfoAboutContainer()
    {
        base.PrintInfoAboutContainer();
        Console.Write($"container temperature = {ContainerTemperature}, product = {LoadProduct.Name}, product temperature = {LoadProduct.Temperature})");
    }
}