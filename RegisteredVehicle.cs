namespace Practice1
{
    abstract class RegisteredVehicle : Vehicle
    {
        private string plate;

        public RegisteredVehicle(string typeOfVehicle, string plate) : base(typeOfVehicle) 
        {
            this.plate = plate;
        }

        //Override ToString() method with class information
        public override string ToString()
        {
            return $"{GetTypeOfVehicle()} with plate {GetPlate()}";
        }
        public string GetPlate()
        {
            return plate;
        }
    }
}