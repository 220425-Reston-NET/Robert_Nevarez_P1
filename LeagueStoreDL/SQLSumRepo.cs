using Summoner;
using Microsoft.Data.SqlClient;

namespace StoreRepo
{
    public class SQLSumRepo : IRepository<SummonerInfo>
    {

        private string _connectionString;

        //============================================
        public SQLSumRepo(string p_connectionString)
        {
            this._connectionString = p_connectionString;
        }
        //============================================
        public void Add(SummonerInfo p_resource)
        {
            string SQLQuery = @"insert into Suminfo
                                values (@SumName,@SumPhoneNumber,@SumAddress)";
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand command = new SqlCommand(SQLQuery, con);

                //We dynamically changed information using addwithvalue to avoid sql injection
                command.Parameters.AddWithValue("@SumName", p_resource.Name);
                command.Parameters.AddWithValue("@SumPhoneNumber", p_resource.Phonenumber);
                command.Parameters.AddWithValue("@SumAddress", p_resource.Address);
                
                command.ExecuteNonQuery();
            }
        }

        public List<SummonerInfo> GetAll()
        {
            string SQLQuery = @"Select * from Suminfo";
            List<SummonerInfo> listofSummoners = new List<SummonerInfo>();
        
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();


                SqlCommand command = new SqlCommand(SQLQuery, con);


                SqlDataReader reader = command.ExecuteReader();

                
                while (reader.Read())
                {
                    //zero based index
                    listofSummoners.Add(new SummonerInfo(){
                        Name = reader.GetString(1),
                        Phonenumber = reader.GetDouble(2),
                        Address = reader.GetString(3)
                    });
                }
                return listofSummoners;
            }
        }

        public void replenish(SummonerInfo p_resource)
        {
            throw new NotImplementedException();
        }

        public void update(SummonerInfo p_resource)
        {
            string SQLQuery = @"update Suminfo set SumName = @SumName
                                where SumName = @SumName1";
              using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SQLQuery, con);

                command.Parameters.AddWithValue("@SumName", p_resource.Name);
                command.Parameters.AddWithValue("@SumName1", p_resource.Name);
               

                command.ExecuteNonQuery();
            }
        }
    }
}