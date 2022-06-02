using Summoner;

namespace LeagueStoreBL
{
    public interface IRPBL
    {
        List<ChampionInfo> GetAllRP();



        List <ChampionInfo> SearchByRP(int p_ChampRP);
    }
}