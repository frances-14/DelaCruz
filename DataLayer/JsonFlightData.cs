using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ModelLayer;

namespace DataLayer
{
    public class JsonFlightData : IFlightDataService
    {
        private List<Flight> flights = new List<Flight>();

        private string _jsonFileName;

        public JsonFlightData()
        {
            _jsonFileName = $"{AppDomain.CurrentDomain.BaseDirectory}/Flights.json";

            PopulateJsonFile();
        }

        private void PopulateJsonFile()
        {
            RetrieveDataFromJsonFile();

            if (flights.Count <= 0)
            {
                flights.Add(new Flight { FlightId = Guid.NewGuid(), Origin = "MANILA", Destination = "CEBU" });
                flights.Add(new Flight { FlightId = Guid.NewGuid(), Origin = "DAVAO", Destination = "ILOILO" });

                SaveDataToJsonFile();
            }
        }

        private void SaveDataToJsonFile()
        {
            using (var outputStream = File.OpenWrite(_jsonFileName))
            {
                JsonSerializer.Serialize<List<Flight>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    { SkipValidation = true, Indented = true })
                    , flights);
            }
        }

        private void RetrieveDataFromJsonFile()
        {
            if (!File.Exists(_jsonFileName))
            {
                flights = new List<Flight>();
                return;
            }

            using (var jsonFileReader = File.OpenText(_jsonFileName))
            {
                flights = JsonSerializer.Deserialize<List<Flight>>(
                    jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    { PropertyNameCaseInsensitive = true }) ?? new List<Flight>();
            }
        }

        public void Add(Flight flight)
        {
            RetrieveDataFromJsonFile();
            flights.Add(flight);
            SaveDataToJsonFile();
        }

        public List<Flight> GetFlights()
        {
            RetrieveDataFromJsonFile();
            return flights;
        }

        public void Delete(int index)
        {
            RetrieveDataFromJsonFile();

            if (index >= 0 && index < flights.Count)
            {
                flights.RemoveAt(index);
                SaveDataToJsonFile();
            }
        }
    }
}
