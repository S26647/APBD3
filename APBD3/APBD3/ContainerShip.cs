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

    public void UnloadFromShip(Container container)
    {
        CurrentContainersWeight -= container.Weight + container.LoadWeight;
        ContainersList.RemoveAll(c => c == container);
    }

    public void UnloadWholeShip()
    {
        ContainersList = new List<Container?>();
        CurrentContainersWeight = 0;
    }

    public void SwapContainers(Container con1, Container con2)
    {
        LoadOnShip(con2);
        UnloadFromShip(con1);
    }

    public void MoveToAnotherShip(ContainerShip? ship, Container? con1)
    {
        ship.ContainersList.Add(ContainersList.Find(c => c == con1));
        CurrentContainersWeight -= con1.LoadWeight + con1.Weight;
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