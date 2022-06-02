using LeagueStoreBL;
using LeagueStoreUI;
using Microsoft.Extensions.Configuration;
using Serilog;
using StoreRepo;

Log.Logger = new LoggerConfiguration()
     .WriteTo.File("./logs/user.txt")
    .CreateLogger();
    
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

ILeague menu = new MainMenu();
// WriteChampions menu1 = new WriteChampions( new SearchChampionBL ( new ChampionInfoRepo())); // Creator only to add new champions
bool repeat = true;
while (repeat)
{   
    Console.Clear();
    menu.Display();
    // menu1.Display(); // Creator only to add new champions
    // menu1.YourChoice(); // Creator only to add new champions
    string ans1 = menu.YourChoice();

    if (ans1 == "SummonerSearch")
    {
        Log.Information("User went to Summoner Search");

        Console.Clear();
        menu = new SummonerSearch(new SearchSummonerBL(new SQLSumRepo(configuration.GetConnectionString("Robert_Nevarez_Summoner"))));
    }
    else if (ans1 == "SearchChampion")
    {
        Log.Information("User went to Champion Search");

        Console.Clear();
        menu = new SearchChampion(new SearchChampionBL(new SQLChampRepo(configuration.GetConnectionString("Robert_Nevarez_Champion"))), new SearchRPBL(new SQLChampRepo(configuration.GetConnectionString("Robert_Nevarez_Champion"))));
    }
    else if (ans1 == "StoreSelection")
    {
        Log.Information("User went to select a store");

        Console.Clear();
        menu = new StoreSelection();
    }
    else if (ans1 == "UpdateProfile")
    {
        Log.Information("User went to Update their profile");

        Console.Clear();
        menu = new UpdateInfo(new SearchSummonerBL (new SQLSumRepo(configuration.GetConnectionString("Robert_Nevarez_Summoner"))));
    }
    else if (ans1 == "SummonerProfile")

    {
        Log.Information("User went to Search Summoner Profile");

        Console.Clear();
        menu = new SummonerProfile(new SearchSummonerBL(new SQLSumRepo(configuration.GetConnectionString("Robert_Nevarez_Summoner"))));

    }
    else if (ans1 == "MainMenu")
    {
        Log.Information("User went to Main Menu");
        
        menu = new MainMenu();
    }
    else if (ans1 == "AdminMenu")
    {   
        Console.Clear();
        Console.WriteLine("Please enter the admin password to access Admin Menu");
        string AdminPassword = Console.ReadLine();
        if (AdminPassword == "Yeezus")
        {
            menu = new AdminMenu(new SearchChampionBL(new SQLChampRepo(configuration.GetConnectionString("Robert_Nevarez_Champion"))), new StoreItemsBL(new SQLStoreChampion(configuration.GetConnectionString("Robert_Nevarez_Champion"))));
        }
        else 
        {
            Console.WriteLine("Password was incorrect. Press any key to be taken back to the main menu");
            Console.ReadLine();
            menu = new MainMenu();
        }
    }
    else if (ans1 == "Exit")
    {
        Log.Information("User Exited the store");

        repeat = false;
    }
    else if (ans1 == "Top")
    {
        Log.Information("User went to the Top Store");

        menu = new Top(new StoreItemsBL(new SQLStoreChampion(configuration.GetConnectionString("Robert_Nevarez_Champion"))));
    }
    else if (ans1 == "Jungle")
    {
        Log.Information("User went to the Jungle Store");

        menu = new Jungle(new StoreItemsBL(new SQLStoreChampion(configuration.GetConnectionString("Robert_Nevarez_Champion"))));
    }
    else if (ans1 == "Mid")
    {
        Log.Information("User went to the Mid Store");

        menu = new Mid(new StoreItemsBL(new SQLStoreChampion(configuration.GetConnectionString("Robert_Nevarez_Champion"))));
    }
    else if (ans1 == "ADC")
    {
        Log.Information("User Went to the ADC Store");

        menu = new ADC(new StoreItemsBL(new SQLStoreChampion(configuration.GetConnectionString("Robert_Nevarez_Champion"))));
    }
    else if (ans1 == "Support")
    {
        Log.Information("User went to the Support Store");

        menu = new Support(new StoreItemsBL(new SQLStoreChampion(configuration.GetConnectionString("Robert_Nevarez_Champion"))), new SearchSummonerBL(new SQLSumRepo(configuration.GetConnectionString("Robert_Nevarez_Champion"))), new OrderHistoryBL(new SQLOrderHistoryRepo(configuration.GetConnectionString("Robert_Nevarez_Champion"))));
    }

}
