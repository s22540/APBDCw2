using APBDCw2.Exceptions;
using APBDCw2.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBDCw2.Model
{
    public class GasContainer : Container, IHazardNotifier
    {
        public double Pressure { get; set; }

        public GasContainer(double ownWeight, int height, int depth, double maxLoad, double pressure)
            : base(ownWeight, height, depth, maxLoad, "G")
        {
            Pressure = pressure;
        }

        public override void Load(double mass)
        {
            if (mass > MaxLoad)
            {
                SendHazardNotification($"Próba przeładowania {nameof(GasContainer)} o numerze: {SerialNumber}");
                throw new OverfillException("Kontener przeładowany.");
            }
            LoadMass = mass;
        }

        public override void Unload()
        {
            LoadMass *= 0.05; // 5% ładunku kontenera ma pozostać przy rozładunku.
        }

        public void SendHazardNotification(string message)
        {
            Console.WriteLine($"Powiadomienie o niebezpieczeństwie: {message}");
        }
    }
}
