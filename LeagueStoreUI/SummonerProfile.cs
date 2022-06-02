using Summoner;
using LeagueStoreBL;
using Serilog;

namespace LeagueStoreUI
{
    public class SummonerProfile : ILeague
    {
        private SummonerInfo _username = new SummonerInfo();
        //============================================================//
        private ILeagueStoreBL <SummonerInfo> _LeagueStoreBL;
        public SummonerProfile(ILeagueStoreBL<SummonerInfo> p_LeagueStoreBL)
        {
            _LeagueStoreBL = p_LeagueStoreBL;
        }
       
        public void Display()
        {
            Console.Clear();
            Console.WriteLine("=======Summoner Profile Menu =======");
            Console.WriteLine("Please type your Summoner Name to find your account");
        }

        public string YourChoice()
        {
            string SummonerName = Console.ReadLine();
            
            Log.Warning("User tried to search " + SummonerName );
            SummonerInfo FoundedSummoner = _LeagueStoreBL.Search(SummonerName);
            // double Sum1 = Convert.ToDouble(FoundedSummoner);
            if (FoundedSummoner == null)
                {   
                    Log.Warning("User did not find account!");

                    Console.WriteLine("==================================================================================");
                    Console.WriteLine("You do not have an account with us");
                    Console.WriteLine("Please create an account by selecting 'Buy Champions' in the Main Menu");
                    Console.WriteLine ("Press any key to be taken back to the Main Menu");
                    Console.ReadLine();
                    return "MainMenu";
                }
            else
                {
                    Log.Information("User has an account!");
                    Console.WriteLine("=================================================================");
                    Console.WriteLine("You have an account with us! Welcome back " + SummonerName + "!");
                    Console.WriteLine("For Security reasons please enter the phone number associated with your account");
                    string Summonerphone = Console.ReadLine();
                    
                    Log.Warning("User tried to search " + Summonerphone);

                    

                //     SummonerInfo FoundedPhone = _LeagueStoreBL.Search(Summonerphone);

                try
                {
                    double phone = Convert.ToDouble(Summonerphone);
                    if(phone == 0)
                    {
                        Log.Warning("User did not put their phone number correctly");

                        Console.WriteLine("That phone number was not correct. Please verify your phone number is correct and try again");
                        Console.WriteLine("Press any key to go back to main menu");
                        Console.ReadLine();
                        return "MainMenu";

                    }
                    if (phone != 0 && FoundedSummoner.Phonenumber == phone)
                       {
                        Log.Information("User entered the correct phone number");

                        Console.WriteLine("Your profile has been verified!");
                        Console.WriteLine("What would you like to do today?");
                        Console.WriteLine("[2] - Update my information");
                        Console.WriteLine("[1] - View past orders");
                        Console.WriteLine("[0] - Go back to Main Menu");
                        string UserInput = Console.ReadLine();

                        if (UserInput == "2")
                        {
                            return "UpdateProfile";
                        }

                        else if (UserInput == "1")
                        {
                            return "MainMenu";
                        }
                        else if (UserInput == "0")
                        {
                            return "MainMenu";
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid input");
                            Console.WriteLine("Press any key to be taken back to the Main Menu");
                            Console.ReadLine();
                            return "MainMenu";
                        }
                       } 
                    return "MainMenu";
                }
                catch (System.FormatException)
                {
                    Log.Warning("User did not put their phone number correctly");

                    Console.WriteLine("That phone number was not correct. Please verify your phone number is correct and try again");
                    Console.WriteLine("Press any key to go back to main menu");
                    Console.ReadLine();
                    return "MainMenu";
                     
                    
                }   
            }
        }   
    }
}