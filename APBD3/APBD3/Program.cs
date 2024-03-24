
namespace APBD3;

public static class Program
{
    public static void Main(string[] args)
    {
        LuquidContainer lc = new LuquidContainer(10.1, false);
        LuquidContainer lc2 = new LuquidContainer(12.1, true);
        GasContainer gc = new GasContainer(10.1, false);

        Product banan = new Product("banan", false, 10);
        gc.LoadContainer(banan, 10.2);
        
        Console.WriteLine(lc.SerialNumber);
        Console.WriteLine(lc2.SerialNumber);
        Console.WriteLine(gc.SerialNumber);
    }
}