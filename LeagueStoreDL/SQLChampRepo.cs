using Microsoft.Data.SqlClient;
using Summoner;

namespace StoreRepo
{
    public class SQLChampRepo : IRepository<ChampionInfo>
    {
        private readonly string _connectionString;

        //============================================
        public SQLChampRepo(string p_connectionString)
        {
            this._connectionString = p_connectionString;
        }

        //============================================
        public void Add(ChampionInfo p_resource)
        {
            string SQLQuery = @"insert into Champion
                                values (@Store,@ChampionName,@RPprice)";
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand command = new SqlCommand(SQLQuery, con);

                //We dynamically changed information using addwithvalue to avoid sql injection
                command.Parameters.AddWithValue("@ChampionStore", p_resource.Store);
                command.Parameters.AddWithValue("@ChampionName", p_resource.ChampionName);
                command.Parameters.AddWithValue("@RPprice", p_resource.RPprice);
                
                command.ExecuteNonQuery();
            }
        }

        public List<ChampionInfo> GetAll()
        {
            string SQLQuery = @"select * from Champion c
                                inner join Stores_Champions sc on c.ChampionID = sc.ChampionID
                                inner join Store s on s.StoreID = sc.StoreID";
            List<ChampionInfo> listofChampion = new List<ChampionInfo>();
            /// <summary>
            /// Sqlconnection object is responsible for establishing a connection with your database
            /// </summary>
            /// <param name="con">object created out of sql connection</param>
            /// <_connectionString>String resposible for connecting to the database</returns>
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                /// <summary>
                /// Responsible for executing sql statements to a database
                /// </summary>
                /// <sqlCommand>Object responsible for summary</SQLQuery> It needs a string that is a sql statement. It needs a sqlconnection obj that has a connection to a database

                SqlCommand command = new SqlCommand(SQLQuery, con);

                /// <summary>
                /// SqlDatareader object is responsible for reading information from a SQL server database (Since it gives tavles and tables doesn't exist in c# only classes and objects)
                /// </summary>
                /// <returns></returns>

                SqlDataReader reader = command.ExecuteReader();

                //Mapping the table format that SQL understands to a List collection that C# understands
                //While loop because we don't know how many rows there will be in this table
                //reader.Read() method goes from row to row
                while (reader.Read())
                {
                    //zero based index
                    listofChampion.Add(new ChampionInfo(){
                        Store = reader.GetString(8),
                        ChampionName = reader.GetString(1),
                        RPprice = reader.GetInt32(2),
                    });
                }
                return listofChampion;
            }
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

        public void view(ChampionInfo p_resource)
        {
            throw new NotImplementedException();
        }
    }
}