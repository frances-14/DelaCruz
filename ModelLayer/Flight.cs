using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Flight
    {
        public Guid FlightId { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
    }
}
