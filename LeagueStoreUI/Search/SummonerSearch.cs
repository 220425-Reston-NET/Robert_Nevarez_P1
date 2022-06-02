using Summoner;
using LeagueStoreBL;
using Serilog;
using System.ComponentModel.DataAnnotations;

namespace LeagueStoreUI
{

    public class SummonerSearch : ILeague
    { 
        private SummonerInfo _username = new SummonerInfo();
        //============================================================//
        private ILeagueStoreBL <SummonerInfo> _LeagueStoreBL;
        public SummonerSearch(ILeagueStoreBL<SummonerInfo> p_LeagueStoreBL)
        {
            _LeagueStoreBL = p_LeagueStoreBL;
        }
        
        //============================================================//
        public void Display()
        {
            Console.Clear();
            Console.WriteLine("=======Welcome to Summoner Profile Search!=======");
            Console.WriteLine("It's great having you here! To get started what is your full Summoner name?");
            try
            {
                _username.Name = Console.ReadLine();
            }
            catch (System.ComponentModel.DataAnnotations.ValidationException)
            {
                
                Log.Warning("User did not make a 5 character username!");
                Console.WriteLine("Your Summoner Name must be 5 charcters or more!");
                Console.WriteLine("Please update your summoner information");
                Console.WriteLine("Press any key to continue");
                Console.ReadLine();

            }
            
            Console.WriteLine("===============================================================");
            Console.WriteLine("Great! Welcome " + _username.Name +"! What is your phone number?");
            try
            {
                _username.Phonenumber = Convert.ToDouble(Console.ReadLine());
            }
            catch (System.FormatException)
            {
                Log.Warning("User tried putting none digits!");
                Log.Information(_username.Phonenumber.ToString());

                Console.WriteLine("Your phone number must only include numbers!");
                Console.WriteLine("Please update your summoner information");
                Console.WriteLine("Press any key to continue");
                Console.ReadLine();
                // Console.WriteLine("Press Any button to start again");
                // Console.ReadLine();
                // if (_username.Phonenumber == 1000000001)
                // {
                //     return "SummonerSearch";
                // }  
            }
            catch (System.ComponentModel.DataAnnotations.ValidationException)
            {
                Log.Warning("User did not put 10 digits!");
                Log.Information(_username.Phonenumber.ToString());

                Console.WriteLine("Your Phone Number must be 10 digits!");
                Console.WriteLine("Please update your summoner information");
                Console.WriteLine("Press any key to continue");
                Console.ReadLine();
            }
            Console.WriteLine("=====================================================================================");
            Console.WriteLine("Your phone number is " + _username.Phonenumber + " Last thing we need is your address");
            _username.Address = Console.ReadLine();
            Console.WriteLine("=======================================================================");
            Console.WriteLine("Your address is " + _username.Address + " Welcome to the rift summoner!");
            Console.WriteLine("[1] - Add Summoner Profile");
            Console.WriteLine("[0] - Back to Main Menu");
        }
        public string YourChoice()
        {
            string UserInput = Console.ReadLine();

            if (UserInput == "1")
            {
                SummonerInfo FoundedSummoner = _LeagueStoreBL.Search(_username.Name);
                if (FoundedSummoner == null)
                {   
                    Log.Information("User made a new account");
                    Console.Clear();
                    Console.WriteLine("==================================================================================");
                    Console.WriteLine ("You do not have an account with us. We will add your information for future shops");
                    _LeagueStoreBL.Add(_username);
                    Console.WriteLine ("Press any key to continue");
                    Console.ReadLine();
                }
                else
                {
                    Log.Information("User signed in back into their account");
                    Console.Clear();
                    Console.WriteLine("=================================================================");
                    Console.WriteLine("You have an account with us! Welcome back " + _username.Name + "!");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadLine();
                }
                return "StoreSelection";
            }
            else if (UserInput == "0")
            {
                return "MainMenu";
            }
            else
            {
               Console.WriteLine("Please Enter a valid response");
               Console.WriteLine("Press any key to redo Summoner Search");
               Console.ReadLine();
               return "SummonerSearch"; 
            }
        }
        
    }

}
