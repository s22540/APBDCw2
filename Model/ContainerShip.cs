using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBDCw2.Model
{
    public class ContainerShip
    {
        public List<Container> Containers { get; private set; }
        public int MaxSpeed { get; private set; }
        public int MaxContainerCount { get; private set; }
        public double MaxWeight { get; private set; }

        public ContainerShip(int maxSpeed, int maxContainerCount, double maxWeight)
        {
            MaxSpeed = maxSpeed;
            MaxContainerCount = maxContainerCount;
            MaxWeight = maxWeight;
            Containers = new List<Container>();
        }

        public void AddContainer(Container container)
        {
            if (Containers.Count >= MaxContainerCount)
            {
                Console.WriteLine("Nie można dodać więcej kontenerów. Statek jest pełny.");
                return;
            }

            if (Containers.Sum(c => c.LoadMass + c.OwnWeight) + container.LoadMass + container.OwnWeight > MaxWeight)
            {
                Console.WriteLine("Nie można dodać kontenera. Waga za duża.");
                return;
            }

            Containers.Add(container);
            Console.WriteLine($"Kontener {container.SerialNumber} dodany.");
        }

        public void RemoveContainer(string serialNumber)
        {
            var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
            if (container != null)
            {
                Containers.Remove(container);
                Console.WriteLine($"Kontener {serialNumber} usunięty.");
            }
            else
            {
                Console.WriteLine("Nie znaleziono kontenera.");
            }
        }

        public void ListContainers()
        {
            foreach (var container in Containers)
            {
                Console.WriteLine($"Numer kontenera: {container.SerialNumber}, Masa: {container.LoadMass}, Typ: {container.GetType().Name}");
            }
        }

        public void LoadContainers(List<Container> containers)
        {
            foreach (var container in containers)
            {
                AddContainer(container); 
            }
        }

        public void UnloadContainer(string serialNumber)
        {
            var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
            if (container != null)
            {
                container.Unload(); 
                Console.WriteLine($"Kontener {serialNumber} rozładowany.");
            }
            else
            {
                Console.WriteLine("Nie znaleziono kontenera.");
            }
        }

        public void ReplaceContainer(string serialNumber, Container newContainer)
        {
            RemoveContainer(serialNumber); // Usuwa stary kontener
            AddContainer(newContainer); // Dodaje nowy kontener
        }

        public void TransferContainer(ContainerShip targetShip, string serialNumber)
        {
            var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
            if (container != null)
            {
                RemoveContainer(serialNumber); // Usuwa kontener z obecnego statku
                targetShip.AddContainer(container); // Dodaje kontener do docelowego statku
            }
            else
            {
                Console.WriteLine("Nie znaleziono kontenera.");
            }
        }

        public void PrintShipInfo()
        {
            Console.WriteLine($"Informacje statku: Prędkość: {MaxSpeed}, Pojemność: {MaxContainerCount}, Maksymalna waga: {MaxWeight}");
            Console.WriteLine("Kontenery na statku:");
            ListContainers(); // Wypisuje listę kontenerów
        }
    }
}

