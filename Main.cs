namespace Practice1
{
    internal class Program
    {

        static void Main()
        {
            City city = new City("Madrid");
            PoliceStation policeStation = new PoliceStation(1);
            Taxi taxi1 = new Taxi("0001 AAA");
            Taxi taxi2 = new Taxi("0002 BBB");
            PoliceCar policeCar1 = new PoliceCar("0001 CNP", true);
            PoliceCar policeCar2 = new PoliceCar("0002 CNP", false);

            Console.WriteLine(city.WriteMessage("Created"));
            Console.WriteLine(policeStation.WriteMessage("Created"));
            Console.WriteLine(taxi1.WriteMessage("Created"));
            Console.WriteLine(taxi2.WriteMessage("Created"));
            Console.WriteLine(policeCar1.WriteMessage("Created"));
            Console.WriteLine(policeCar2.WriteMessage("Created"));

            city.AddTaxi(taxi1);
            city.AddTaxi(taxi2);
            city.RegisterTaxiLicense(taxi1);
            city.RegisterTaxiLicense(taxi2);

            policeStation.AddPoliceCar(policeCar1);
            policeStation.AddPoliceCar(policeCar2);
            city.AddPoliceStation(policeStation);

            taxi1.StartRide();
            taxi2.StartRide();

            policeCar2.StartPatrolling();
            policeCar2.UseRadar(taxi1, policeStation);
            policeCar1.StartPatrolling();
            policeCar1.UseRadar(taxi2, policeStation);
            policeStation.NotifyPoliceCars(taxi2.GetPlate());
            city.RemoveTaxiLicense(taxi2);
        }
    }
}
