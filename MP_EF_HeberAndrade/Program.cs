using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace MP_EF_HeberAndrade
{
    class Program
    {
        static void Main(string[] args)
        {
        AssetsContext context;
        IEnumerable<Asset> list;

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($">.............................................................<\n");
            Console.WriteLine($"       Welcomen to IDESIGNER.SE\n");
            Console.WriteLine($">.............................................................<\n");
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine($"              INVENTORY        \n");
            Console.WriteLine($">.............................................................<\n");
            Console.ResetColor();

            WriteLine("     Press key A,B,C or D Instructions: ");
            WriteLine("     a) Back Menu");
            WriteLine("     b) Create an Item");
            WriteLine("     c) Update and Item");
            WriteLine("     d) Delete and Item");

            ConsoleKey command = Console.ReadKey(true).Key;


            void Run()
            {
                new App();
                PageMainMenu();

            }

            void PageMainMenu()
            {
                Header("Menu");
                ConsoleKey command = Console.ReadKey(true).Key;

                if (command == ConsoleKey.A)
                    PageMainMenu();

                if (command == ConsoleKey.B)
                    CreatePost();

                if (command == ConsoleKey.C)
                    PageUpdatePost();

                if (command == ConsoleKey.D)
                    DeletePost();
                ShowAllBlogPostsBrief();


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


                var asset = new Asset();

                asset.Brand = newBrand;
                asset.ModelName = newModelName;
                asset.PurchaseDate = newPurchaseDate;
                asset.InicialCost = newInitialCost;
                asset.ExpiredDate = newExpiredDate;
                asset.ExpiredCost = newExpiredCost;

                using (context = new AssetsContext())
                {
                    context.Computers.Add((Computer)asset);
                    context.SaveChanges();
                }
                Write("Item is now in our list! ");
                Console.ReadKey();
                PageMainMenu();
            }
            void PageUpdatePost()
            {
                Header("Update");

                ShowAllBlogPostsBrief();

                Write("Any Item to update? ");

                int assetId = int.Parse(Console.ReadLine());

                using (context = new AssetsContext())
                {
                    var asset = context.Computers.Find(assetId);

                    WriteLine("The actual Item is: " + assetId);

                    Write("Write a new Item: ");

                    string newBrand = Console.ReadLine();

                    asset.Brand = newBrand;

                    context.SaveChanges();
                }

                Write("Bloggposten uppdaterad.");
                Console.ReadKey();
                PageMainMenu();
            }
            void DeletePost()
            {
                Header("DELETE");

                ShowAllBlogPostsBrief();

                Write("Wich Item to DELETE? ");

                int assetId = int.Parse(Console.ReadLine());
                using (context = new AssetsContext())
                {
                    var asset = context.Computers.Find(assetId);

                    context.Remove(asset);
                    context.SaveChanges();
                }

                Write("Asset Item is  DELETED.");
                Console.ReadKey();
                PageMainMenu();
            }
            void ShowAllBlogPostsBrief()
            {
                using (context = new AssetsContext())
                {
                    var list = context.Computers.ToList();
                }
                foreach (Asset bp in list)
                {
                    WriteLine(bp.Id.ToString().PadRight(5) + bp.Brand.PadRight(30) +
                        bp.ModelName.PadRight(20) + bp.PurchaseDate.ToString().PadRight(5) +
                        bp.InicialCost.ToString().PadRight(5) + bp.ExpiredDate.ToString().PadRight(5) +
                        bp.ExpiredCost.ToString().PadRight(5)
                    );
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
