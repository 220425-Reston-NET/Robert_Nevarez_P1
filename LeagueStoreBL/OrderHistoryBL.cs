using Summoner;
using StoreRepo;

namespace LeagueStoreBL
{
    public class OrderHistoryBL : IOrderHistoryBL
    {
        private readonly IRepository<OrderHistory> _Historyrepo;
        public OrderHistoryBL(IRepository<OrderHistory> p_Historyrepo)
        {
            _Historyrepo = p_Historyrepo;
        }
        public void NewOrderHistory(string p_ChampionName, int p_TotalBought, string p_Store, int p_SumID)
        {
            OrderHistory Allhistory = new OrderHistory();
            Allhistory.ChampionName = p_ChampionName;
            Allhistory.TotalBought = p_TotalBought;
            Allhistory.StoreName = p_Store;
            Allhistory.SumID = p_SumID;

            _Historyrepo.Add(Allhistory);
        }

        public List<OrderHistory> StoreOrderHistory(string p_Store)
        {
            List<OrderHistory> currentorderhistory = _Historyrepo.GetAll();
            List<OrderHistory> filteredorderhistory = new List<OrderHistory>();
            foreach (OrderHistory History in currentorderhistory)
            {

                if (History.StoreName == p_Store)
                {
                    filteredorderhistory.Add(History);
                }
            }
            return filteredorderhistory;
        }

        public List<OrderHistory> SumOrderHistory(string p_SumName)
        {
            List<OrderHistory> currentorderhistory = _Historyrepo.GetAll();
            List<OrderHistory> filteredorderhistory = new List<OrderHistory>();
            foreach (OrderHistory History in currentorderhistory)
            {

                if (History.Name == p_SumName)
                {
                    filteredorderhistory.Add(History);
                }
            }
            return filteredorderhistory;
        }
    }
}