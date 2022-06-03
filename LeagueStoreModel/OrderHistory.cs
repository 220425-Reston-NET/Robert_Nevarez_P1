namespace Summoner
{
    public class OrderHistory
    {
       public string Name {get; set;}
       public int SumID{get; set;}
       public string ChampionName{get;set;}
        public int TotalBought{get;set;}
       public int TotalPrice{get;set;}
       public string StoreName{get;set;}
    //    SummonerInfo Connection =  new SummonerInfo();

        public OrderHistory()
        {
            Name = "";
            ChampionName = "";
            TotalBought = 0;
            TotalPrice = 0;
            StoreName = "";

        }
        public override string ToString()
        {
            return $"===Order History Info===\nName: {Name}\nChampion Name: {ChampionName}\nTotalBought: {TotalBought}\nTotal Price: {TotalPrice}\nStoreName: {StoreName}\n=========================";
        }

    }
}