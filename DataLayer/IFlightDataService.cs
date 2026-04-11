using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;

namespace DataLayer
{
    public  interface IFlightDataService

    {
        void Add(Flight flight);
        List<Flight> GetFlights();
        void Delete(int index);
        void Update(int index, string newOrigin, string newDestination);
        string[] GetLocations();
    }
}
