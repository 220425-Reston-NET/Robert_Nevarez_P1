using System.Text.Json;
using Summoner;

namespace StoreRepo
{
    public class SummonerInfoRepo : IRepository<SummonerInfo>
    {
        private string _filepath1 = "../LeagueStoreDL/SummonerNameData/SummonerInfo.json";
        public void Add(SummonerInfo p_username)
        {
            List<SummonerInfo> listofsummoners = GetAll();
            listofsummoners.Add(p_username);
            string jsonstring = JsonSerializer.Serialize(listofsummoners, new JsonSerializerOptions{WriteIndented = true});
            File.WriteAllText(_filepath1, jsonstring);

            
        }
        public List<SummonerInfo> GetAll()
        {
            string jsonstring = File.ReadAllText(_filepath1);
            List<SummonerInfo> summonername = JsonSerializer.Deserialize<List<SummonerInfo>>(jsonstring);
            return summonername;
        }

        public List<SummonerInfo> GetStoreHistory(string p_resource)
        {
            throw new NotImplementedException();
        }

        public List<SummonerInfo> GetSumHistory(string p_resource)
        {
            throw new NotImplementedException();
        }

        public void replenish(SummonerInfo p_resource)
        {
            throw new NotImplementedException();
        }

        public void update(SummonerInfo p_resource)
        {
            throw new NotImplementedException();
        }

        public void view(SummonerInfo p_resource)
        {
            throw new NotImplementedException();
        }
    }
}