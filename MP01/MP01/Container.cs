namespace MP01;

public abstract class Container {
    private static Dictionary<string, Container> containers = new Dictionary<string, Container>();
    private static int _mainId = 0;
    private int _id;
    private double _cargoWeight;            //in kilograms
    private double _emptyWeight = 2_000;    //in kilograms
    private double _maxWeight = 24_000;     //in kilograms
    private int _height = 243;           //in centimeters
    private int _depth = 605;            //in centimeters
    private string _serialNumber;
    private ContainerType _type;
    private int _delay;

    protected Container(ContainerType type)
    {
        _type = type;
        _id = _mainId++;
        _serialNumber = $"CON-{_type}-{_id}";
    }

    public virtual void LoadContainer(double load) {
        if (load < 0) {
            throw new ArgumentException("Load cannot be a negative value!");
        }
        try {
            if (_emptyWeight + load > _maxWeight) {
                throw new OverfillException("Load is too heavy.");
            }
        } catch (OverfillException e) {
            Console.WriteLine($"Weight exceeds max by: {_emptyWeight + load - _maxWeight}");
            Console.WriteLine("OverfillException handled." , e);
        }
        _cargoWeight += load;
    }

    public virtual void UnloadContainer() {
        _cargoWeight = 0;
    }

    public override string ToString() {
        return $"{nameof(_serialNumber)}: {_serialNumber}, {nameof(_type)}: {_type}, {nameof(_cargoWeight)}: {_cargoWeight})";
    }

    public String GetSerialNumber() {
        return _serialNumber;
    }

    public double GetCargoWeight() {
        return _cargoWeight;
    }

    public double GetEmptyWeight() {
        return _emptyWeight;
    }

    public double GetMaxWeight() {
        return _maxWeight;
    }

    public void SetCargoWeight(double load) {
        _cargoWeight = load;
    }
}