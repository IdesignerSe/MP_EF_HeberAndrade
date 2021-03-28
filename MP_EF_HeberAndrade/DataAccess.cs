using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
//using MP_EF_HeberAndrade.AssetsContext;

namespace MP_EF_HeberAndrade

{
    public class DataAccess
    {
        private const string conString = @"Server=S5D011\SQLEXPRESS; Database=AccessCatalog";

        public List<Computer> GetAllBlogPostsBrief()
        {
            var sql = @"SELECT [Id], [Brand], [ModelName], [PurchaseDate], [InicialCost], [ExpiredDate], [ExpiredCost]
                        FROM Computer";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                var list = new List<Computer>();

                while (reader.Read())
                {
                    var bp = new Computer
                    {
                        Id = reader.GetSqlInt32(0).Value,
                        Brand = reader.GetSqlString(1).Value,
                        ModelName = reader.GetSqlString(2).Value,
                        PurchaseDate = reader.GetSqlInt32(3).Value,
                        InicialCost = reader.GetSqlInt32(4).Value,
                        ExpiredDate = reader.GetSqlInt32(5).Value,
                        ExpiredCost = reader.GetSqlInt32(6).Value,
                    };
                    list.Add(bp);
                }

                return list;
            }
        }
        public Computer GetPostById(int computerId)
        {
            var sql = @"SELECT [Id], [Brand], [ModelName], [PurchaseDate], [InicialCost], [ExpiredDate], [ExpiredCost]
                        FROM Computer";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("Id", computerId));

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    var bp = new Computer
                    {
                        Id = reader.GetSqlInt32(0).Value,
                        Brand = reader.GetSqlString(1).Value,
                        ModelName = reader.GetSqlString(2).Value,
                        PurchaseDate = reader.GetSqlInt32(3).Value,
                        InicialCost = reader.GetSqlInt32(4).Value,
                        ExpiredDate = reader.GetSqlInt32(5).Value,
                        ExpiredCost = reader.GetSqlInt32(6).Value,
                    };
                    return bp;

                }

                return null;

            }
        }

        void CreateBlogpost(Computer computer)
        {
            //INSERT INTO Computer(Brand,ModelName) VALUES('Good post','Mats Lind')
            //INSERT INTO BlogPost(Title,Author) VALUES('Good post','Mats Lind')
            var sql = "INSERT INTO Computer(Brand,ModelName) VALUES(@Brand,@ModelName, @PurchaseDate, @InicialCost, @ExpiredDate, @ExpiredCost)";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.Add(new SqlParameter("Id", computer.Id));
                command.Parameters.Add(new SqlParameter("Brand", computer.Brand));
                command.Parameters.Add(new SqlParameter("ModelName", computer.ModelName));
                command.Parameters.Add(new SqlParameter("PurchaseDate", computer.PurchaseDate));
                command.Parameters.Add(new SqlParameter("InicialCost", computer.InicialCost));
                command.Parameters.Add(new SqlParameter("ExpiredDate", computer.ExpiredDate));
                command.Parameters.Add(new SqlParameter("ExpiredCost", computer.ExpiredCost));
                command.ExecuteNonQuery();
            }
        }

        void UpdateBlogpost(Computer computer)
        {
            var sql = "UPDATE Computer SET Brand=@Brand WHERE id=@Id";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("Id", computer.Id));
                command.Parameters.Add(new SqlParameter("Brand", computer.Brand));
                command.Parameters.Add(new SqlParameter("ModelName", computer.ModelName));
                command.Parameters.Add(new SqlParameter("PurchaseDate", computer.ModelName));
                command.Parameters.Add(new SqlParameter("InicialCost", computer.ModelName));
                command.Parameters.Add(new SqlParameter("ExpiredDate", computer.ModelName));
                command.Parameters.Add(new SqlParameter("ExpiredCost", computer.ModelName));
                command.ExecuteNonQuery();
            }
        }

        public void DeleteBlogpost(Computer computer)
        {
            //DELETE FROM BlogPost WHERE Id=3
            var sql = "DELETE FROM Computer WHERE id=@Id";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("Id", computer.Id));
                command.ExecuteNonQuery();
            }
        }
    }
}

