using System.Text.Json;
using Summoner;

namespace StoreRepo
{
    public class ChampionInfoRepo : IRepository<ChampionInfo>
    {
        private string _filepath2 = "../LeagueStoreDL/SummonerNameData/ChampionInfo.json";
        public void Add(ChampionInfo p_Champ)
        {
            List<ChampionInfo> listofChampions = GetAll();
            listofChampions.Add(p_Champ);
            string jsonstring1 = JsonSerializer.Serialize(listofChampions, new JsonSerializerOptions{WriteIndented = true});
            File.WriteAllText(_filepath2, jsonstring1);

            
        }
        public List<ChampionInfo> GetAll()
        {
            string jsonstring1 = File.ReadAllText(_filepath2);
            List<ChampionInfo> Championname = JsonSerializer.Deserialize<List<ChampionInfo>>(jsonstring1);
            return Championname;
        }

        public List<ChampionInfo> GetStoreHistory(string p_resource)
        {
            throw new NotImplementedException();
        }

        public List<ChampionInfo> GetSumHistory(string p_resource)
        {
            throw new NotImplementedException();
        }

        public void replenish(ChampionInfo p_resource)
        {
            throw new NotImplementedException();
        }

        public void update(ChampionInfo p_resource)
        {
            throw new NotImplementedException();
        }
    }
}