using System;

namespace DelaCruz
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] originLocation = { "MANILA", "BACOLOD", "BOHOL", "BORACAY", "BUTUAN", "CAGAYAN DE ORO", "CALBAYOG", "CAMIGUIN", "CAUAYAN", "CEBU", "CORON", "DAVAO", "DIPOLOG", "ILOILO", "KALIBO", "LAOAG", "LEGAZPI", "MASBATE" };
            string[] destinationLocation = { "MANILA", "BACOLOD", "BOHOL", "BORACAY", "BUTUAN", "CAGAYAN DE ORO", "CALBAYOG", "CAMIGUIN", "CAUAYAN", "CEBU", "CORON", "DAVAO", "DIPOLOG", "ILOILO", "KALIBO", "LAOAG", "LEGAZPI", "MASBATE" };

            int originSize = originLocation.Length;
            int destinationSize = destinationLocation.Length;

            bool originExist = false;
            bool destinationExist = false;

            Console.WriteLine("Flight Management\n");

            Console.WriteLine("Locations \nManila     |   Bacolod    |    Bohol\n" +
                                          "Boracay    |   Butuan     |    Cagayan De Oro\n" +
                                          "Calbayog   |   Camiguin   |    Cauayan\n" +
                                          "Cebu       |   Coron      |    Davao\n" +
                                          "Dipolog    |   Iloilo     |    Kalibo\n" +
                                          "Laoag      |   Legazpi    |    Masbate\n");

            Console.Write("\nEnter Origin Place: ");
            string originInput = Console.ReadLine().ToUpper();

            Console.Write("Enter Destination Place: ");
            string destiInput = Console.ReadLine().ToUpper();

            foreach (string origin in originLocation)
            {
                if (origin == originInput)
                {
                    originExist = true;
                    break;
                }
            }

            foreach (string desti in destinationLocation)
            {
                if (desti == destiInput)
                {
                    destinationExist = true;
                    break;
                }
            }

            if (originInput == destiInput)
            {
                Console.WriteLine("\nThe Flight does not Exist.");
            }
            else if (originExist && destinationExist)
            {
                Console.WriteLine("\nThe Flight from " + originInput + " to " + destiInput + " is Available.");
            }
            else
            {
                Console.WriteLine("\nThe Flight does not Exist");
            }
        }
    }
}
