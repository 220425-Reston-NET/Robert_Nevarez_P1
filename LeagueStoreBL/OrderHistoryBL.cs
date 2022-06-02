using Summoner;
using StoreRepo;

namespace LeagueStoreBL
{
    public class OrderHistoryBL : IOrderHistoryBL
    {
        private IRepository<OrderHistory> _Historyrepo;
        public OrderHistoryBL(IRepository<OrderHistory> p_Historyrepo)
        {
            _Historyrepo = p_Historyrepo;
        }
        public void NewOrderHistory(string p_Name, string p_ChampionName, int p_TotalBought, int p_TotalPrice, string p_Store)
        {
            OrderHistory Allhistory = new OrderHistory();
            Allhistory.Name = p_Name;
            Allhistory.ChampionName = p_ChampionName;
            Allhistory.TotalBought = p_TotalBought;
            Allhistory.TotalPrice = p_TotalPrice;
            Allhistory.StoreName = p_Store;

            _Historyrepo.Add(Allhistory);
        }
    }
}