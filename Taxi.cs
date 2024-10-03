namespace Practice1
{
    class Taxi : RegisteredVehicle
    {
        //constant string as TypeOfVehicle wont change allong PoliceCar instances.
        private static string typeOfVehicle = "Taxi";
        private bool isCarryingPassengers;
        private bool isLicensed;

        public Taxi(string plate) : base(typeOfVehicle, plate)
        {
            //Values of atributes are set just when the instance is done if not needed before.
            isCarryingPassengers = false;
            SetSpeed(45.0f);
            isLicensed = true;
        }

        public void SetIsLicensed()
        {
            if (!isLicensed)
            {
                isLicensed = true;
            }             
        }

        public void RemoveLicense()
        {
            if (isLicensed)
            {
                isLicensed = false;
            }
        }

        public void StartRide()
        {
            if (!isLicensed)
            {
                Console.WriteLine(WriteMessage("cannot start a ride because the license has been revoked."));
                return;
            }

            if (!isCarryingPassengers)
            {
                isCarryingPassengers = true;
                SetSpeed(100.0f);
                Console.WriteLine(WriteMessage("starts a ride."));
            }

            else
            {
                Console.WriteLine(WriteMessage("is already in a ride."));
            }
        }

        public void StopRide()
        {
            if (!isLicensed)
            {
                Console.WriteLine(WriteMessage("cannot stop a ride because the license has been revoked."));
                return;
            }

            if (isCarryingPassengers)
            {
                isCarryingPassengers = false;
                SetSpeed(45.0f);
                Console.WriteLine(WriteMessage("finishes ride."));
            }
            else
            {
                Console.WriteLine(WriteMessage("is not on a ride."));
            }
        }
    }
}