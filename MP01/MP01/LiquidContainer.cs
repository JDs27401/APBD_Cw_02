using System.Transactions;

namespace MP01;

public class LiquidContainer : Container, IHazardNotifier {
    private bool _isCargoHazardous;

    public LiquidContainer(bool ishazardous) : base(ContainerType.L) {
        _isCargoHazardous = ishazardous;
    }

    public override void LoadContainer(double load) {
        /*try
        {
            if (_isCargoHazardous)
            {
                if (GetEmptyWeight() + load > GetMaxWeight() * 0.5)
                {
                    throw new OverfillException("Load is too heavy.");
                }
            }
            else
            {
                if (GetEmptyWeight() + load > GetMaxWeight() * 0.9)
                {
                    throw new OverfillException("Load is too heavy.");
                }
            }
            
        }
        catch (OverfillException e)
        {
            Console.WriteLine("Weight exceeds the maximum capacity.");
            Console.WriteLine("OverfillException handled." , e);
        }
        SetCargoWeight(load);*/
        if (_isCargoHazardous) {
            base.LoadContainer(load * 0.5);
        } else {
            base.LoadContainer(load * 0.9);
        }
    }

    public void IncidentNotifier() {
        Console.Write($"Container: {GetSerialNumber()} was involved in an accident with hazardous cargo.");
    }
}