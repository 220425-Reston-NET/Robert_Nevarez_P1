using Summoner;
using LeagueStoreBL;

namespace LeagueStoreUI
{
    public class AdminMenu : ILeague
    {
        public static ChampionInfo Founded;
        public ChampionInfo _Champ = new ChampionInfo();
        public ChampionInfoInventory _Inventory = new ChampionInfoInventory();

        //===============================================================================
        private IStoreItemsBL _addinventory;
        private ILeagueStoreBL<ChampionInfo> _addchampion;
        public AdminMenu (ILeagueStoreBL<ChampionInfo> p_addchampion, IStoreItemsBL p_addinventory)
        {
            _addchampion = p_addchampion;
            _addinventory = p_addinventory;
        }


        public void Display()
        {       
            Console.Clear();
            Console.WriteLine("=======Welcome to the Admin Menu=======");
            Console.WriteLine("What would you like to do today");
            Console.WriteLine("[3] - Add New Champion");
            Console.WriteLine("[2] - Replenish Inventory");
            Console.WriteLine("[1] - View Store Inventories");
            Console.WriteLine("[0] - Return to Main Menu");
            
            // Console.WriteLine("What Store Role will the new champion be bought from?");
            //  _Champ.Store = Console.ReadLine();
            //  Console.WriteLine("===============================================================");
            // Console.WriteLine("The New Champion will go be bought from the "+ _Champ.Store + " store. What will be the Champion Name?");
            // _Champ.ChampionName = Console.ReadLine();
            // Console.WriteLine("=====================================================================================");
            // Console.WriteLine("The Champion will be called " + _Champ.ChampionName + ". How much will that new champion cost");
            // _Champ.RPprice = Convert.ToInt32(Console.ReadLine());
            // Console.WriteLine("=======================================================================");
            // Console.WriteLine(_Champ.ChampionName + " will cost " + _Champ.RPprice + "and will be for store " +_Champ.Store); 
            // Console.WriteLine("[1] - Add Champion");
            // Console.WriteLine("[0] - Redo");
        }
        public string YourChoice()
        {
            string UserInput = Console.ReadLine();

            if (UserInput == "3")
            { 
                // _addchampion.Add(_Champ);
                // Console.WriteLine ("Champion was successfully added");
                // Console.WriteLine ("Press any key to start again");
                // Console.ReadLine();
                // return "MainMenu";
                return "";
            }
            else if (UserInput == "2")
            {
                Console.Clear();
                Console.WriteLine("Please write the Champion ID of the champion you're trying to replenish?");
                Console.WriteLine("Please refer to Inventory if you don't know ChampionID");
                int ChampionSearchID = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Please select the amount you want to replenish");
                byte ChampionReplenish = Convert.ToByte(Console.ReadLine());
                try
                {
                    _addinventory.AddUpdateInventory(ChampionSearchID,ChampionReplenish);
                    Console.WriteLine("Success! The inventory has been updates");
                    Console.WriteLine("Press any key to go back");
                    Console.ReadLine();
                }
                catch (System.FormatException)
                {
                    
                    Console.WriteLine("Please enter valid info when updating inventory");
                    Console.WriteLine("Press any key to go back");
                    Console.ReadLine();
                }
                
            }
            else if (UserInput == "1")
            {
                Console.Clear();
                Console.WriteLine("Please choose which store you want to see the inventory from");
                Console.WriteLine("[5] - Top");
                Console.WriteLine("[4] - Jungle");
                Console.WriteLine("[3] - Mid");
                Console.WriteLine("[2] - ADC");
                Console.WriteLine("[1] - Support");
                Console.WriteLine("[0] - Back");

                string UserInput2 = Console.ReadLine();
                
                if(UserInput2 == "5")
                {
                    string FoundedStore = "Top";
                    List<ChampionInfoInventory> Founded = _addinventory.SearchStore(FoundedStore);
                    Console.Clear();
                    foreach (ChampionInfoInventory Store in Founded)
                    {
                        Console.WriteLine(Store.ToString());
                        Console.ReadLine();
                    }
                }
                else if(UserInput2 == "4")
                {
                    string FoundedStore = "Jungle";
                    List<ChampionInfoInventory> Founded = _addinventory.SearchStore(FoundedStore);
                    Console.Clear();
                    foreach (ChampionInfoInventory Store in Founded)
                    {
                        Console.WriteLine(Store.ToString());
                        Console.ReadLine();
                    }
                }
                else if (UserInput2 == "3")
                {
                    string FoundedStore = "Mid";
                    List<ChampionInfoInventory> Founded = _addinventory.SearchStore(FoundedStore);
                    Console.Clear();
                    foreach (ChampionInfoInventory Store in Founded)
                    {
                        Console.WriteLine(Store.ToString());
                        Console.ReadLine();
                    }
                }
                else if (UserInput2 == "2")
                {
                    string FoundedStore = "ADC";
                    List<ChampionInfoInventory> Founded = _addinventory.SearchStore(FoundedStore);
                    Console.Clear();
                    foreach (ChampionInfoInventory Store in Founded)
                    {
                        Console.WriteLine(Store.ToString());
                        Console.ReadLine();
                    }
                }
                else if (UserInput2 == "1")
                {
                    string FoundedStore = "Support";
                    List<ChampionInfoInventory> Founded = _addinventory.SearchStore(FoundedStore);
                    Console.Clear();
                    foreach (ChampionInfoInventory Store in Founded)
                    {
                        Console.WriteLine(Store.ToString());
                        Console.ReadLine();
                    }
                }
                else
                {

                }
            }
            else if (UserInput == "0")
            {
                return "MainMenu";
            }
            else
            {
                Console.WriteLine ("Please make a valid selection");
                Console.WriteLine ("Press any key to be taken back to the Main Menu");
                Console.ReadLine();
                return "Main Menu";
            }
            return "";
        }
    }
}
