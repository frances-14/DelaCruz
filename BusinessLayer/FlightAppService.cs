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
    }
}
