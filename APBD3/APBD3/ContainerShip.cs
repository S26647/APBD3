namespace APBD3;

public class ContainerShip
{
    public List<Container> ContainersList;
    public string Name;
    public double MaxSpeed;
    public int MaxContainers;
    public double MaxContainersWeight;
    public double CurrentContainersWeight;
    public static int Number = 1;

    public ContainerShip(List<Container> containersList, string name, double maxSpeed, int maxContainers, double maxContainersWeight)
    {
        ContainersList = containersList;
        Name = name;
        MaxSpeed = maxSpeed;
        MaxContainers = maxContainers;
        MaxContainersWeight = maxContainersWeight;
    }

    public void LoadOnShip(Container container)
    {
        ContainersList.Add(container);
        CurrentContainersWeight += container.Weight + container.LoadWeight;
    }

    public void UnloadFromShip(int index)
    {
        CurrentContainersWeight -= ContainersList.ElementAt(index).Weight + ContainersList.ElementAt(index).LoadWeight;
        ContainersList.RemoveAt(index);
    }

    public void UnloadWholeShip()
    {
        ContainersList = new List<Container>();
    }

    public void SwapContainers(string serialNumber1, string serialNumber2)
    {
        
    }

    public void MoveToAnotherShip(int indexShip1, int indexShip2, int indexContainer)
    {
        
    }

    public void PrintInfoAboutContainer(int index)
    {
        Console.WriteLine($"Container's max load: {ContainersList.ElementAt(index).MaxLoad}");
        Console.WriteLine($"Container's height: {ContainersList.ElementAt(index).Height}");
        Console.WriteLine($"Container's weight: {ContainersList.ElementAt(index).Weight}");
        Console.WriteLine($"Container's depth: {ContainersList.ElementAt(index).Depth}");
        Console.WriteLine($"Container's serial number: {ContainersList.ElementAt(index).SerialNumber}");
    }

    public void PrintInfoAboutShip()
    {
        Console.WriteLine($"{Number++}. {Name} (maxSpeed = {MaxSpeed}, maxContainerNum = {MaxContainers}, maxWeight = {MaxContainersWeight})");
        for (int i = 0; i < ContainersList.Count; i++)
        {
            PrintInfoAboutContainer(i);
        }
    }
}