using Summoner;
using StoreRepo;

namespace LeagueStoreBL
{
    public class SearchSummonerBL : ILeagueStoreBL <SummonerInfo>
    {
        
        //==============================Dependecy Injection=========================
            private IRepository<SummonerInfo> _SummonerRepo;
            public SearchSummonerBL(IRepository<SummonerInfo> p_SumInfo)
            {
                _SummonerRepo = p_SumInfo;
            }
        //==========================================================================
        public void Add(SummonerInfo p_username)
        {
            SummonerInfo FoundedSummoner = Search(p_username.Name);
            if (FoundedSummoner == null)
            {
                _SummonerRepo.Add(p_username);
            }
            else
            {
                throw new InvalidOperationException ("Summoner already exist");
            }

        }

        public List<SummonerInfo> GetAllChampion()
        {
            throw new NotImplementedException();
        }

        public SummonerInfo Search(string p_Name)
        {  
            try
            {
                double phone = Convert.ToDouble(p_Name);

                List<SummonerInfo> CurrentListOfSummoners = _SummonerRepo.GetAll();
                // List<SummonerInfo> FilteredListOfSummoners = new List<SummonerInfo>();

            foreach (SummonerInfo SumName in CurrentListOfSummoners)
           {

               if (SumName.Phonenumber == phone)
               {
                //    FilteredListOfSummoners.Add(SumName);
                   return SumName;
               }
           }

                return null;
            }
            catch (FormatException)
            {
                List<SummonerInfo> CurrentListOfSummoners = _SummonerRepo.GetAll();
                // List<SummonerInfo> FilteredListOfSummoners = new List<SummonerInfo>();

            foreach (SummonerInfo SumName in CurrentListOfSummoners)
           {

               if (SumName.Name == p_Name)
               {
                //    FilteredListOfSummoners.Add(SumName);
                   return SumName;
               }
           }

           return null;
            }
        }

        public void Update(SummonerInfo p_update)
        {
            SummonerInfo SumUpdate = new SummonerInfo();
            SumUpdate.Name = p_update.Name;

            _SummonerRepo.update(SumUpdate);

        }
    }
}