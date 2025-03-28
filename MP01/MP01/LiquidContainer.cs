namespace MP01;

public class LiquidContainer : Container
{
    private bool _isCargoHazardous;
    public LiquidContainer(bool ishazardous) : base(ContainerType.L)
    {
        _isCargoHazardous = ishazardous;
    }
}