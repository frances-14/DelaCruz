using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;

namespace DataLayer
{
    public class FlightDBData : IFlightDataService
    {
        private string connectionString =
        "Data Source=AimEmpowered\\SQLEXPRESS;Initial Catalog=FlightDB;Integrated Security=True;TrustServerCertificate=True;";

        private SqlConnection sqlConnection;

        public FlightDBData()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public void Add(Flight flight)
        {
            var insertStatement = "INSERT INTO Flights VALUES (@FlightId, @Origin, @Destination)";

            SqlCommand command = new SqlCommand(insertStatement, sqlConnection);

            command.Parameters.AddWithValue("@FlightId", flight.FlightId);
            command.Parameters.AddWithValue("@Origin", flight.Origin);
            command.Parameters.AddWithValue("@Destination", flight.Destination);

            sqlConnection.Open();
            command.ExecuteNonQuery();
            sqlConnection.Close();

        }

        public List<Flight> GetFlights()
        {
            string selectStatement = "SELECT FlightId,Origin, Destination FROM Flights";

            SqlCommand command = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<Flight> flights = new List<Flight>();

            while (reader.Read())
            {
                Flight flight = new Flight();

                flight.FlightId = Guid.Parse(reader["FlightId"].ToString());
                flight.Origin = reader["Origin"].ToString();
                flight.Destination = reader["Destination"].ToString();

                flights.Add(flight);
            }

            sqlConnection.Close();

            return flights;
        }

        public void Delete(int index)
        {
            var flights = GetFlights();

            if (index >= 0 && index < flights.Count)
            {
                var flight = flights[index];

                string deleteStatement = "DELETE FROM Flights WHERE FlightId = @FlightId";

                SqlCommand command = new SqlCommand(deleteStatement, sqlConnection);
                command.Parameters.AddWithValue("@FlightId", flight.FlightId);

                sqlConnection.Open();
                command.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        public void Update(int index, string newOrigin, string newDestination)
        {
            var flights = GetFlights();

            if (index >= 0 && index < flights.Count)
            {
                var flight = flights[index];
                string updateStatement = "UPDATE Flights SET Origin = @Origin, Destination = @Destination WHERE FlightId = @FlightId";

                SqlCommand command = new SqlCommand(updateStatement, sqlConnection);
                command.Parameters.AddWithValue("@Origin",newOrigin);
                command.Parameters.AddWithValue("@Destination" , newDestination);
                command.Parameters.AddWithValue("@FlightId",  flight.FlightId);

                sqlConnection.Open();
                command.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        public string[] GetLocations()
        {
            return new string[]{"MANILA", "BACOLOD", "BOHOL", "BORACAY", "BUTUAN", "CAGAYAN DE ORO", "CALBAYOG", "CAMIGUIN", "CAUAYAN", "CEBU", "CLARK", "CORON", "COTABATO", "DAVAO", "DIPOLOG", "DUMAGUETE", "ILOILO",
             "GENERAL SANTOS", "KALIBO", "LAOAG", "LEGAZPI", "MASBATE", "NAGA", "OZAMIZ", "PAGADIAN", "PUERTO PRINCESA", "ROXAS", "SAN JOSE", "SIARGAO", "SURIGAO", "TACLOBAN", "TAWI-TAWI", "TUGUEGARAO", "VIRAC", "ZAMBOANGA"
            };
        }
    }
}
