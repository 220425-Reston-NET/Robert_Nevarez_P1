using Summoner;

namespace LeagueStoreBL
{
    public interface IOrderHistoryBL
    {
        void NewOrderHistory(string p_ChampionName, int p_TotalBought, string p_Store, int p_SumID);
        public List<OrderHistory> SumOrderHistory(string p_SumName);

        public List<OrderHistory> StoreOrderHistory(string p_Store);

         public List<OrderHistory> GetAllHistory();
    }
}