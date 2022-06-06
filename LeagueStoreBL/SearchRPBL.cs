using Summoner;
using StoreRepo;
using System;

namespace LeagueStoreBL
{
    public class SearchRPBL : IRPBL
    {
        //==============================Dependecy Injection=========================
            private readonly IRepository<ChampionInfo> _ChampRepoRP;
            public SearchRPBL(IRepository<ChampionInfo> p_ChampRepoRP)
            {
                _ChampRepoRP = p_ChampRepoRP;
            }
        // =========================================================================

        public List<ChampionInfo> GetAllRP()
        {
            return _ChampRepoRP.GetAll();
        }
        public List<ChampionInfo> SearchByRP(int p_ChampRP)
        {
            List<ChampionInfo> CurrentListOfRP = _ChampRepoRP.GetAll();
            List<ChampionInfo> FilteredListOfRP = new List<ChampionInfo>();

            foreach (ChampionInfo ChampRP in CurrentListOfRP)
           {

               if (ChampRP.RPprice == p_ChampRP)
               {
                   FilteredListOfRP.Add(ChampRP);
               }
           }

           return FilteredListOfRP;
        }
    }
}