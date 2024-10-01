using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    internal class PoliceStation : IMessageWritter
    {
        private int id;
        private bool activeAlarm;
        public List<PoliceCar> PoliceCarsList { get; private set; }

        public PoliceStation(int id)
        {
            this.id = id;
            activeAlarm = false;
            PoliceCarsList = new List<PoliceCar>();
        }

        public override string ToString()
        {
            return $"Police Station with ID {GetId()}";
        }

        public int GetId()
        {
            return id;
        }

        public void AddPoliceCar(PoliceCar policeCar)
        {
            if (!PoliceCarsList.Contains(policeCar))
            {
                PoliceCarsList.Add(policeCar);
                policeCar.SetPoliceStation(this);
                Console.WriteLine(WriteMessage($"Police Car with plate {policeCar.GetPlate()} has been registered."));
            }
            else
            {
                Console.WriteLine(policeCar.WriteMessage($"Police Car with plate {policeCar.GetPlate()} is already registered."));
            }
        }

        public void ActivateAlarm(string offenderPlate)
        {
            if (!activeAlarm)
            {
                activeAlarm = true;
                Console.WriteLine(WriteMessage($"The alarm has been activated. Plate of the offender vehicle: {offenderPlate}"));
                NotifyPoliceCars(offenderPlate);
            }
            else
            {
                Console.WriteLine(WriteMessage("The alarm is already active."));
            }
        }

        public void NotifyPoliceCars(string offenderPlate)
        {
            foreach (var policeCar in PoliceCarsList)
            {
                if (policeCar.IsPatrolling() && !policeCar.InPersecution())
                {
                    policeCar.StartPersecution(offenderPlate); // all police cars will start the persecution of the offending car
                }
            }
        }

        public string WriteMessage(string message)
        {
            return $"{this}: {message}";
        }
    }
}
