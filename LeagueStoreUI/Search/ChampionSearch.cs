using LeagueStoreBL;
using Summoner;
using Serilog;

public class SearchChampion : ILeague
{
    public static ChampionInfo Founded;

    //==============================================================================================
        private ILeagueStoreBL <ChampionInfo> _found;
        private IRPBL _foundRP;
        public SearchChampion(ILeagueStoreBL<ChampionInfo> p_found, IRPBL p_foundRP)
        {
            _found = p_found;
            _foundRP = p_foundRP;
        }
    //=============================================================================================


    public void Display()
    {
        Console.WriteLine("=======Search Champion Menu=======");
        Console.WriteLine("How would you like to search your Champion?");
        Console.WriteLine("[2] - Search by Champion Name");
        Console.WriteLine("[1] - Search by RP Price");
        Console.WriteLine("[0] - Exit");
    }

    public string YourChoice()
    {
        string UserInput = Console.ReadLine();

        if (UserInput == "2")
        {   
            Log.Information("User wants to search champion by name");
            Console.WriteLine("Enter a Champion Name: ");
            string ChampionName = Console.ReadLine();

            Log.Warning("User tried to search champion " + ChampionName);
            Founded = _found.Search(ChampionName);

            if (Founded == null)
            {
                Console.Clear();
                Console.WriteLine("Champion was not found!");
                Console.WriteLine("Press any key to go back");
                Console.ReadLine();
                return "SearchChampion";
            }
            else
            {
                Console.Clear();
                Console.WriteLine (Founded.ToString());
                Console.WriteLine("Press any key to go back to Main Menu");
                Console.ReadLine();
                return "MainMenu";
            }
        }
        else if (UserInput == "1")
        {
            
            Console.Clear();
            Console.WriteLine ("Please Select which price range you want to see");
            Console.WriteLine ("[3] - 200RP");
            Console.WriteLine ("[2] - 400RP");
            Console.WriteLine ("[1] - 600RP");
            Console.WriteLine ("[0] - Back");
            string ChampionRP = Console.ReadLine(); 
            
            if (ChampionRP == "3")
            {
                int RP = 200;
                List<ChampionInfo> Founded = _foundRP.SearchByRP(RP);
            
                Console.Clear();
                foreach(ChampionInfo RPI in Founded)
                {
                    Console.WriteLine(RPI);
                    Console.WriteLine("Press any key to go back to the Main Menu");
                    Console.ReadLine();
                }
                
            }
            else if (ChampionRP == "2")
            {
                int RP = 400;
                List<ChampionInfo> Founded = _foundRP.SearchByRP(RP);
                Console.Clear();
                foreach(ChampionInfo RPI in Founded)
                {
                    Console.WriteLine(RPI);
                    Console.WriteLine("Press any key to go back to the Main Menu");
                    Console.ReadLine();
                }
            }
            else if (ChampionRP == "1")
            {
                int RP = 600;
                List<ChampionInfo> Founded = _foundRP.SearchByRP(RP);
                Console.Clear();
                foreach(ChampionInfo RPI in Founded)
                {
                    Console.WriteLine(RPI);
                    Console.WriteLine("Press any key to go back to the Main Menu");
                    Console.ReadLine();
                }
            }
            else if (ChampionRP == "0")
            {
                return "SearchChampion";
            }
            else
            {
                Console.WriteLine ("Please enter a valid input");
                Console.WriteLine ("Press any key to go back to Champion Search");
                Console.ReadLine();
                Console.Clear();
                return "ChampionSearch";
            }

            return "MainMenu";
        }
        else if(UserInput == "0")
        {
            return "MainMenu";
        }
        else
        {
            Console.WriteLine("Please enter a valid response");
            return "SearchChampion";
        }
    }
}