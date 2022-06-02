namespace Summoner
{

    public class ChampionInfo
    {
        public string Store { get ; set; }
        public string ChampionName { get ; set ;}
        public int RPprice { get ; set ; }

        public List<ChampionInfoInventory> Inventories = new List<ChampionInfoInventory>();


        public ChampionInfo()
        {
        Store = "";
        ChampionName = "";
        RPprice = 0;
        Inventories = new List<ChampionInfoInventory>();

        }
        public override string ToString()
        {
            return $"===Champion Info===\nStore: {Store}\nChampion Name: {ChampionName}\nRP Price: {RPprice}\n========================";
        }
        
    }
}