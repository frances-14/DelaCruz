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

        public bool AddFlight(string originInput, string destinationInput)
        {
            if (originInput == destinationInput)
            {
                return false;
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
                return false;
            }

            if (!destinationExists)
            {
                return false;
            }

            Flight flight = new Flight
            {
                FlightId = Guid.NewGuid(),
                Origin = originInput,
                Destination = destinationInput
            };

            Service.AddFlight(flight);
            return true;
        }

        public List<Flight> SearchFlight(string originInput, string destinationInput)
        {
            var flights = Service.GetFlights();

            List<Flight> results = new List<Flight>();

            foreach (Flight flight in flights)
            {
                if (flight.Origin == originInput &&
                    flight.Destination == destinationInput)
                {
                    results.Add(flight);
                }
            }

            return results;
        }

        public bool UpdateFlight(int index, string newOrigin, string newDestination)
        {

            var flights = Service.GetFlights();

            if (index < 0 || index >= flights.Count)
            {
                return false;
            }

            if (newOrigin == newDestination)
            {
                return false;
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
                return false;
            }

            if (!destinationExists)
            {
                return false;
            }

            Service.UpdateFlight(index, newOrigin, newDestination);
            return true;
        }

        public bool DeleteFlight(int index, int totalFlights)
        {
            if (index < 0 || index >= totalFlights)
            {
                return false;
            }

            Service.DeleteFlight(index);
            return true;
        }

    }
}