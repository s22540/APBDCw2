using APBDCw2.Exceptions;
using APBDCw2.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBDCw2.Model
{
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
                SendHazardNotification($"Próba przeładowania {nameof(LiquidContainer)} o numerze: {SerialNumber}");
                throw new OverfillException($"Nie można załadować więcej niż {allowedMass} kg do kontenera.");
            }
            LoadMass = mass;
        }

        public override void Unload()
        {
            LoadMass = 0;
        }

        public void SendHazardNotification(string message)
        {
            Console.WriteLine($"Powiadomienie o niebezpieczeństwie: {message}");
        }
    }

}
