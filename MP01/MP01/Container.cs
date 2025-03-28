namespace MP01;

public abstract class Container
{
    private static Dictionary<string, Container> containers = new Dictionary<string, Container>();
    private static int _mainId = 0;
    private int _id;
    private int _cargoWeight;            //in kilograms
    private int _emptyWeight = 2_000;    //in kilograms
    private int _maxWeight = 24_000;     //in kilograms
    private int _height = 243;           //in centimeters
    private int _depth = 605;            //in centimeters
    private string _serialNumber;
    private ContainerType _type;
    private int _delay;

    protected Container(ContainerType type)
    {
        _type = type;
        _serialNumber = $"CON-{_type}-{_mainId++}";
        _id = _mainId++;
    }

    public void LoadContainer(int load)
    {
        try
        {
            if (_emptyWeight + load > _maxWeight)
            {
                throw new OverfillException("Load is too heavy.");
            }
        }
        catch (OverfillException e)
        {
            Console.WriteLine($"Weight exceeds max by: {_emptyWeight + load - _maxWeight}");
            Console.WriteLine("OverfillException handled." , e);
        }
        _cargoWeight = load;
    }

    public override string ToString()
    {
        return $"{nameof(_serialNumber)}: {_serialNumber}, {nameof(_type)}: {_type}, {nameof(_cargoWeight)}: {_cargoWeight})";
    }
}