using StoreRepo;
using Summoner;

namespace LeagueStoreBL
{
    public class StoreItemsBL : IStoreItemsBL
    {
            //==============================Dependecy Injection=========================
            private readonly IRepository<ChampionInfoInventory> _StoreSearch;
            public StoreItemsBL(IRepository<ChampionInfoInventory> p_StoreSearch)
            {
                _StoreSearch = p_StoreSearch;
            }

        public void AddUpdateInventory(int p_ChampionId, byte p_StoreInventory)
        {
            ChampionInfoInventory RepoUpdate = new ChampionInfoInventory();
            RepoUpdate.ChampionID = p_ChampionId;
            RepoUpdate.ChampionInventory = p_StoreInventory;

            _StoreSearch.replenish(RepoUpdate);
        }

        //==========================================================================
        public List<ChampionInfoInventory> SearchStore(string ChampStoreItems)
        {
            List<ChampionInfoInventory> CurrentListOfStore = _StoreSearch.GetAll();
            List<ChampionInfoInventory> FilteredListOfStore = new List<ChampionInfoInventory>();

            foreach (ChampionInfoInventory StoreSearch in CurrentListOfStore)
           {

               if (StoreSearch.Store == ChampStoreItems)
               {
                   FilteredListOfStore.Add(StoreSearch);
               }
           }

           return FilteredListOfStore;
        }

        public void UpdateInventory(int p_ChampionId, byte p_StoreInventory)
        {
            ChampionInfoInventory RepoUpdate = new ChampionInfoInventory();
            RepoUpdate.ChampionID = p_ChampionId;
            RepoUpdate.ChampionInventory = p_StoreInventory;

            _StoreSearch.update(RepoUpdate);
        }
    }
}