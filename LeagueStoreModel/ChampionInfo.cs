namespace Summoner
{

    public class ChampionInfo
    {
        public string Store { get ; set; }
        public string ChampionName { get ; set ;}
        public int RPprice { get ; set ; }



        public ChampionInfo()
        {
        Store = "";
        ChampionName = "";
        RPprice = 0;

        }
        public override string ToString()
        {
            return $"===Champion Info===\nStore: {Store}\nChampion Name: {ChampionName}\nRP Price: {RPprice}\n========================";
        }
        
    }
}