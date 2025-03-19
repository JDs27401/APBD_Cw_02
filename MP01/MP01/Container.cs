namespace MP01;

public class Container
{
    private static Dictionary<string, Container> containers = new Dictionary<string, Container>();
    private static int mainId = 0;
    private int id;
    private int cargoWeight;            //in kilograms
    private int emptyWeight = 2_000;    //in kilograms
    private int maxWeight = 24_000;     //in kilograms
    private int height = 243;           //in centimeters
    private int depth = 605;            //in centimeters
    private string serialNumber;
    private ContainerType type;
    private int delay;

    public Container(ContainerType type)
    {
        serialNumber = $"CON-{type}-{mainId++}";
        this.type = type;
        id = mainId++;
    }

    public void loadContainer(int load)
    {
        try
        {
            if (emptyWeight + load > maxWeight)
            {
                throw new OverfillException("Load is too heavy.");
            }
        }
        catch (OverfillException e)
        {
            Console.WriteLine($"Weight exceeds max by: {emptyWeight + load - maxWeight}");
            Console.WriteLine("OverfillException handled." , e);
        }
        cargoWeight = load;
    }

    public override string ToString()
    {
        return $"{nameof(serialNumber)}: {serialNumber}, {nameof(type)}: {type}, {nameof(cargoWeight)}: {cargoWeight})";
    }
}