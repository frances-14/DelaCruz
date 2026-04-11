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

        public void DeleteFlight(int index)
        {
            flightDataService.Delete(index);
        }

        public void UpdateFlight(int index, string newOrigin, string newDestination)
        {
            flightDataService.Update(index, newOrigin, newDestination);
        }

        public void SearchFlight(string origin, string destination)
        {
            var flights = flightDataService.GetFlights();

            var result = flights.Where(f => f.Origin == origin && f.Destination == destination).ToList();

            if (result.Count == 0)
            {
                Console.WriteLine("No flights found.");
            }
            else
            {
                Console.WriteLine("Flights found:");
                foreach (var f in result)
                {
                    Console.WriteLine($"{f.Origin} to {f.Destination}");
                }
            }
        }

        public string[] GetLocations()
        {
            return flightDataService.GetLocations();
        }

    }
}
