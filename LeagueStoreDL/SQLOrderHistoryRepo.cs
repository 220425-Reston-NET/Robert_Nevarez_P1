using Summoner;
using Microsoft.Data.SqlClient;

namespace StoreRepo
{
    public class SQLOrderHistoryRepo : IRepository<OrderHistory>
    {
        private readonly string _connectionString;
        public SQLOrderHistoryRepo(string p_connectionString)
        {
            this._connectionString = p_connectionString;
        }
        public void Add(OrderHistory p_resource)
        {
            string SQLquery = @"insert into OrderHistory
                                values (@ChampionName,@TotalBought,@TotalPrice,@StoreName,@SumID);";
             using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SQLquery, con);


                command.Parameters.AddWithValue("@ChampionName", p_resource.ChampionName);
                command.Parameters.AddWithValue("@TotalBought", p_resource.TotalBought);
                command.Parameters.AddWithValue("@StoreName", p_resource.StoreName);
                command.Parameters.AddWithValue("@SumID", p_resource.SumID);
                command.Parameters.AddWithValue("@TotalPrice", p_resource.TotalPrice);

                command.ExecuteNonQuery();

            }
        }
        public List<OrderHistory> GetAll()
        {
            string SQLQuery = @"select o.SumID,s.SumName,o.TotalBought, o.TotalSpent, o.ChampionName, o.StoreName from OrderHistory o
                                inner join Suminfo s on o.SumID = s.SumID;";
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
                        SumID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        TotalBought = reader.GetInt32(2),
                        TotalPrice = reader.GetInt32(3),
                        ChampionName = reader.GetString(4),
                        StoreName = reader.GetString(5),
                    });
                }
            return OrderHistory1;
               }   }

        public List<OrderHistory> GetStoreHistory(string p_resource)
        {
            string SQLQuery = @"select o.SumID,s.SumName,o.TotalBought, o.TotalSpent, o.ChampionName, o.StoreName from OrderHistory o
                                inner join Suminfo s on o.SumID = s.SumID
                                Where o.StoreName = '@StoreName'";
            List<OrderHistory> OrderHistory1 = new List<OrderHistory>();
            
            using (SqlConnection con = new SqlConnection(_connectionString))
            {

                con.Open();


                SqlCommand command = new SqlCommand(SQLQuery, con);

            

                command.Parameters.AddWithValue("@StoreName", p_resource);



                SqlDataReader reader = command.ExecuteReader();

                
                while (reader.Read())
                {
                    //zero based index
                    OrderHistory1.Add(new OrderHistory(){
                        SumID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        TotalBought = reader.GetInt32(2),
                        TotalPrice = reader.GetInt32(3),
                        ChampionName = reader.GetString(4),
                        StoreName = reader.GetString(5),

                    });
                }
            return OrderHistory1;
               }
        }

        public List<OrderHistory> GetSumHistory(string p_resource)
        {
            string SQLQuery = @"select o.SumID,s.SumName,o.TotalBought, o.TotalSpent, o.ChampionName, o.StoreName from OrderHistory o
                                inner join Suminfo s on o.SumID = s.SumID
                                Where s.SumName = '@SumName'";
            List<OrderHistory> OrderHistory1 = new List<OrderHistory>();
            
            using (SqlConnection con = new SqlConnection(_connectionString))
            {

                con.Open();


                SqlCommand command = new SqlCommand(SQLQuery, con);

            

                command.Parameters.AddWithValue("@SumName", p_resource);



                SqlDataReader reader = command.ExecuteReader();

                
                while (reader.Read())
                {
                    //zero based index
                    OrderHistory1.Add(new OrderHistory(){
                        SumID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        TotalBought = reader.GetInt32(2),
                        TotalPrice = reader.GetInt32(3),
                        ChampionName = reader.GetString(4),
                        StoreName = reader.GetString(5),

                    });
                }
            return OrderHistory1;
               }
        }

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