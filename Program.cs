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
            //menu();

            string choice = "";

            while (choice != "4")
            {
                Console.WriteLine("\nFlight Management");
                Console.WriteLine("1. Add a Flight");
                Console.WriteLine("2. View Booked Flights");
                Console.WriteLine("3. Delete a Flight");
                Console.WriteLine("4. Exit the Program");

                Console.Write("Please select a number from the menu: ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Origin: ");
                        string origin = Console.ReadLine().ToUpper();

                        Console.Write("Enter Destination: ");
                        string destination = Console.ReadLine().ToUpper();

                        service.AddFlight(new Flight
                        {
                            FlightId = Guid.NewGuid(),
                            Origin = origin,
                            Destination = destination
                        });

                        break;

                    case "2":
                        var flights = service.GetFlights();

                        for (int i = 0; i < flights.Count; i++)
                        {
                            Console.WriteLine($"{i}. {flights[i].Origin} to {flights[i].Destination}");
                        }

                        break;

                    case "3":
                        flights = service.GetFlights();

                        for (int i = 0; i < flights.Count; i++)
                        {
                            Console.WriteLine($"{i}. {flights[i].Origin} → {flights[i].Destination}");
                        }

                        Console.Write("Enter index: ");
                        int index = int.Parse(Console.ReadLine());

                        service.DeleteFlight(index);

                        break;
                }
            }

        }

        static void menu()
        {
            Console.WriteLine("Flight Management\n");

            Console.WriteLine("Locations \nManila     |   Bacolod    |    Bohol\n" +
                                          "Boracay    |   Butuan     |    Cagayan De Oro\n" +
                                          "Calbayog   |   Camiguin   |    Cauayan\n" +
                                          "Cebu       |   Coron      |    Davao\n" +
                                          "Dipolog    |   Iloilo     |    Kalibo\n" +
                                          "Laoag      |   Legazpi    |    Masbate\n");
        }
    }

   
}