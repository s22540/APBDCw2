using System;

public abstract class Container
{
    private static int serialCounter = 1;

    public double LoadMass { get; set; }
    public int Height { get; private set; }
    public double OwnWeight { get; private set; }
    public int Depth { get; private set; }
    public string SerialNumber { get; private set; }
    public double MaxLoad { get; private set; }

    protected Container(double ownWeight, int height, int depth, double maxLoad, string containerType)
    {
        OwnWeight = ownWeight;
        Height = height;
        Depth = depth;
        MaxLoad = maxLoad;
        SerialNumber = $"KON-{containerType}-{serialCounter++}";
    }

    public abstract void Load(double mass);
    public abstract void Unload();
}