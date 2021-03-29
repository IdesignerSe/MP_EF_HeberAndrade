using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MP_EF_HeberAndrade
{
    class AssetsContext : DbContext
    {
        public DbSet<Computer> Computers { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Tv> Tvs { get; set; }
        

        public const string conString = @"Server=S5D011\SQLEXPRESS; Database=Assetscatalog";
        private SqlDbType itemId;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source = S5D011\SQLEXPRESS; Initial Catalog = AssetsCatalog;" +
                " Integrated Security = True; Connect Timeout = 30; Encrypt = False;" +
                " TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False"
            );
        }

       // public List<Computer> GetAllItems()
        
        public Computer GetPostById(int itemId)
        {
            //(string brand, string modelName, int purchaseDate, int inicialCost, int expiredDate, int expiredCost)

            var sql = @"SELECT [Id], [Brand], [ModelName],[PurchaseDate], [InicialCost], [ExpiredDate], [ExpiredCost]
                        FROM Computer 
                        WHERE Id=@Id";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("Id", itemId));

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    //(string brand, string modelName, int purchaseDate, int inicialCost, int expiredDate, int expiredCost)

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
                    return (Computer)bp;

                }

                return null;

            }
        }

        //GetItemById
        public List<Computer> GetAllItems()
        {
            //(string brand, string modelName, int purchaseDate, int inicialCost, int expiredDate, int expiredCost)

            var sql = @"SELECT [Id], [Brand], [ModelName],[PurchaseDate], [InicialCost], [ExpiredDate], [ExpiredCost]
                        FROM Computer 
                        WHERE Id=@Id";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("Id", itemId));

                SqlDataReader reader = command.ExecuteReader();
                {
                    //(string brand, string modelName, int purchaseDate, int inicialCost, int expiredDate, int expiredCost)
                }

                return null;

            }
        }

    }
}
