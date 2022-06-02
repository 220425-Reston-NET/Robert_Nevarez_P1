

using LeagueStoreBL;
using Summoner;

namespace LeagueStoreUI
{
    public class UpdateInfo : ILeague
    {
        private SummonerInfo _username = new SummonerInfo();
        private ILeagueStoreBL <SummonerInfo> _LeagueStoreBL;
        public UpdateInfo(ILeagueStoreBL<SummonerInfo> p_LeagueStoreBL)
        {
            _LeagueStoreBL = p_LeagueStoreBL;
        }
        public void Display()
        {
            Console.WriteLine ("=======Welcome to Profile Update Menu=======");
            Console.WriteLine ("Please choose what you want to update");
            Console.WriteLine ("[3] - Update Summoner Name");
            Console.WriteLine ("[2] - Update Phone Number");
            Console.WriteLine ("[1] - Update Address");
            Console.WriteLine ("[0] - Go to Main Menu");
        }

        public string YourChoice()
        {
            string UserInput = Console.ReadLine();

            if (UserInput == "3")
            {
                Console.WriteLine("Please Write your new Summoner Name");
                _username.Name = Console.ReadLine();

                

                _LeagueStoreBL.Update(_username);
                Console.WriteLine("Summoner Name has been updates");
                Console.WriteLine("Press any key to be returned to Profile Update Menu");
                Console.ReadLine();
                return "UpdateProfile";
            }  
            else
            {
                return "MainMenu";
            }
        }
    }
}