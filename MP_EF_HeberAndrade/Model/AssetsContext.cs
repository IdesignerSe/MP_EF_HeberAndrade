using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MP_EF_HeberAndrade
{
    public class AssetsContext : DbContext
    {
        
        public DbSet<Computer> Computers { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Tv> Tvs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source = S5D011\SQLEXPRESS; Initial Catalog = AssetsCatalog;" +
                " Integrated Security = True; Connect Timeout = 30; Encrypt = False;" +
                " TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False"
            );
        }

        private const string conString = @"Server=S5D011\SQLEXPRESS; Database=AssetsCatalog";
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
    }
   
}

