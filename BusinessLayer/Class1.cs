using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;
using ModelLayer;
using DataLayer;

namespace BusinessLayer
{
    public class Business
    {
        DataLayer.DataLayer data = new DataLayer.DataLayer();

        public void searchFlight(string originInput, string destiInput)
        {
            Model model = new Model(originInput, destiInput);

            bool originExist = false;
            bool destinationExist = false;

            if (originInput == destiInput)
            {
                Console.WriteLine("\nInvalid Input. You cannot have the same Origin and Destination.");
                return;
            }

            string[] locations = data.getLocations();

            foreach (string location in locations)
            {
                if (location == originInput)
                {
                    originExist = true;
                    break;
                }
            }

            foreach (string location in locations)
            {
                if (location == destiInput)
                {
                    destinationExist = true;
                    break;
                }
            }
            flightExists(model, originExist, destinationExist);

        }

        public void flightExists(Model model, bool originExist, bool destinationExist)
        {

                if (originExist && destinationExist)
                {
                    Console.WriteLine("\nThe Flight from " + model.origin + " to " + model.destination + " is Available.");
                    Console.WriteLine("Would you like to book this flight? (Y/N)");
                    string bookFlight = Console.ReadLine().ToUpper();

                    if (bookFlight == "Y")
                    {
                    FlightAppService service = new FlightAppService(new JsonFlightData());

                    service.AddFlight(new Flight
                    {
                        FlightId = Guid.NewGuid(),
                        Origin = model.origin,
                        Destination = model.destination
                    });
                    Console.WriteLine("You have successfully booked the flight from " + model.origin + " to " + model.destination + ".");
                        
                    }

                    if (bookFlight == "N")
                    {
                        Console.WriteLine("No flight was booked.");
                        return;
                }

                    if (bookFlight != "N" && bookFlight != "Y")
                {
                        Console.WriteLine("Invalid Input. Please enter Y or N.");
                    }
                }
                else
                {
                    Console.WriteLine("\nThe Flight does not Exist");

                }


            }

    }
}
