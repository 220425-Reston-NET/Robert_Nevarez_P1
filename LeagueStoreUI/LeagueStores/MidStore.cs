using LeagueStoreBL;
using Summoner;

namespace LeagueStoreUI
{
    public class Mid : ILeague
    {
        internal ChampionInfoInventory _checkout = new ChampionInfoInventory();
        public static ChampionInfoInventory Founded;
    //==============================================================================================
        private IStoreItemsBL  _found;
        public Mid(IStoreItemsBL p_found)
        {
            _found = p_found;
        }
    //==============================================================================================
        public void Display()
        {
            Console.Clear();
            Console.WriteLine ("=======Welcome to the Mid Store!=======");
            Console.WriteLine ("You ready to just 1 shot every champion in the game");
            Console.WriteLine ("What would you like to do today?");
            Console.WriteLine ("[2] - Buy Mid Champion");
            Console.WriteLine ("[1] - Check inventory");
            Console.WriteLine ("[0] - Return to store selection");
        }

        public string YourChoice()
        {
            string Userinput = Console.ReadLine();


             if (Userinput == "2")
            {
                 Console.WriteLine("Please choose what Champion you would like to buy");
                Console.WriteLine("[3] - Katarina");
                Console.WriteLine("[2] - Leblanc");
                Console.WriteLine("[1] - Yone");
                Console.WriteLine("[0] - Go Back");

                string UserInput2 = Console.ReadLine();

                if(UserInput2 == "3")
                {
                    Console.WriteLine("Great Choice! The Sinister Blade at your service. How many would you like to buy?");
                    byte HowMany =  Convert.ToByte(Console.ReadLine());
                    _checkout.ChampionID = HowMany;

                    Console.WriteLine("Nice! Confirming your order, You are buying " + HowMany + " Katarina for " + (200*HowMany) + " RP.\nPlease choose what you would like to do");
                    Console.WriteLine("[1] - Buy");
                    Console.WriteLine("[0] - Go back");
                    
                    string Userinput3 = Console.ReadLine();
                    if(Userinput3 == "1")
                    {
                        int ChampionID = 7;
                        try
                        {
                            _found.UpdateInventory(ChampionID, HowMany);
                            Console.WriteLine("Sucess! Congrats on your purchase");
                            Console.WriteLine("Press any key to be taken back to the Mid Menu");
                            Console.ReadLine();
                            return "Mid";
                        }
                        catch (Microsoft.Data.SqlClient.SqlException)
                        {
                            
                            Console.WriteLine("You're trying to buy more than what we have in the store!");
                            Console.WriteLine("Please check inventory and select an amount we have");
                            Console.WriteLine("Press any key to be taken back to the Mid store");
                            Console.ReadLine();
                            return "Mid";
                        }
                        
                    }
                    else if (Userinput3 == "0")
                    {
                        return "Mid";
                    }
                    else
                    {
                        Console.WriteLine("Please Enter a Valid Input");
                        Console.WriteLine("Press any key to be taken back to Mid Menu");
                        Console.ReadLine();
                        return "Mid";
                    }
                    
                }
                else if(UserInput2 == "2")
                {
                    Console.WriteLine("Great Choice! The Deceiver at your service. How many would you like to buy?");
                    byte HowMany = Convert.ToByte(Console.ReadLine());
                    _checkout.ChampionID = HowMany;

                    Console.WriteLine("Nice! Confirming your order, You are buying " + HowMany + " Leblanc for " + (400*HowMany) + " RP.\nPlease choose what you would like to do");
                    Console.WriteLine("[1] - Buy");
                    Console.WriteLine("[0] - Go back");
                    
                    string Userinput3 = Console.ReadLine();
                    if(Userinput3 == "1")
                    {
                        int ChampionID = 8;
                        try
                        {
                            _found.UpdateInventory(ChampionID, HowMany);
                            Console.WriteLine("Sucess! Congrats on your purchase");
                            Console.WriteLine("Press any key to be taken back to the Mid Menu");
                            Console.ReadLine();
                            return "Mid";
                        }
                        catch (Microsoft.Data.SqlClient.SqlException)
                        {
                            
                            Console.WriteLine("You're trying to buy more than what we have in the store!");
                            Console.WriteLine("Please check inventory and select an amount we have");
                            Console.WriteLine("Press any key to be taken back to the Mid store");
                            Console.ReadLine();
                            return "Mid";
                        }

                    }
                    else if (Userinput3 == "0")
                    {
                        return "Mid";
                    }
                    else
                    {
                        Console.WriteLine("Please Enter a Valid Input");
                        Console.WriteLine("Press any key to be taken back to Mid Menu");
                        Console.ReadLine();
                        return "Mid";
                    }
                }
                else if(UserInput2 == "1")
                {
                    Console.WriteLine("Great Choice! The Unforgotten at your service. How many would you like to buy?");
                    byte HowMany = Convert.ToByte(Console.ReadLine());
                    _checkout.ChampionID = HowMany;

                    Console.WriteLine("Nice! Confirming your order, You are buying " + HowMany + " Yone for " + (600*HowMany) + " RP.\nPlease choose what you would like to do");
                    Console.WriteLine("[1] - Buy");
                    Console.WriteLine("[0] - Go back");
                    
                    string Userinput3 = Console.ReadLine();
                    if(Userinput3 == "1")
                    {
                        int ChampionID = 9;
                       try
                        {
                            _found.UpdateInventory(ChampionID, HowMany);
                            Console.WriteLine("Sucess! Congrats on your purchase");
                            Console.WriteLine("Press any key to be taken back to the Mid Menu");
                            Console.ReadLine();
                            return "Mid";
                        }
                        catch (Microsoft.Data.SqlClient.SqlException)
                        {
                            
                            Console.WriteLine("You're trying to buy more than what we have in the store!");
                            Console.WriteLine("Please check inventory and select an amount we have");
                            Console.WriteLine("Press any key to be taken back to the Mid store");
                            Console.ReadLine();
                            return "Mid";
                        }

                    }
                    else if (Userinput3 == "0")
                    {
                        return "Mid";
                    }
                    else
                    {
                        Console.WriteLine("Please Enter a Valid Input");
                        Console.WriteLine("Press any key to be taken back to Mid Menu");
                        Console.ReadLine();
                        return "Mid";
                    }
                 }     
            }

            else if (Userinput == "1")
            {
                string FoundedStore = "Mid";
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
                return "Mid";

            }
            return "";
        }
    }
}