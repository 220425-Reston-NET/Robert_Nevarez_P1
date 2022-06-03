using Microsoft.Data.SqlClient;
using Summoner;

namespace StoreRepo
{
    public class SQLStoreChampion : IRepository<ChampionInfoInventory>
    {
        private string _connectionString;

        //============================================
        public SQLStoreChampion(string p_connectionString)
        {
            this._connectionString = p_connectionString;
        }
        public void Add(ChampionInfoInventory p_resource)
        {
            throw new NotImplementedException();
        }

        public List<ChampionInfoInventory> GetAll()
        {
             string SQLQuery = @"select * from Champion c
                                inner join Stores_Champions sc on c.ChampionID = sc.ChampionID
                                inner join Store s on s.StoreID = sc.StoreID";
            List<ChampionInfoInventory> listofChampion = new List<ChampionInfoInventory>();
           
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();


                SqlCommand command = new SqlCommand(SQLQuery, con);

               
                SqlDataReader reader = command.ExecuteReader();

            
                while (reader.Read())
                {
                    
                    listofChampion.Add(new ChampionInfoInventory(){
                        Store = reader.GetString(8),
                        ChampionName = reader.GetString(1),
                        ChampionID = reader.GetInt32(0),
                        RP = reader.GetInt32(2),
                        ChampionInventory = reader.GetByte(6),
                    });
                }
                return listofChampion;
            }
        }

        public void update(ChampionInfoInventory p_resource)
        {
            string SQLquery = @"update Stores_Champions
                            set Inventory = Inventory - @Inventory
                            where ChampionID = @ChampionID";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SQLquery, con);

                command.Parameters.AddWithValue("@Inventory", p_resource.ChampionInventory);
                command.Parameters.AddWithValue("@ChampionID", p_resource.ChampionID);
              

                command.ExecuteNonQuery();
            }
        }

        public void replenish(ChampionInfoInventory p_resource)
        {
            
        {
            string SQLquery = @"update Stores_Champions
                            set Inventory = Inventory + @Inventory
                            where ChampionID = @ChampionID";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SQLquery, con);

                command.Parameters.AddWithValue("@Inventory", p_resource.ChampionInventory);
                command.Parameters.AddWithValue("@ChampionID", p_resource.ChampionID);
              

                command.ExecuteNonQuery();
            }
        }
        }

    }
}