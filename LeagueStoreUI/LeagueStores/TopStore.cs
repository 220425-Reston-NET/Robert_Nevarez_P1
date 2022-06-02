using LeagueStoreBL;
using Summoner;

namespace LeagueStoreUI
{
    public class Top : ILeague
    {
        internal ChampionInfoInventory _checkout = new ChampionInfoInventory();

         public static ChampionInfoInventory Founded;
    //==============================================================================================
        private IStoreItemsBL  _found;
        public Top(IStoreItemsBL p_found)
        {
            _found = p_found;
        }
    //==============================================================================================
        public void Display()
        {
            Console.Clear();
            Console.WriteLine ("=======Welcome to the Top Store!=======");
             Console.WriteLine ("You ready for the bot diff in your game?");
            Console.WriteLine ("What would you like to do today?");
            Console.WriteLine ("[2] - Buy Top Champion");
            Console.WriteLine ("[1] - Check inventory");
            Console.WriteLine ("[0] - Return to store selection");
        }

        public string YourChoice()
        {
             string Userinput = Console.ReadLine();


            if (Userinput == "2")
            {
                 Console.WriteLine("Please choose what Champion you would like to buy");
                Console.WriteLine("[3] - Amumu");
                Console.WriteLine("[2] - Ivern");
                Console.WriteLine("[1] - Lilia");
                Console.WriteLine("[0] - Go Back");

                string UserInput2 = Console.ReadLine();

                if(UserInput2 == "3")
                {
                    Console.WriteLine("Great Choice! The Sad Mummy at your service. How many would you like to buy?");
                    byte HowMany =  Convert.ToByte(Console.ReadLine());
                    _checkout.ChampionID = HowMany;

                    Console.WriteLine("Nice! Confirming your order, You are buying " + HowMany + " Amumu for " + (200*HowMany) + " RP.\nPlease choose what you would like to do");
                    Console.WriteLine("[1] - Buy");
                    Console.WriteLine("[0] - Go back");
                    
                    string Userinput3 = Console.ReadLine();
                    if(Userinput3 == "1")
                    {
                        int ChampionID = 4;
                        try
                        {
                            _found.UpdateInventory(ChampionID, HowMany);
                            Console.WriteLine("Sucess! Congrats on your purchase");
                            Console.WriteLine("Press any key to be taken back to the Jungle Menu");
                            Console.ReadLine();
                            return "Jungle";
                        }
                        catch (Microsoft.Data.SqlClient.SqlException)
                        {
                            
                            Console.WriteLine("You're trying to buy more than what we have in the store!");
                            Console.WriteLine("Please check inventory and select an amount we have");
                            Console.WriteLine("Press any key to be taken back to the Jungle store");
                            Console.ReadLine();
                            return "Jungle";
                        }
                        
                    }
                    else if (Userinput3 == "0")
                    {
                        return "Jungle";
                    }
                    else
                    {
                        Console.WriteLine("Please Enter a Valid Input");
                        Console.WriteLine("Press any key to be taken back to Jungle Menu");
                        Console.ReadLine();
                        return "Jungle";
                    }
                    
                }
                else if(UserInput2 == "2")
                {
                    Console.WriteLine("Great Choice! The Green Father at your service. How many would you like to buy?");
                    byte HowMany = Convert.ToByte(Console.ReadLine());
                    _checkout.ChampionID = HowMany;

                    Console.WriteLine("Nice! Confirming your order, You are buying " + HowMany + " Ivern for " + (400*HowMany) + " RP.\nPlease choose what you would like to do");
                    Console.WriteLine("[1] - Buy");
                    Console.WriteLine("[0] - Go back");
                    
                    string Userinput3 = Console.ReadLine();
                    if(Userinput3 == "1")
                    {
                        int ChampionID = 5;
                        try
                        {
                            _found.UpdateInventory(ChampionID, HowMany);
                            Console.WriteLine("Sucess! Congrats on your purchase");
                            Console.WriteLine("Press any key to be taken back to the Jungle Menu");
                            Console.ReadLine();
                            return "Jungle";
                        }
                        catch (Microsoft.Data.SqlClient.SqlException)
                        {
                            
                            Console.WriteLine("You're trying to buy more than what we have in the store!");
                            Console.WriteLine("Please check inventory and select an amount we have");
                            Console.WriteLine("Press any key to be taken back to the Jungle store");
                            Console.ReadLine();
                            return "Jungle";
                        }

                    }
                    else if (Userinput3 == "0")
                    {
                        return "Jungle";
                    }
                    else
                    {
                        Console.WriteLine("Please Enter a Valid Input");
                        Console.WriteLine("Press any key to be taken back to Jungle Menu");
                        Console.ReadLine();
                        return "Jungle";
                    }
                }
                else if(UserInput2 == "1")
                {
                    Console.WriteLine("Great Choice! The Bashful Bloom at your service. How many would you like to buy?");
                    byte HowMany = Convert.ToByte(Console.ReadLine());
                    _checkout.ChampionID = HowMany;

                    Console.WriteLine("Nice! Confirming your order, You are buying " + HowMany + " Lilia for " + (600*HowMany) + " RP.\nPlease choose what you would like to do");
                    Console.WriteLine("[1] - Buy");
                    Console.WriteLine("[0] - Go back");
                    
                    string Userinput3 = Console.ReadLine();
                    if(Userinput3 == "1")
                    {
                        int ChampionID = 6;
                       try
                        {
                            _found.UpdateInventory(ChampionID, HowMany);
                            Console.WriteLine("Sucess! Congrats on your purchase");
                            Console.WriteLine("Press any key to be taken back to the Jungle Menu");
                            Console.ReadLine();
                            return "Jungle";
                        }
                        catch (Microsoft.Data.SqlClient.SqlException)
                        {
                            
                            Console.WriteLine("You're trying to buy more than what we have in the store!");
                            Console.WriteLine("Please check inventory and select an amount we have");
                            Console.WriteLine("Press any key to be taken back to the Jungle store");
                            Console.ReadLine();
                            return "Jungle";
                        }

                    }
                    else if (Userinput3 == "0")
                    {
                        return "Jungle";
                    }
                    else
                    {
                        Console.WriteLine("Please Enter a Valid Input");
                        Console.WriteLine("Press any key to be taken back to Jungle Menu");
                        Console.ReadLine();
                        return "Jungle";
                    }
                 }     
            }

            else if (Userinput == "1")
            {
                string FoundedStore = "Top";
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
                return "Top";

            }
            return "";
        }
    }
}
