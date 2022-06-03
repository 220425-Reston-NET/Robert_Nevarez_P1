using Summoner;
using Microsoft.Data.SqlClient;

namespace StoreRepo
{
    public class SQLOrderHistoryRepo : IRepository<OrderHistory>
    {
        private string _connectionString;
        public SQLOrderHistoryRepo(string p_connectionString)
        {
            this._connectionString = p_connectionString;
        }
        public void Add(OrderHistory p_resource)
        {
            string SQLquery = @"insert into OrderHistory
                                values (@ChampionName,@TotalBought,1,@StoreName,@SumID";
             using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SQLquery, con);


                command.Parameters.AddWithValue("@ChampionName", p_resource.ChampionName);
                command.Parameters.AddWithValue("@TotalBought", p_resource.TotalBought);
                command.Parameters.AddWithValue("@StoreName", p_resource.StoreName);
                command.Parameters.AddWithValue("@SumID", p_resource.SumID);

                command.ExecuteNonQuery();

            }
        }
        public List<OrderHistory> GetAll()
        {
            string SQLQuery = @"select * from OrderHistory
                                where SumName = @SumName";
            List<OrderHistory> OrderHistory1 = new List<OrderHistory>();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();


                SqlCommand command = new SqlCommand(SQLQuery, con);


                SqlDataReader reader = command.ExecuteReader();

                
                while (reader.Read())
                {
                    //zero based index
                    OrderHistory1.Add(new OrderHistory(){
                        Name = reader.GetString(0),
                    });
                }
            return OrderHistory1;
               }   }

        public void replenish(OrderHistory p_resource)
        {
            throw new NotImplementedException();
        }

        public void update(OrderHistory p_resource)
        {
            throw new NotImplementedException();
        }

    }
}