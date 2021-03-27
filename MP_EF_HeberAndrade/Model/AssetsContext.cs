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

        public List<Computer> GetAllBlogPostsBrief()
        {
            var sql = @"SELECT [Id], [Author], [Title]
                        FROM BlogPost";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                var list = new List<Computer>();

                while (reader.Read())
                {
                    var bp = new BlogPost
                    {
                        Id = reader.GetSqlInt32(0).Value,
                        Author = reader.GetSqlString(1).Value,
                        Title = reader.GetSqlString(2).Value
                    };
                    list.Add(bp);
                }

                return list;

            }
        }
    }
   
}

