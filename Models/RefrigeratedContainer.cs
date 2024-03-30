using APBDCw2.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBDCw2.Models
{
    public class RefrigeratedContainer : Container
    {
        public string ProductType { get; private set; }
        public double Temperature { get; private set; }

        public RefrigeratedContainer(double ownWeight, int height, int depth, double maxLoad, string productType, double temperature)
            : base(ownWeight, height, depth, maxLoad, "C")
        {
            ProductType = productType;
            Temperature = temperature;
        }

        public override void Load(double mass)
        {
            if (mass > MaxLoad)
            {
                throw new OverfillException("Nie można załadować więcej niż maksymalna dopuszczalna masa.");
            }
            LoadMass = mass;
        }

        public override void Unload()
        {
            LoadMass = 0;
        }
    }

}
