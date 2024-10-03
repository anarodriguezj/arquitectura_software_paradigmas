namespace Practice1
{
    class PoliceCar : RegisteredVehicle
    {
        //constant string as TypeOfVehicle wont change allong PoliceCar instances
        private const string typeOfVehicle = "Police Car";
        private bool isPatrolling;
        private SpeedRadar? speedRadar;
        private bool inPersecution;
        private string? offenderPlate;
        private PoliceStation? station;

        private List<PoliceCar> policeCars = new List<PoliceCar>();

        public PoliceCar(string plate, bool hasRadar = false) : base(typeOfVehicle, plate)
        {
            isPatrolling = false;
            inPersecution = false;
            offenderPlate = null;

            if (hasRadar) // Police Car's radar could be null
            {
                speedRadar = new SpeedRadar();
            }
        }

        public void UseRadar(RegisteredVehicle vehicle, PoliceStation policeStation)
        {
            if (!isPatrolling)
            {
                Console.WriteLine(WriteMessage($"is not patrolling and cannot use the radar."));
                return;
            }
            if (speedRadar != null)
            {
                speedRadar.TriggerRadar(vehicle);
                string measurement = speedRadar.GetLastReading();
                Console.WriteLine(WriteMessage($"Triggered radar. Result: {measurement}"));

                var plate = vehicle.GetPlate();
                var speed = vehicle.GetSpeed();
                if (speed > speedRadar.GetLegalSpeed())
                {
                    StartPersecution(plate);
                    policeStation.ActivateAlarm(offenderPlate);
                }

                // si es un patinete como lo hago? como persigo a algo sin matricula? o no tengo que perseguirlo?
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
            if (speedRadar != null)
            {
                Console.WriteLine(WriteMessage("Report radar speed history:"));
                foreach (float speed in speedRadar.SpeedHistory)
                {
                    Console.WriteLine(speed);
                }
            }
            else
            {
                Console.WriteLine(WriteMessage("There is no radar history in this Police Car."));
            }
        }

        public void StartPersecution(string offenderPlate)
        {
            if (!inPersecution)
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