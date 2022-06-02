namespace LeagueStoreBL
{
    public interface IOrderHistoryBL
    {
        void NewOrderHistory(string p_Name, string p_ChampionName, int p_TotalBought, int p_TotalPrice, string p_Store);
    }
}