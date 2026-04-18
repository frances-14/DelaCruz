using ModelLayer;
using DataLayer;

namespace BusinessLayer
{
    public class Business
    {
        private FlightAppService Service;

        public Business(FlightAppService service)
        {
            Service = service;
        }

        public void AddFlight(string originInput, string destinationInput)
        {
            if (originInput == destinationInput)
            {
                Console.WriteLine("Invalid Input. Origin and Destination cannot be the same.");
                return;
            }

            string[] locations = Service.GetLocations();

            bool originExists = false;
            bool destinationExists = false;

            foreach (string location in locations)
            {
                if (location == originInput)
                    originExists = true;

                if (location == destinationInput)
                    destinationExists = true;
            }

            if (!originExists)
            {
                Console.WriteLine("Invalid Origin. Please check the available locations.");
                return;
            }

            if (!destinationExists)
            {
                Console.WriteLine("Invalid Destination. Please check the available locations.");
                return;
            }

            Flight flight = new Flight
            {
                FlightId = Guid.NewGuid(),
                Origin = originInput,
                Destination = destinationInput
            };

            Service.AddFlight(flight);

            Console.WriteLine("Flight added successfully.");
        }

        public void SearchFlight(string originInput, string destinationInput)
        {
            var flights = Service.GetFlights();

            bool found = false;

            foreach (var flight in flights)
            {
                if (flight.Origin == originInput && flight.Destination == destinationInput)
                {
                    Console.WriteLine($"Flight found: {flight.Origin} to {flight.Destination}");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("No matching flight found. Please check the locations available or check for spelling error.");
            }
        }

        public void UpdateFlight(int index, string newOrigin, string newDestination)
        {

            var flights = Service.GetFlights();

            if (index < 0 || index >= flights.Count)
            {
                Console.WriteLine("Invalid index.");
                return;
            }

            if (newOrigin == newDestination)
            {
                Console.WriteLine("Invalid Input. Origin and Destination cannot be the same.");
                return;
            }

            string[] locations = Service.GetLocations();

            bool originExists = false;
            bool destinationExists = false;

            foreach (string location in locations)
            {
                if (location == newOrigin)
                    originExists = true;

                if (location == newDestination)
                    destinationExists = true;
            }
        

            if (!originExists)
            {
                Console.WriteLine("Invalid Origin. Please check the available locations.");
                return;
            }

            if (!destinationExists)
            {
                Console.WriteLine("Invalid Destination. Please check the available locations.");
                return;
            }

            Service.UpdateFlight(index, newOrigin, newDestination);
            Console.WriteLine("Flight Updated");
        }

        public void DeleteFlight(int index, int totalFlights)
        {
            if (index < 0 || index >= totalFlights)
            {
                Console.WriteLine("Invalid index.");
                return;
            }

            Service.DeleteFlight(index);
            Console.WriteLine("Flight deleted.");
        }

    }
}
