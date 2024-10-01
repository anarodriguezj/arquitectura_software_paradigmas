using System.Diagnostics.Tracing;

namespace Practice1
{
    class PoliceCar : Vehicle
    {
        //constant string as TypeOfVehicle wont change allong PoliceCar instances
        private const string typeOfVehicle = "Police Car"; 
        private bool isPatrolling;
        private SpeedRadar speedRadar;
        private bool inPersecution;
        private string? offenderPlate;
        private PoliceStation? station;

        private List<PoliceCar> policeCars = new List<PoliceCar> ();

        public PoliceCar(string plate) : base(typeOfVehicle, plate)
        {
            isPatrolling = false;            
            inPersecution = false;
            offenderPlate = null;
            speedRadar = new SpeedRadar();
        }

        public void UseRadar(Vehicle vehicle)
        {
            if (isPatrolling)
            {
                speedRadar.TriggerRadar(vehicle);
                string meassurement = speedRadar.GetLastReading();                
                Console.WriteLine(WriteMessage($"Triggered radar. Result: {meassurement}"));
                offenderPlate = vehicle.GetPlate();
                StartPersecution(offenderPlate);
            }
            else
            {
                Console.WriteLine(WriteMessage($"has no active radar."));
            }
        }
        

        public void SetPoliceStation(PoliceStation station)
        {
            this.station = station;
        }

        public bool IsPatrolling()
        {
            return isPatrolling;
        }

        public bool InPersecution()
        {
            return inPersecution;
        }

        public void StartPatrolling()
        {
            if (!isPatrolling)
            {
                isPatrolling = true;
                Console.WriteLine(WriteMessage("started patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage("is already patrolling."));
            }
        }

        public void EndPatrolling()
        {
            if (isPatrolling)
            {
                isPatrolling = false;
                Console.WriteLine(WriteMessage("stopped patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage("was not patrolling."));
            }
        }

        public void PrintRadarHistory()
        {
            {
                Console.WriteLine(WriteMessage("Report radar speed history:"));
                foreach (float speed in speedRadar.SpeedHistory)
                {
                    Console.WriteLine(speed);
                }
            }
        }

        public void StartPersecution(string offenderPlate)
        {
            if (!inPersecution && offenderPlate != null)
            {
                inPersecution = true;
                this.offenderPlate = offenderPlate;
                Console.WriteLine(WriteMessage($"started the persecution of vehicle with plate {offenderPlate}."));
            }
            else
            {
                Console.WriteLine(WriteMessage("is already in persecution."));
            }
        }

        public void EndPersecution()
        {
            if (inPersecution)
            {
                inPersecution = false;
                offenderPlate = null;
                Console.WriteLine(WriteMessage("stopped the persecution."));
            }
            else
            {
                Console.WriteLine(WriteMessage("was not in persecution."));
            }
        }
    }
}