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
        public Computer GetPostById(int postId)
        {
            var sql = @"SELECT [Id], [Brand], [ModelName], [PurchaseDate], [InicialCost], [ExpiredDate], [ExpiredCost]
                        FROM Computer";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("Id", postId));

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

        public void CreateBlogpost(Computer computer)
        {
            //INSERT INTO Computer(Brand,ModelName) VALUES('Good post','Mats Lind')
            //INSERT INTO BlogPost(Title,Author) VALUES('Good post','Mats Lind')
            var sql = "INSERT INTO Computer(Brand,ModelName) VALUES(@Brand,@ModelName)";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("Brand", computer.Brand));
                command.Parameters.Add(new SqlParameter("Title", computer.ModelName));
                command.ExecuteNonQuery();
            }
        }

        public void UpdateBlogpost(Computer computer)
        {
            var sql = "UPDATE BlogPost SET Title=@Title WHERE id=@Id";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("Id", blogPost.Id));
                command.Parameters.Add(new SqlParameter("Title", blogPost.Title));
                command.ExecuteNonQuery();
            }
        }

        public void DeleteBlogpost(Computer computer)
        {
            //DELETE FROM BlogPost WHERE Id=3
            var sql = "DELETE FROM BlogPost WHERE id=@Id";

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

