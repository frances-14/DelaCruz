
using DataLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class FlightAppService
    {
        IFlightDataService flightDataService;

        public FlightAppService(IFlightDataService dataService)
        {
            flightDataService = dataService;
        }

        public void AddFlight(Flight flight)
        {
            flightDataService.Add(flight);
        }

        public List<Flight> GetFlights()
        {
            return flightDataService.GetFlights() ?? new List<Flight>();
        }

        public Flight GetFlight(Guid id)
        {
            var flights = flightDataService.GetFlights();

            foreach (Flight flight in flights)
            {
                if (flight.FlightId == id)
                {
                    return flight;
                }
            }

            return null;
        }

        public void DeleteFlight(int index)
        {
            flightDataService.Delete(index);
        }

        public bool RemoveFlight(Guid id)
        {
            var flights = flightDataService.GetFlights();

            for (int i = 0; i < flights.Count; i++)
            {
                if (flights[i].FlightId == id)
                {
                    flightDataService.Delete(i);
                    return true;
                }
            }

            return false;
        }


        public void UpdateFlight(int index, string newOrigin, string newDestination)
        {
            flightDataService.Update(index, newOrigin, newDestination);
        }

        public bool UpdateFlight(Guid id, string newOrigin, string newDestination)
        {
            var flights = flightDataService.GetFlights();

            for (int i = 0; i < flights.Count; i++)
            {
                if (flights[i].FlightId == id)
                {
                    flightDataService.Update(i, newOrigin, newDestination);

                    return true;
                }
            }

            return false;
        }

        public List<Flight> SearchFlight(string origin, string destination)
        {
            var flights = flightDataService.GetFlights();

            List<Flight> results = new List<Flight>();

            foreach (Flight flight in flights)
            {
                if (flight.Origin == origin &&
                    flight.Destination == destination)
                {
                    results.Add(flight);
                }
            }
            return results;
        }

        public string[] GetLocations()
        {
            return flightDataService.GetLocations();
        }

    }
}
