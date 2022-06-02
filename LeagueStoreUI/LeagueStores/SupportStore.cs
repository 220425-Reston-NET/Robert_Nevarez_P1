using LeagueStoreBL;
using Summoner;

namespace LeagueStoreUI
{
    public class Support : ILeague
    {
        internal ChampionInfoInventory _checkout = new ChampionInfoInventory();

         public static SummonerInfo Founded;
    //==============================================================================================
        private IStoreItemsBL  _found;
        private ILeagueStoreBL<SummonerInfo> _check;
        private IOrderHistoryBL _history;
        public Support(IStoreItemsBL p_found, ILeagueStoreBL<SummonerInfo> p_check, IOrderHistoryBL p_history)
        {
            _found = p_found;
            _check = p_check;
            _history = p_history;
        }
    //==============================================================================================
        public void Display()
        {
            Console.Clear();
            Console.WriteLine ("=======Welcome to the Support Store!=======");
            Console.WriteLine ("Support Dif wins games!");
            Console.WriteLine ("What would you like to do today?");
            Console.WriteLine ("[2] - Buy Support Champion");
            Console.WriteLine ("[1] - Check inventory");
            Console.WriteLine ("[0] - Return to store selection");
        }

        public string YourChoice()
        {
             string Userinput = Console.ReadLine();

            if (Userinput == "2")
            {
                Console.WriteLine("Please choose what Champion you would like to buy");
                Console.WriteLine("[3] - Nami");
                Console.WriteLine("[2] - Taric");
                Console.WriteLine("[1] - Renata Glasc");
                Console.WriteLine("[0] - Go Back");

                string UserInput2 = Console.ReadLine();

                if(UserInput2 == "3")
                {
                    Console.WriteLine("Great Choice! The Tidecaller at your service. How many would you like to buy?");
                    byte HowMany =  Convert.ToByte(Console.ReadLine());
                    _checkout.ChampionID = HowMany;

                    Console.WriteLine("Nice! Confirming your order, You are buying " + HowMany + " Nami for " + (200*HowMany) + " RP.\nPlease choose what you would like to do");
                    Console.WriteLine("[1] - Buy");
                    Console.WriteLine("[0] - Go back");
                    
                    string Userinput3 = Console.ReadLine();
                    if(Userinput3 == "1")
                    {
                        Console.WriteLine("Please type your Summoner Name to confirm your purchase");
                        string SummonerCheck = Console.ReadLine();

                        Founded = _check.Search(SummonerCheck);
                        if (Founded == null)
                        {
                            Console.WriteLine("Your Summoner Name was not found! Please your correct summoner name to checkout");
                            Console.WriteLine("Press any key to be taken back to the Support Menu");
                            Console.ReadLine();
                            return "Support";
                        }
                        else
                        {
                            int ChampionID = 13;
                            int TotalBought = 200 * Convert.ToInt32(HowMany);
                        try
                        {
                             _history.NewOrderHistory(SummonerCheck,"Nami", Convert.ToInt32(HowMany), TotalBought, "Support");
                            _found.UpdateInventory(ChampionID, HowMany);
                            Console.WriteLine("Sucess! Congrats on your purchase");
                            Console.WriteLine("Press any key to be taken back to the Support Menu");
                            Console.ReadLine();
                            return "Support";
                        }
                        catch (Microsoft.Data.SqlClient.SqlException)
                        {
                            
                            Console.WriteLine("You're trying to buy more than what we have in the store!");
                            Console.WriteLine("Please check inventory and select an amount we have");
                            Console.WriteLine("Press any key to be taken back to the Support store");
                            Console.ReadLine();
                            return "Support";
                        }
                        }
                        
                        
                    }
                    else if (Userinput3 == "0")
                    {
                        return "Support";
                    }
                    else
                    {
                        Console.WriteLine("Please Enter a Valid Input");
                        Console.WriteLine("Press any key to be taken back to Support Menu");
                        Console.ReadLine();
                        return "Support";
                    }
                    
                }
                else if(UserInput2 == "2")
                {
                    Console.WriteLine("Great Choice! The Shield of Valoran at your service. How many would you like to buy?");
                    byte HowMany = Convert.ToByte(Console.ReadLine());
                    _checkout.ChampionID = HowMany;

                    Console.WriteLine("Nice! Confirming your order, You are buying " + HowMany + " Taric for " + (400*HowMany) + " RP.\nPlease choose what you would like to do");
                    Console.WriteLine("[1] - Buy");
                    Console.WriteLine("[0] - Go back");
                    
                    string Userinput3 = Console.ReadLine();
                    if(Userinput3 == "1")
                    {
                        Console.WriteLine("Please type your Summoner Name to confirm your purchase");
                        string SummonerCheck = Console.ReadLine();

                        Founded = _check.Search(SummonerCheck);
                        if (Founded == null)
                        {
                            Console.WriteLine("Your Summoner Name was not found! Please your correct summoner name to checkout");
                            Console.WriteLine("Press any key to be taken back to the Support Menu");
                            Console.ReadLine();
                            return "Support";
                        }
                        else
                        {
                            int ChampionID = 14;
                            int TotalBought = 400 * Convert.ToInt32(HowMany);
                        try
                        {

                            _found.UpdateInventory(ChampionID, HowMany);
                            _history.NewOrderHistory(SummonerCheck,"Taric", Convert.ToInt32(HowMany), TotalBought, "Support");
                            Console.WriteLine("Sucess! Congrats on your purchase");
                            Console.WriteLine("Press any key to be taken back to the Support Menu");
                            Console.ReadLine();
                            return "Support";
                        }
                        catch (Microsoft.Data.SqlClient.SqlException)
                        {
                            
                            Console.WriteLine("You're trying to buy more than what we have in the store!");
                            Console.WriteLine("Please check inventory and select an amount we have");
                            Console.WriteLine("Press any key to be taken back to the Support store");
                            Console.ReadLine();
                            return "Support";
                        }
                        }

                    }
                    else if (Userinput3 == "0")
                    {
                        return "Support";
                    }
                    else
                    {
                        Console.WriteLine("Please Enter a Valid Input");
                        Console.WriteLine("Press any key to be taken back to Support Menu");
                        Console.ReadLine();
                        return "Support";
                    }
                }
                else if(UserInput2 == "1")
                {
                    Console.WriteLine("Great Choice! The Chem-Baroness at your service. How many would you like to buy?");
                    byte HowMany = Convert.ToByte(Console.ReadLine());
                    _checkout.ChampionID = HowMany;

                    Console.WriteLine("Nice! Confirming your order, You are buying " + HowMany + " Renata Glasc for " + (600*HowMany) + " RP.\nPlease choose what you would like to do");
                    Console.WriteLine("[1] - Buy");
                    Console.WriteLine("[0] - Go back");
                    
                    string Userinput3 = Console.ReadLine();
                    if(Userinput3 == "1")
                    {
                       Console.WriteLine("Please type your Summoner Name to confirm your purchase");
                        string SummonerCheck = Console.ReadLine();

                        Founded = _check.Search(SummonerCheck);
                        if (Founded == null)
                        {
                            Console.WriteLine("Your Summoner Name was not found! Please your correct summoner name to checkout");
                            Console.WriteLine("Press any key to be taken back to the Support Menu");
                            Console.ReadLine();
                            return "Support";
                        }
                        else
                        {
                            int ChampionID = 15;
                            int TotalBought1 = 600 * HowMany;
                            string Champion1 = "Renata Glasc";
                            string store1 = "Support";
                        try
                        {

                            _found.UpdateInventory(ChampionID, HowMany);
                            _history.NewOrderHistory(SummonerCheck, Champion1, Convert.ToInt32(HowMany), TotalBought1, store1);
                            Console.WriteLine("Sucess! Congrats on your purchase");
                            Console.WriteLine("Press any key to be taken back to the Support Menu");
                            Console.ReadLine();
                            return "Support";
                        }
                        catch (Microsoft.Data.SqlClient.SqlException)
                        {
                            
                            Console.WriteLine("You're trying to buy more than what we have in the store!");
                            Console.WriteLine("Please check inventory and select an amount we have");
                            Console.WriteLine("Press any key to be taken back to the Support store");
                            Console.ReadLine();
                            return "Support";
                        }
                        }
                    }
                    else if (Userinput3 == "0")
                    {
                        return "Support";
                    }
                    else
                    {
                        Console.WriteLine("Please Enter a Valid Input");
                        Console.WriteLine("Press any key to be taken back to Support Menu");
                        Console.ReadLine();
                        return "Support";
                    }
                 }     
            }

            else if (Userinput == "1")
            {
                string FoundedStore = "Support";
                List<ChampionInfoInventory> Founded = _found.SearchStore(FoundedStore);
                Console.Clear();
                foreach (ChampionInfoInventory Store in Founded)
                {
                    Console.WriteLine(Store.ToString());
                    Console.ReadLine();
                }
            }

            else if (Userinput == "0")
            {
                return "StoreSelection";
            }

            else
            {
                Console.WriteLine("Please make a valid selection");
                return "Support";

            }
            return "";
        }
    }
}