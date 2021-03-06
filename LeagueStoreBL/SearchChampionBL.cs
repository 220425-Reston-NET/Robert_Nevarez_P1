using StoreRepo;
using Summoner;

namespace LeagueStoreBL
{
    public class SearchChampionBL : ILeagueStoreBL<ChampionInfo>
    {
         //==============================Dependecy Injection=========================
            private readonly IRepository<ChampionInfo> _ChampRepo;
            public SearchChampionBL(IRepository<ChampionInfo> p_ChampRepo)
            {
                _ChampRepo = p_ChampRepo;
            }
        //==========================================================================
        public void Add(ChampionInfo p_username)
        {
            ChampionInfo FoundedChampion = Search(p_username.ChampionName);
            if (FoundedChampion == null)
            {
                _ChampRepo.Add(p_username);
            }
            else
            {
                throw new InvalidOperationException ("Champion already exist");
            }

        }

        public List<ChampionInfo> GetAllChampion()
        {
            return _ChampRepo.GetAll();
        }

        public ChampionInfo Search(string p_usernameName)
        {
            return _ChampRepo.GetAll().First(ChampionInfo => ChampionInfo.ChampionName == p_usernameName);
        }


        public void Update(ChampionInfo p_update)
        {
            throw new NotImplementedException();
        }
    }
}