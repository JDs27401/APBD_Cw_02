namespace MP01;

public class GasContainer : Container, IHazardNotifier {
    private int _pressure;  //w atmosferach

    public GasContainer(int pressure) : base(ContainerType.G) {
        _pressure = pressure;
    }

    public override void UnloadContainer() {
        SetCargoWeight( GetCargoWeight() * 0.05);
    }
    
    public void IncidentNotifier() {
        Console.Write($"Container: {GetSerialNumber()} was involved in an accident.");
    }
}