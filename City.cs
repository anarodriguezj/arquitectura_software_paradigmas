using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    internal class City : IMessageWritter
    {
        private string name;
        public List<PoliceStation> PoliceStationsList { get; private set; }
        public List<Taxi> TaxisList { get; private set; }

        public City(string name)
        {
            this.name = name;
            PoliceStationsList = new List<PoliceStation>();
            TaxisList = new List<Taxi>();
        }

        public override string ToString()
        {
            return $"City named {GetName()}";
        }

        public string GetName()
        {
            return name;
        }

        public void AddPoliceStation(PoliceStation policeStation)
        {
            if (!PoliceStationsList.Contains(policeStation))
            {
                PoliceStationsList.Add(policeStation);
                Console.WriteLine(WriteMessage($"Police station {policeStation.GetId()} has been added to {name}."));
            }
            else
            {
                Console.WriteLine(WriteMessage($"Police station {policeStation.GetId()} is already registered."));
            }
        }

        public void AddTaxi(Taxi taxi)
        {
            if (!TaxisList.Contains(taxi))
            {
                TaxisList.Add(taxi);
                Console.WriteLine(WriteMessage($"Taxi with plate {taxi.GetPlate()} has been added to {name}."));
            }
            else
            {
                Console.WriteLine(WriteMessage($"Taxi with plate {taxi.GetPlate()} is already registered."));
            }
        }

        public void RemoveTaxi(Taxi taxi)
        {
            if (TaxisList.Contains(taxi))
            {
                TaxisList.Remove(taxi);
                Console.WriteLine(WriteMessage($"Taxi with plate {taxi.GetPlate()} has been removed from {name}."));
            }
            else
            {
                Console.WriteLine(WriteMessage($"Taxi with plate {taxi.GetPlate()} is not registered."));
            }
        }

        public string WriteMessage(string message)
        {
            return $"{this}: {message}";
        }
    }
}
