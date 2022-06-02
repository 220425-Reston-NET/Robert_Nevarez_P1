namespace LeagueStoreUI
{
    public class MainMenu : ILeague
    {
        public void Display()
        {
            Console.WriteLine("========Welcome to the League Of Legends Store!=======");
            Console.WriteLine("Summoner what would you like to do today?");
            Console.WriteLine("[4] Buy champion");
            Console.WriteLine("[3] Search Champion");
            Console.WriteLine("[2] Search Summoner Profile");
            Console.WriteLine("[1] Admin Menu");
            Console.WriteLine("[0] Exit");
            
        }
        public string YourChoice()
        {
            string UserInput = Console.ReadLine();

            if (UserInput == "4")
            {
               
                return "SummonerSearch";
            }

             else if (UserInput == "3")
            
            {
                return "SearchChampion";
            }
            else if (UserInput == "2")
            {
                return "SummonerProfile";
            }
            else if (UserInput == "1")
            {
                return "AdminMenu";
            }
            else if (UserInput == "0")
            {
                return "Exit";
            }
            else
            {
                Console.WriteLine("Please enter a valid response");
                return "MainMenu";
            }  
        }
        
     }
}
            
 
