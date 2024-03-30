using APBDCw2.Models;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var containerShip1 = new ContainerShip(30, 200, 500000);
        var containerShip2 = new ContainerShip(25, 150, 400000);

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nDostępne akcje:");
            Console.WriteLine("1. Dodaj kontener");
            Console.WriteLine("2. Usuń kontener");
            Console.WriteLine("3. Lista kontenerów na statku");
            Console.WriteLine("4. Załaduj listę kontenerów na statek");
            Console.WriteLine("5. Rozładuj kontener");
            Console.WriteLine("6. Zastąp kontener na statku");
            Console.WriteLine("7. Przenieś kontener między statkami");
            Console.WriteLine("8. Wyświetl informacje o statku");
            Console.WriteLine("9. Wyjście");

            Console.Write("\nWybierz akcję: ");
            string action = Console.ReadLine();

            switch (action)
            {
                case "1":
                    AddContainer(containerShip1);
                    break;
                case "2":
                    RemoveContainer(containerShip1);
                    break;
                case "3":
                    containerShip1.ListContainers();
                    break;
                case "4":
                    LoadContainersList(containerShip1);
                    break;
                case "5":
                    UnloadContainer(containerShip1);
                    break;
                case "6":
                    ReplaceContainer(containerShip1);
                    break;
                case "7":
                    TransferContainerBetweenShips(containerShip1, containerShip2);
                    break;
                case "8":
                    containerShip1.PrintShipInfo();
                    break;
                case "9":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Nieznana akcja.");
                    break;
            }
        }
    }

    static void AddContainer(ContainerShip ship)
        {
            Console.WriteLine("Dodawanie kontenera: (1) Chłodniczy, (2) Na płyny, (3) Na gaz");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Przykładowe wartości
                    var refrigeratedContainer = new RefrigeratedContainer(2000, 250, 400, 20000, "Jabłka", -5);
                    ship.AddContainer(refrigeratedContainer);
                    Console.WriteLine("Dodano kontener chłodniczy.");
                    break;
                case "2":
                    // Przykładowe wartości
                    var liquidContainer = new LiquidContainer(1500, 250, 400, 15000, false);
                    ship.AddContainer(liquidContainer);
                    Console.WriteLine("Dodano kontener na płyny.");
                    break;
                case "3":
                    // Przykładowe wartości
                    var gasContainer = new GasContainer(1800, 250, 400, 18000, 100);
                    ship.AddContainer(gasContainer);
                    Console.WriteLine("Dodano kontener na gaz.");
                    break;
                default:
                    Console.WriteLine("Nieprawidłowy wybór.");
                    break;
            }
        }
        static void LoadContainersList(ContainerShip ship)
        {
            // Przykładowa lista kontenerów
            var containersToAdd = new List<Container>
        {
            new RefrigeratedContainer(2000, 250, 400, 20000, "Jabłka", -5),
            new LiquidContainer(1500, 250, 400, 15000, true)
        };

            ship.LoadContainers(containersToAdd);
            Console.WriteLine("Kontenery zostały załadowane na statek.");
        }

        static void UnloadContainer(ContainerShip ship)
        {
            Console.Write("Podaj numer seryjny kontenera do rozładunku: ");
            var serialNumber = Console.ReadLine();

            ship.UnloadContainer(serialNumber);
            Console.WriteLine($"Kontener {serialNumber} został rozładowany.");
        }

        static void ReplaceContainer(ContainerShip ship)
        {
            Console.Write("Podaj numer seryjny kontenera do zastąpienia: ");
            var oldSerialNumber = Console.ReadLine();

            // Przykładowy nowy kontener
            var newContainer = new GasContainer(1800, 250, 400, 18000, 100);

            ship.ReplaceContainer(oldSerialNumber, newContainer);
            Console.WriteLine($"Kontener {oldSerialNumber} został zastąpiony nowym kontenerem.");
        }

        static void TransferContainerBetweenShips(ContainerShip ship1, ContainerShip ship2)
        {
            Console.Write("Podaj numer seryjny kontenera do przeniesienia: ");
            var serialNumber = Console.ReadLine();

            ship1.TransferContainer(ship2, serialNumber);
            Console.WriteLine($"Kontener {serialNumber} został przeniesiony z jednego statku na drugi.");
        }
        static void RemoveContainer(ContainerShip ship)
        {
            Console.Write("Podaj numer seryjny kontenera do usunięcia: ");
            string serialNumber = Console.ReadLine();
            ship.RemoveContainer(serialNumber);
        }
    }
