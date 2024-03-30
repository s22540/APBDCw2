using APBDCw2.Exceptions;
using APBDCw2.Interface;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; set; }

    public LiquidContainer(double ownWeight, int height, int depth, double maxLoad, bool isHazardous)
        : base(ownWeight, height, depth, maxLoad, "L")
    {
        IsHazardous = isHazardous;
    }

    public override void Load(double mass)
    {
        double allowedMass = IsHazardous ? MaxLoad * 0.5 : MaxLoad * 0.9;
        if (mass > allowedMass)
        {
            SendHazardNotification($"Próba przeciążenia kontenera o numerze: {SerialNumber}");
            throw new OverfillException("Nie można załadować więcej niż maksymalna dopuszczalna masa.");
        }
        LoadMass = mass;
    }

    public override void Unload()
    {
        LoadMass = 0;
    }

    public void SendHazardNotification(string message)
    {
        Console.WriteLine($"Powiadomienie o zagrożeniu: {message}");
    }
}