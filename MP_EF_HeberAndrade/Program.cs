using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MP_EF_HeberAndrade
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new AssetsContext();

            using ( dbContext = new AssetsContext())
            {
                Computer computerItem = new Computer("MacBook", "2018 15 inch ", 20180101, 13000, 20211201, 8000);
                string classBrand = computerItem.GetType().Name;
                PropertyInfo brand = computerItem.GetType().GetProperty("Brand");
                List<PropertyInfo> properties = computerItem.GetType().GetProperties().ToList();

                Computer computerItem2 = new Computer("MacBook", "2019 15 inch ", 20180101, 16000, 20211201, 10000);
                List<Computer> computers = new List<Computer>();

                computers.Add(computerItem);
                computers.Add(computerItem2);
                computers = dbContext.Computers.ToList();

                Dictionary<string, int> colWidths = new Dictionary<string, int>();

                foreach (PropertyInfo property in properties)
                {
                    int colLength = property.Name.Length;
                    int tmpLength = 0;
                    int dataLength = 0;

                    foreach (Computer computer in computers)
                    {
                        tmpLength = computers.Max(computer => computer.GetType().GetProperty(property.Name)).GetValue(computer).ToString().Length;
                        dataLength = Math.Max(dataLength, tmpLength);
                    }
                    int maxLength = Math.Max(colLength, dataLength);

                    colWidths.Add(property.Name, maxLength);
                }

                Console.WriteLine();

                //Print Header with correct widths
                foreach (var colWidth in colWidths)
                {
                    Console.Write(colWidth.Key.PadRight(colWidth.Value + 2));
                }

                Console.WriteLine();

                //Print Data with correct widths
                foreach (Computer computer in computers)
                {
                    foreach (var colWidth in colWidths)
                    {
                        var c = computer.GetType().GetProperties().Where(c => c.Name == colWidth.Key).FirstOrDefault();
                        Console.Write(c.GetValue(computer).ToString().PadRight(colWidth.Value + 2));
                    }
                    Console.WriteLine();
                }

                void Run()
                {
                    PageMainMenu();
                }

                void PageMainMenu()
                {
                    Header("Menu");

                    ShowAllBlogPostsBrief();

                    WriteLine("Press key A,B,C or D Instructions: ");
                    WriteLine("a) Back Menu");
                    WriteLine("b) Create an Item");
                    WriteLine("c) Update and Item");
                    WriteLine("d) Delete and Item");

                    ConsoleKey command = Console.ReadKey(true).Key;

                    if (command == ConsoleKey.A)
                        PageMainMenu();

                    if (command == ConsoleKey.B)
                        CreatePost();

                    if (command == ConsoleKey.C)
                        PageUpdatePost();

                    if (command == ConsoleKey.D)
                        DeletePost();
                }


                void ClearDatabase()

                {
                    Asset.RemoveRange(dbContext.Computers);


                    context.SaveChanges();
                }

                static void AddSomeTitles()
                {

                    var computer1 = new Computer("MacBook", "2018 15 inch ", 20180101, 13000, 20211201, 8000);
                    var computer2 = new Computer("MacBook", "2018 15 inch ", 20180101, 13000, 20211201, 8000);

                    using (var context = new AssetsContext())
                    {
                        context.Computers.AddRange(computer1, computer2);
                        context.SaveChanges();
                    }
                }

                void CreatePost()
                {
                    Header("Create");

                    ShowAllBlogPostsBrief();

                    Write("Write an Item: ");

                    string newBrand = Console.ReadLine();
                    //

                    Write("Write model and year: ex. Macbest 2030 ");

                    string newModelName = Console.ReadLine();
                    //

                    Write("Write the date of purchase! ex. 2021/12/01");

                    string newPurchaseDate = Console.ReadLine();

                    //
                    Write("Write the inicial cost! ex. 13,000");

                    string newInitialCost = Console.ReadLine();

                    //
                    Write("Write the Expiration date! # years from now ex.2023/12/01");

                    string newExpiredDate = Console.ReadLine();

                    //

                    Write("Write the Expiration Price! To sale out");

                    string newExpiredCost = Console.ReadLine();


                    Computer computer = new Computer();

                    //Computer.Brand = newBrand;
                    //Computer.ModelName = newModelName;
                    //Computer.PurchaseDate = newPurchaseDate;
                    //Computer.InicialCost = newInitialCost;
                    //Computer.ExpiredDate = newExpiredDate;
                    //Computer.ExpiredCost = newExpiredCost;

                    Write("Item is now in our list! ");
                    Console.ReadKey();
                    PageMainMenu();
                }

                void PageUpdatePost()
                {
                    Header("Uppdatera");

                    ShowAllBlogPostsBrief();

                    Write("Vilken bloggpost vill du uppdatera? ");

                    int computerId = int.Parse(Console.ReadLine());

                    Computer computer = dbContext.GetPostById(computerId);

                    //DbContextId ContextId

                    WriteLine("The actual Item is: " + computerId);

                    Write("Write a new Item: ");

                    string newBrand = Console.ReadLine();

                    Computer.Brand = newBrand;
                    //save


                    dbContext.UpdateBlogpost(computer);

                    Write("Bloggposten uppdaterad.");
                    Console.ReadKey();
                    PageMainMenu();
                }

                void DeletePost()
                {
                    Header("DELETE");

                    ShowAllBlogPostsBrief();

                    Write("Wich Item to DELETE? ");

                    int computerId = int.Parse(Console.ReadLine());

                    Computer computer = dbContext.GetPostById(computerId);

                    dbContext.DeleteBlogpost(computer);

                    Write("Computer Item is  DELETED.");
                    Console.ReadKey();
                    PageMainMenu();
                }

                void ShowAllBlogPostsBrief()
                {
                    List<Computer> list = dbContext.GetAllBlogPostsBrief();

                    foreach (Computer bp in list)
                    {
                        WriteLine(bp.Id.ToString().PadRight(5) + bp.Brand.PadRight(30) + bp.ModelName.PadRight(20) + bp.PurchaseDate.ToString().PadRight(5) + bp.InicialCost.ToString().PadRight(5) + bp.ExpiredDate.ToString().PadRight(5) + bp.ExpiredCost.ToString().PadRight(5));
                    }
                    WriteLine();
                }

                void Header(string text)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine();
                    Console.WriteLine(text.ToUpper());
                    Console.WriteLine();
                }

                void WriteLine(string text = "")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(text);
                }

                void Write(string text)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(text);
                }
            }
        }
    } 
}
