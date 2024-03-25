namespace APBD3;

public class ContainerShip
{
    public List<Container?> ContainersList;
    public string Name;
    public double MaxSpeed;
    public int MaxContainers;
    public double MaxContainersWeight;
    public double CurrentContainersWeight;

    public ContainerShip(string name, double maxSpeed, int maxContainers, double maxContainersWeight)
    {
        ContainersList = new List<Container?>();
        Name = name;
        MaxSpeed = maxSpeed;
        MaxContainers = maxContainers;
        MaxContainersWeight = maxContainersWeight;
    }

    public void LoadOnShip(Container? container)
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
        ContainersList = new List<Container?>();
    }

    public void SwapContainers(string serialNumber1, string serialNumber2)
    {
        
    }

    public void MoveToAnotherShip(ContainerShip? ship, Container? con1)
    {
        ship.ContainersList.Add(ContainersList.Find(c => c == con1));
        ContainersList.RemoveAll(c => c == con1);
    }

    public void PrintInfoAboutShip()
    {
        Console.WriteLine($"{Name} (maxSpeed = {MaxSpeed}, maxContainerNum = {MaxContainers}, maxWeight = {MaxContainersWeight})");
        foreach (var container in ContainersList)
        {
            Console.Write("      ");
            container.PrintInfoAboutContainer();
        }
    }
}