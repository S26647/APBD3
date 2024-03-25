
namespace APBD3;

public static class Program
{
    static int commandNumber = 1;
    public static void Main(string[] args)
    {
        List<ContainerShip?> shipsList = new List<ContainerShip?>();
        List<Container?> containersList = new List<Container?>();
        shipsList.Add(new ContainerShip("Ship1",10, 10, 10));
        shipsList.Add(new ContainerShip("Ship2",10, 10, 10));
        containersList.Add(new LiquidContainer(100, 10, 10, 10, true));

        while (true)
        {
            try
            {
                commandNumber = 1;
                Console.WriteLine("List of container ships: ");
                PrintShipList(shipsList);

                commandNumber = 1;
                Console.WriteLine("\nList of containers: ");
                PrintContainerList(containersList);

                commandNumber = 1;
                Console.WriteLine("\nList of possible actions: ");
                Console.WriteLine($"{commandNumber++}. (as) Add container ship");
                Console.WriteLine($"{commandNumber++}. (ac) Add container");
                if (shipsList.Count != 0)
                {
                    Console.WriteLine($"{commandNumber++}. (rs) Remove container ship");
                    Console.WriteLine($"{commandNumber++}. (us) Unload ship");
                }
                if (shipsList.Count > 1)
                {
                    Console.WriteLine($"{commandNumber++}. (mc) Move container from one ship to another");
                }

                if (containersList.Count != 0)
                {
                    Console.WriteLine($"{commandNumber++}. (rc) Remove container");
                    Console.WriteLine($"{commandNumber++}. (lc) Load Container");
                    Console.WriteLine($"{commandNumber++}. (uc) Unload container from ship");
                    Console.WriteLine($"{commandNumber++}. (sc) Swap containers");
                }

                if (containersList.Count != 0 && shipsList.Count != 0)
                {
                    Console.WriteLine($"{commandNumber++}. (lcs) Load container on ship");
                }

                Console.WriteLine($"{commandNumber}. (ex) Exit");

                string? command = Console.ReadLine();
                commandNumber = 1;
                switch (command)
                {
                    case "as":
                        Console.WriteLine("Enter name, max speed, max containers, max containers weight");
                        string[]? cs = Console.ReadLine()?.Split(",");
                        ContainerShip? containerShip = new ContainerShip(cs[0],
                            Convert.ToDouble(cs[1]),
                            Convert.ToInt32(cs[2]),
                            Convert.ToDouble(cs[3]));
                        shipsList.Add(containerShip);
                        break;
                    case "ac":
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
                            case "G":
                                Console.WriteLine("Enter maxLoad, height, weight, depth, pressure");
                                string[]? gc = Console.ReadLine()?.Split(",");
                                GasContainer gasContainer = new GasContainer(Convert.ToDouble(gc?[0]),
                                    Convert.ToDouble(gc?[1]),
                                    Convert.ToDouble(gc?[2]),
                                    Convert.ToDouble(gc?[3]),
                                    Convert.ToDouble(gc?[4]));
                                containersList.Add(gasContainer);
                                break;
                            case "C":
                                Console.WriteLine(
                                    "Enter maxLoad, height, weight, depth, product, container temperature");
                                string[]? cc = Console.ReadLine()?.Split(",");
                                CoolingContainer coolingContainer = new CoolingContainer(Convert.ToDouble(cc?[0]),
                                    Convert.ToDouble(cc?[1]),
                                    Convert.ToDouble(cc?[2]),
                                    Convert.ToDouble(cc?[3]),
                                    cc?[4],
                                    Convert.ToDouble(cc?[5]));
                                containersList.Add(coolingContainer);
                                break;
                        }

                        break;
                    case "rs":
                        Console.WriteLine("List of possible ships:");
                        PrintShipList(shipsList);
                        command = Console.ReadLine()?.ToLower();
                        shipsList.RemoveAll(c => c.Name.ToLower() == command);
                        break;
                    case "us":
                        Console.WriteLine("List of possible ships:");
                        PrintShipList(shipsList);
                        command = Console.ReadLine()?.ToLower();
                        ContainerShip ship = shipsList.Find(c => c.Name.ToLower() == command);
                        foreach (var container in ship.ContainersList)
                        {
                            containersList.Add(container);
                        }

                        shipsList.Find(c => c.Name.ToLower() == command)?.UnloadWholeShip();
                        break;
                    case "mc":
                        Console.WriteLine("List of possible ships:");
                        Console.WriteLine("Choose shipFrom, shipTo, load");
                        PrintShipList(shipsList);
                        string[]? commandSplit = Console.ReadLine()?.ToLower().Split(",");
                        ContainerShip? ship1 = shipsList.Find(s => s.Name.ToLower() == commandSplit?[0]);
                        ContainerShip? ship2 = shipsList.Find(s => s.Name.ToLower() == commandSplit?[1]);
                        Container? container1 = ship1.ContainersList.Find(c => c.SerialNumber.ToLower() == commandSplit?[2]);
                        shipsList.Find(s => s.Name.ToLower() == commandSplit?[0]).MoveToAnotherShip(ship2, container1);
                        
                        break;
                    case "rc":
                        Console.WriteLine("List of possible containers:");
                        PrintContainerList(containersList);
                        command = Console.ReadLine()?.ToLower();
                        containersList.RemoveAll(c => c.SerialNumber.ToLower() == command);
                        break;
                    case "lc":
                        Console.WriteLine("List of possible containers:");
                        PrintContainerList(containersList);
                        command = Console.ReadLine()?.ToLower();
                        Console.WriteLine("How much load?");
                        double load = Convert.ToDouble(Console.ReadLine()?.ToLower());
                        containersList.Find(c => c.SerialNumber.ToLower() == command)?.LoadContainer(load);
                        break;
                    case "uc":
                        break;
                    case "sc":
                        break;
                    case "lcs":
                        Console.WriteLine("List of possible containers:");
                        PrintContainerList(containersList);
                        command = Console.ReadLine()?.ToLower();
                        Container? con = containersList.Find(c => c.SerialNumber.ToLower() == command);
                        containersList.RemoveAll(c => c.SerialNumber.ToLower() == command);

                        Console.WriteLine("List of possible ships:");
                        PrintShipList(shipsList);
                        command = Console.ReadLine()?.ToLower();
                        shipsList.Find(c => c.Name.ToLower() == command)?.LoadOnShip(con);
                        break;
                    case "ex":
                        Environment.Exit(0);
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();
        }
    }

    public static void PrintShipList(List<ContainerShip?> list)
    {
        if (list.Count == 0)
        {
            Console.WriteLine("Empty");    
        }
        else
        {
            foreach (var ship in list)
            {
                Console.Write($"{commandNumber++}. ");
                ship.PrintInfoAboutShip();
                
            }
        }
    }

    public static void PrintContainerList(List<Container?> list)
    {
        if (list.Count == 0)
        {
            Console.WriteLine("Empty");    
        }
        else
        {
            foreach (var container in list)
            {
                Console.Write($"{commandNumber++}. ");
                container.PrintInfoAboutContainer();
            }
        }
    }
}