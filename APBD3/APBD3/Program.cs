
namespace APBD3;

public static class Program
{
    public static void Main(string[] args)
    {
        LiquidContainer milkContainer = new LiquidContainer(1000, true);
        GasContainer heliumContainer = new GasContainer(500, true, 1000);
        Product milk = new Product("milk", 1000);
        Product helium = new Product("helium",  100);
        
        heliumContainer.LoadContainer(helium, 500);
        heliumContainer.EmptyLoad();
        Console.WriteLine(heliumContainer.LoadWeight);
        
        milkContainer.LoadContainer(milk, 950);

        Console.WriteLine($"Milk Container Number: {milkContainer.SerialNumber}");
        Console.WriteLine($"Helium Container Number: {heliumContainer.SerialNumber}");

        
    }
}