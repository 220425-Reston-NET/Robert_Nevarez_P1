using Summoner;

namespace LeagueStoreBL
{
    public interface IStoreItemsBL
    {
        List <ChampionInfoInventory> SearchStore(string ChampStoreItems);

        void UpdateInventory(int p_ChampionId, byte p_StoreInventory);

        void AddUpdateInventory(int p_ChampionId, byte p_StoreInventory);
    }
}
    