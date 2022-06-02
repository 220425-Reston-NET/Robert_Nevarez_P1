namespace LeagueStoreBL;

/// <summary>
/// Business Layer is responsible for further validation or process of data obtained from the database or the user
/// What kind of process? That all depends on the type of functionality you will be doing
/// </summary>

public interface ILeagueStoreBL <T>
{
    /// <summary>
    /// Add Summoner Info to the Database
    /// </summary>
    /// <param name="p_username"> This is the summoner object that will be added to the DB</param>
    /// <returns>Gives back the Summoner thaty gets added to the DB</returns>
    public void Add(T p_username);

    /// <summary>
    /// This will search summoner profile using their summoner name
    /// </summary>
    /// <param name="p_usernameName"></param>
    /// <returns></returns>
    public T Search(string p_usernameName);

     public void Update(T p_update);
    
    public List<T> GetAllChampion();
}
