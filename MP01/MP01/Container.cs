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

    public Container(string serialNumber, ContainerType type)
    {
        this.serialNumber = "CON-{type}-{main}";
        this.type = type;
        id = mainId++;
    }
}