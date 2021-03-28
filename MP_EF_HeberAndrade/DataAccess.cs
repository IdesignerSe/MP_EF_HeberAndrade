using System;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using MP_EF_HeberAndrade;

namespace MP_EF_HeberAndrade

{
    public class DataAccess
    {
        private const string conString = @"Server=S5D011\SQLEXPRESS; Database=AccessCatalog";

        public List<Asset> GetAllBlogPostsBrief()
        {
            var sql = @"SELECT [Id], [Brand], [ModelName], [PurchaseDate], [InicialCost], [ExpiredDate], [ExpiredCost]
                        FROM Asset";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                var list = new List<Asset>();

                while (reader.Read())
                {
                    var bp = new Asset
                    {
                        Id = reader.GetSqlInt32(0).Value,
                        Brand = reader.GetSqlString(1).Value,
                        ModelName = reader.GetSqlString(2).Value,
                        PurchaseDate = reader.GetSqlInt32(3).Value,
                        InicialCost = reader.GetSqlInt32(4).Value,
                        ExpiredDate = reader.GetSqlInt32(5).Value,
                        ExpiredCost = reader.GetSqlInt32(6).Value,
                    };
                    list.Add((Asset)bp);
                }

                return list;
            }
        }
        public Asset GetPostById(int assetId)
        {
            var sql = @"SELECT [Id], [Brand], [ModelName], [PurchaseDate], [InicialCost], [ExpiredDate], [ExpiredCost]
                        FROM Asset";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("Id", assetId));

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    var bp = new Asset
                    {
                        Id = reader.GetSqlInt32(0).Value,
                        Brand = reader.GetSqlString(1).Value,
                        ModelName = reader.GetSqlString(2).Value,
                        PurchaseDate = reader.GetSqlInt32(3).Value,
                        InicialCost = reader.GetSqlInt32(4).Value,
                        ExpiredDate = reader.GetSqlInt32(5).Value,
                        ExpiredCost = reader.GetSqlInt32(6).Value,
                    };
                    return (Asset)bp;
                }

                return null;

            }
        }

        void CreateBlogpost(Asset asset)
        {
            //INSERT INTO Computer(Brand,ModelName) VALUES('Good post','Mats Lind')
            //INSERT INTO BlogPost(Title,Author) VALUES('Good post','Mats Lind')
            var sql = "INSERT INTO Asset(Brand,ModelName, PurchaseDate, InicialCost, ExpiredCost, ExpiredCost) VALUES(@Brand,@ModelName, @PurchaseDate, @InicialCost, @ExpiredDate, @ExpiredCost)";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.Add(new SqlParameter("Id", asset.Id));
                command.Parameters.Add(new SqlParameter("Brand", asset.Brand));
                command.Parameters.Add(new SqlParameter("ModelName", asset.ModelName));
                command.Parameters.Add(new SqlParameter("PurchaseDate", asset.PurchaseDate));
                command.Parameters.Add(new SqlParameter("InicialCost", asset.InicialCost));
                command.Parameters.Add(new SqlParameter("ExpiredDate", asset.ExpiredDate));
                command.Parameters.Add(new SqlParameter("ExpiredCost", asset.ExpiredCost));
                command.ExecuteNonQuery();
            }
        }

        void UpdateBlogpost(Asset asset)
        {
            var sql = "UPDATE Asset SET Brand=@Brand WHERE id=@Id";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("Id", asset.Id));
                command.Parameters.Add(new SqlParameter("Brand", asset.Brand));
                command.Parameters.Add(new SqlParameter("ModelName", asset.ModelName));
                command.Parameters.Add(new SqlParameter("PurchaseDate", asset.ModelName));
                command.Parameters.Add(new SqlParameter("InicialCost", asset.ModelName));
                command.Parameters.Add(new SqlParameter("ExpiredDate", asset.ModelName));
                command.Parameters.Add(new SqlParameter("ExpiredCost", asset.ModelName));
                command.ExecuteNonQuery();
            }
        }

        public void DeleteBlogpost(Asset asset)
        {
            //DELETE FROM BlogPost WHERE Id=3
            var sql = "DELETE FROM Asset WHERE id=@Id";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("Id", asset.Id));
                command.ExecuteNonQuery();
            }
        }
    }
}

