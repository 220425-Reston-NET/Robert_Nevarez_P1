namespace LeagueStoreBL
{
    public interface IOrderHistoryBL
    {
        void NewOrderHistory(string p_ChampionName, int p_TotalBought, string p_Store, int p_SumID);
    }
}