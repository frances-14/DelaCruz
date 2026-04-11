using BusinessLayer;
using ModelLayer;
using DataLayer;
using System;

namespace DelaCruz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FlightAppService service = new FlightAppService(new JsonFlightData());
            Business business = new Business(service);
            //menu();


            string choice = "";

            while (choice != "7")
            {
                Console.WriteLine("\n======================================================");
                Console.WriteLine("                Flight Management");
                Console.WriteLine("====================================================== \n");
                Console.WriteLine("Hello User! What would you like to do? ");
                Console.WriteLine("1. Add Flight");
                Console.WriteLine("2. Delete Flight");
                Console.WriteLine("3. Update Flight");
                Console.WriteLine("4. Search Flight");
                Console.WriteLine("5. View Flights");
                Console.WriteLine("6. View Locations");
                Console.WriteLine("7. Exit the Program");

                Console.Write("\nChoose a number from the menu to proceed: ");
                choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Origin: ");
                        string origin = Console.ReadLine().ToUpper();

                        Console.Write("Enter Destination: ");
                        string destination = Console.ReadLine().ToUpper();

                        business.AddFlight(origin, destination);

                        break;

                    case "2":
                        var flights = service.GetFlights();

                        for (int i = 0; i < flights.Count; i++)
                        {
                            Console.WriteLine($"{i}. {flights[i].Origin} to {flights[i].Destination}");
                        }

                        Console.Write("Enter index: ");
                        int index = int.Parse(Console.ReadLine());

                        business.DeleteFlight(index, flights.Count);

                        break;

                    case "3":
                        flights = service.GetFlights();

                        for (int i = 0; i < flights.Count; i++)
                        {
                            Console.WriteLine($"{i}. {flights[i].Origin} to {flights[i].Destination}");
                        }

                        Console.Write("Enter index to update flight: ");
                        int updateIndex = int.Parse(Console.ReadLine());

                        Console.Write("Enter New Origin: ");
                        string newOrigin = Console.ReadLine().ToUpper();

                        Console.Write("Enter New Destination: ");
                        string newDestination = Console.ReadLine().ToUpper();

                        business.UpdateFlight(updateIndex, newOrigin, newDestination);

                        Console.WriteLine("Flight updated successfully.");

                        break;

                    case "4":
                        Console.Write("Search Origin: ");
                        string sOrigin = Console.ReadLine().ToUpper();

                        Console.Write("Search Destination: ");
                        string sDestination = Console.ReadLine().ToUpper();

                        business.SearchFlight(sOrigin, sDestination);

                        break;

                    case "5":
                         flights = service.GetFlights();

                        foreach (var f in flights)
                        {
                            Console.WriteLine($"{f.Origin} to {f.Destination}");
                        }

                        break;

                    case "6":
                        menu();
                        break;

                }
            }

        }

        static void menu()
        {
            Console.WriteLine("Flight Management");
            Console.WriteLine("                                      Locations                                          ");
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.WriteLine(          "           Manila           |        Bacolod         |         Bohol\n" +
                                         "           Boracay          |        Butuan          |         Cagayan De Oro\n" +
                                         "           Calbayog         |        Camiguin        |         Cauayan\n" +
                                         "           Cebu             |        Clark           |        Coron\n" +
                                         "           Cotabato         |        Davao           |        Dipolog\n" +
                                         "           Dumaguete        |        Iloilo          |        General Santos\n" +
                                         "           Kalibo           |        Laoag           |        Legazpi\n" +
                                         "           Masbate          |        Naga            |        Ozamiz\n" +
                                         "           Pagadian         |        Puerto Princesa |        Roxas\n" +
                                         "           San Jose         |        Siargao         |        Surigao\n" +
                                         "           Tacloban         |        Tawi-Tawi       |        Tuguegarao\n" +
                                         "           Virac            |        Zamboanga       |");

            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.WriteLine("\n  ");
        }
    }

   
}