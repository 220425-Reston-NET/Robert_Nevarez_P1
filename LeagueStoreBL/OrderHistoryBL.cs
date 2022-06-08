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

        public List<OrderHistory> GetAllHistory()
        {
            return _Historyrepo.GetAll();
        }

        public void NewOrderHistory(string p_ChampionName, int p_TotalBought, string p_Store, int p_SumID)
        {
            if (p_ChampionName == "Irelia" || p_ChampionName == "Amumu" || p_ChampionName == "Katarina" || p_ChampionName == "Lucian" || p_ChampionName == "Nami")
            {
                 OrderHistory Allhistory = new OrderHistory();
                Allhistory.ChampionName = p_ChampionName;
                Allhistory.TotalBought = p_TotalBought;
                Allhistory.StoreName = p_Store;
                Allhistory.SumID = p_SumID;

                Allhistory.TotalPrice = (Allhistory.TotalBought*200);

                _Historyrepo.Add(Allhistory);

            }
              else if (p_ChampionName == "Riven" || p_ChampionName == "Ivern" || p_ChampionName == "Leblanc" || p_ChampionName == "Jinx" || p_ChampionName == "Taric")
            {
                 OrderHistory Allhistory = new OrderHistory();
                Allhistory.ChampionName = p_ChampionName;
                Allhistory.TotalBought = p_TotalBought;
                Allhistory.StoreName = p_Store;
                Allhistory.SumID = p_SumID;

                Allhistory.TotalPrice = (Allhistory.TotalBought*400);

                _Historyrepo.Add(Allhistory);

            }
             else if (p_ChampionName == "Gwen" || p_ChampionName == "Lilia" || p_ChampionName == "Yone" || p_ChampionName == "Vayne" || p_ChampionName == "Renata Glasc")
            {
                 OrderHistory Allhistory = new OrderHistory();
                Allhistory.ChampionName = p_ChampionName;
                Allhistory.TotalBought = p_TotalBought;
                Allhistory.StoreName = p_Store;
                Allhistory.SumID = p_SumID;

                Allhistory.TotalPrice = (Allhistory.TotalBought*600);

                _Historyrepo.Add(Allhistory);

            }
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
                // else
                // {
                //     throw new InvalidOperationException();
                // }
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
                // else 
                // {
                //     throw new InvalidOperationException();
                // }
                
            }
            return filteredorderhistory;
            
            
        }
    }
}