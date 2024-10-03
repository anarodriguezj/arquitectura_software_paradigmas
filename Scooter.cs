using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    internal class Scooter : UnregisteredVehicle
    {
        private static string typeOfVehicle = "Scooter";

        public Scooter(string? plate) : base(typeOfVehicle)
        {

        }


    }
}
