namespace LeagueStoreUI

{
    
    public class StoreSelection : ILeague
    {
    
        
        // Top TopMenu = new Top();
        // Jungle JungleMenu = new Jungle();
        // Mid MidMenu = new Mid();
        // // ADC ADCMenu = new ADC(new StoreItemsBL(new SQLStoreChampion(new Configuration.GetConnectionString("Robert_Nevarez_Champion"))));
        // Support SupportMenu = new Support();
        public void Display()
        {
            Console.WriteLine("Welcome to the rift! Please choose what store you would like to buy a champion for");
            Console.WriteLine("[5] Top");
            Console.WriteLine("[4] Jungle");
            Console.WriteLine("[3] Mid");
            Console.WriteLine("[2] ADC");
            Console.WriteLine("[1] Support");
            Console.WriteLine("[0] Back");
        }
        public string YourChoice()
        {
            string UserInput2 = Console.ReadLine();
             if (UserInput2 == "5")
                {
                    // TopMenu = new Top();
                    // menu = new Top();
                    return "Top";
                }
                else if (UserInput2 == "4")
                {
                    // JungleMenu.Display();
                    // JungleMenu.YourChoice();
                    return "Jungle";
                }
                else if (UserInput2 == "3")
                {
                    // MidMenu.Display();
                    // MidMenu.YourChoice();
                    return "Mid";
                }
                else if (UserInput2 == "2")
                {
                    
                    // ADCMenu.Display();
                    // ADCMenu.YourChoice();
                    return "ADC";
                }
                else if (UserInput2 == "1")
                {
                    // SupportMenu.Display();
                    // SupportMenu.YourChoice();
                    return "Support";
                }
                else if (UserInput2 == "0")
                {
                    Console.Clear();
                    return "MainMenu";
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please enter a valid Response");
                    return "StoreSelection";
                }
        }
    }
}