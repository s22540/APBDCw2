using APBDCw2.Exceptions;
using APBDCw2.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBDCw2.Models
{
    public class GasContainer : Container, IHazardNotifier
    {
        public double Pressure { get; private set; }

        public GasContainer(double ownWeight, int height, int depth, double maxLoad, double pressure)
            : base(ownWeight, height, depth, maxLoad, "G")
        {
            Pressure = pressure;
        }

        public override void Load(double mass)
        {
            if (mass > MaxLoad)
            {
                SendHazardNotification($"Próba przeciążenia kontenera na gaz o numerze: {SerialNumber}");
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
            Console.WriteLine($"Powiadomienie o zagrożeniu dla kontenera na gaz: {message}");
        }
    }
}
