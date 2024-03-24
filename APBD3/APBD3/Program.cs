
namespace APBD3;

public static class Program
{
    public static void Main(string[] args)
    {
        List<ContainerShip> shipsList = new List<ContainerShip>();
        List<Container> containersList = new List<Container>();
        shipsList.Add(new ContainerShip(new List<Container>(), "Ship 1",10, 10, 10));
        containersList.Add(new LiquidContainer(100, 10, 10, 10, true));

        GasContainer g = new GasContainer(100, 10, 10, 10, true, 10);
        g.PrintInfoAboutContainer();

        /*while (true)
        {
            int commandNumber = 1;
            Console.WriteLine("List of container ships: ");
            foreach (var ship in shipsList)
            {
                ship.PrintInfoAboutShip();
            }
            
            Console.WriteLine("\nList of containers: ");
            foreach (var container in containersList) 
            {
                container.PrintInfoAboutContainer();
            }
            
            Console.WriteLine("\nList of possible actions: ");
            Console.WriteLine($"{commandNumber++}. (as) Add container ship");
            if (shipsList.Count != 0)
            {
                Console.WriteLine($"{commandNumber++}. (rs) Remove container ship");
            }
            
            Console.WriteLine($"{commandNumber++}. (ac) Add container");
            if (containersList.Count != 0) 
            {
                Console.WriteLine($"{commandNumber++}. (rc) Remove container");
                Console.WriteLine($"{commandNumber++}. (lc) Load container on ship");
                Console.WriteLine($"{commandNumber++}. (uc) Unload container from ship");
                Console.WriteLine($"{commandNumber++}. (us) Unload ship");
                Console.WriteLine($"{commandNumber++}. (sc) Swap containers");
                Console.WriteLine($"{commandNumber++}. (mc) Move container from one ship to another");
            }
            Console.WriteLine($"{commandNumber}. (ex) Exit");

            string? command = Console.ReadLine();
            commandNumber = 1;
            switch (command)
            {
                case "as":
                    Console.WriteLine("What type of container:");
                    Console.WriteLine($"{commandNumber++}. (L) Liquid container");
                    Console.WriteLine($"{commandNumber++}. (G) Gas container");
                    Console.WriteLine($"{commandNumber}. (C) Cooling container");
                    command = Console.ReadLine()?.ToUpper();
                    switch (command)
                    {
                        case "L":
                            Console.WriteLine("Enter maxLoad, height, weight, depth, hazardous(true/false)");
                            string[]? lc = Console.ReadLine()?.Split(",");
                            LiquidContainer liquidContainer = new LiquidContainer(Convert.ToDouble(lc?[0]),
                                Convert.ToDouble(lc?[1]),
                                Convert.ToDouble(lc?[2]),
                                Convert.ToDouble(lc?[3]),
                                Convert.ToBoolean(lc?[4]));
                            containersList.Add(liquidContainer);
                            break;
                    }
                    break;
            }
        }*/
    }
}