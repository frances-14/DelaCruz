using System;

namespace DelaCruz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            business bl = new business();
            menu();

            string repeat = "";
            while (repeat != "N")
            {
                Console.Write("\nEnter Origin Place: ");
                string originInput = Console.ReadLine().ToUpper();

                Console.Write("Enter Destination Place: ");
                string destiInput = Console.ReadLine().ToUpper();

                bl.searchFlight(originInput, destiInput);

                Console.Write("\nWould you like to search again? (Y/N): ");
                repeat = Console.ReadLine().ToUpper();

            }

            Console.WriteLine("You have exited the program.");

        }

        static void menu()
        {
            Console.WriteLine("Flight Management\n");

            Console.WriteLine("Locations \nManila     |   Bacolod    |    Bohol\n" +
                                          "Boracay    |   Butuan     |    Cagayan De Oro\n" +
                                          "Calbayog   |   Camiguin   |    Cauayan\n" +
                                          "Cebu       |   Coron      |    Davao\n" +
                                          "Dipolog    |   Iloilo     |    Kalibo\n" +
                                          "Laoag      |   Legazpi    |    Masbate\n");
        }
    }

    class business
    {
        dataLogic data = new dataLogic();

        public void searchFlight(string originInput, string destiInput)
        {
            modelLayer model = new modelLayer(originInput, destiInput);

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

        public void flightExists(modelLayer model, bool originExist, bool destinationExist)
        {

            string repeat = "";
            while (repeat != "N")
            {
                if (originExist && destinationExist)
                {
                    Console.WriteLine("\nThe Flight from " + model.origin + " to " + model.destination + " is Available.");
                    Console.WriteLine("Would you like to book this flight? (Y/N)");
                    string bookFlight = Console.ReadLine().ToUpper();

                    if (bookFlight == "Y")
                    {
                        Console.WriteLine("You have successfully booked the flight from " + model.origin + " to " + model.destination + ".");
                    }
                    else if (bookFlight == "N")
                    {
                        Console.WriteLine("No flight was booked.");
                    }
                    else
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

    class dataLogic
    {

        public string[] Locations = { "MANILA", "BACOLOD", "BOHOL", "BORACAY", "BUTUAN", "CAGAYAN DE ORO", "CALBAYOG", "CAMIGUIN", "CAUAYAN", "CEBU", "CORON", "DAVAO", "DIPOLOG", "ILOILO", "KALIBO", "LAOAG", "LEGAZPI", "MASBATE" };


        public string[] getLocations()
        {
            return Locations;
        }
    }

    class modelLayer
    {
        public string origin;
        public string destination;

        public modelLayer(string orig, string desti)
        {
            origin = orig;
            destination = desti;
        }
    }
}