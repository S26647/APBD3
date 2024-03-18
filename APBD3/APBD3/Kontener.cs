namespace APBD3;

public abstract class Container
{
    public double LoadWeight { get; set; }
    public double Height { get; set; }
    public double Weight { get; set; }
    public double Depth { get; set; }
    public string SerialNumber { get; set; }
    public static int Number { get; set; }
    public double MaxLoad { get; set; }
    
    public void EmptyLoad()
    {
        LoadWeight = 0.0;
    }

    public void LoadContainer(double loadWeigth)
    {
        if (LoadWeight > MaxLoad)
        {
            throw new OverfillException("Load too heavy");
        }
        else
        {
            
        }
    }
}