using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    abstract class UnregisteredVehicle : Vehicle // vehicle with no plate
    {
        private string typeOfVehicle;

        public UnregisteredVehicle(string typeOfVehicle) : base(typeOfVehicle) 
        {
            this.typeOfVehicle = typeOfVehicle;
        }

        //Override ToString() method with class information
        public override string ToString()
        {
            return $"{GetTypeOfVehicle()}";
        }
    }
}
