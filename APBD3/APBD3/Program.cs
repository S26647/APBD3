
using APBD3;

public class Program
{
    public static void Main(string[] args)
    {
        LuquidContainer lc = new LuquidContainer(10.1);
        LuquidContainer lc2 = new LuquidContainer(12.2);
        
        Console.WriteLine(lc.LoadWeight);
        Console.WriteLine(lc2.LoadWeight);
    }
}