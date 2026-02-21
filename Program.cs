namespace DelaCruz
{
    internal class Program
    {
        static void Main(string[] args)
        {


            List<String> origin = new List<String>();

            origin.Add("Manila");
            origin.Add("Manila");
            origin.Add("Bacolod");
            origin.Add("Bohol");
            origin.Add("Boracay");
            origin.Add("Butuan");
            origin.Add("Cagayan de Oro");
            origin.Add("Calbayog");
            origin.Add("Camiguin");
            origin.Add("Cauayan");

            List<String> desti = new List<String>();

            desti.Add("Manila");
            desti.Add("Bacolod");
            desti.Add("Bohol");
            desti.Add("Boracay");
            desti.Add("Butuan");
            desti.Add("Cagayan de Oro");
            desti.Add("Calbayog");
            desti.Add("Camiguin");
            desti.Add("Cauayan");

            Console.WriteLine("Flight Management\n");

            Console.WriteLine("Locations \nManila   |       ");

            Console.WriteLine("Enter Origin Place: ");
            string origininput = Console.ReadLine();

            Console.WriteLine("Enter Destination Place: ");
            string destiInput = Console.ReadLine();
        }
    }
}
