using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MP_EF_HeberAndrade
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($">.............................................................<\n");
            Console.WriteLine($"       Welcome to IDESIGNER.SE\n");
            Console.WriteLine($">.............................................................<\n");

            PageMainMenu();
        }

        static void PageMainMenu()
        {
            ListInventory();
            Menu();
        }

        static void ListInventory()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"            ASSETS  INVENTORY        \n");
            Console.WriteLine($">.............................................................<\n");
            Console.ResetColor();

            using (var dbContext = new AssetsContext())
            {
                //(string brand, string modelName, int purchaseDate, int inicialCost, int expiredDate, int expiredCost)
                // new Asset("MacBook", "Pro 2018 15 inch ", 20180101, 13000, 20211201, 8000),
                dbContext.Add(new Computer("MacBook", "Pro 2018 15 inch ", new DateTime(2018, 1, 1), 13000, new DateTime(2021, 12, 01), 8000));
                dbContext.Add(new Phone("Iphuff", "Pro 2018 15 inch ", new DateTime(2018, 1, 1), 13000, new DateTime(2021, 12, 1), 8000));
                dbContext.Add(new Tv("SamAbsurd", "Pro 2018 15 inch ", new DateTime(2018, 1, 1), 13000, new DateTime(2021, 12, 1), 8000));
                dbContext.SaveChanges();

                var brand = dbContext.Computers
                  .Select(brand => brand.Brand).ToList();

                var modelName = dbContext.Computers
                    .Select(modelName => modelName.ModelName).ToList();
                Console.WriteLine();

                var purchaseDate = dbContext.Computers
                    .Select(purchaseDate => purchaseDate.PurchaseDate).ToList();

                var inicialCost = dbContext.Computers
                 .Select(inicialCost => inicialCost.InicialCost).ToList();

                var expiredDate = dbContext.Computers
                  .Select(expiredDate => expiredDate.ExpiredDate).ToList();

                var expiredCost = dbContext.Computers
                  .Select(expiredCost => expiredCost.ExpiredCost).ToList();

                Console.WriteLine(string.Join("                     Is a Computer Brand.\n", brand));
                Console.WriteLine(string.Join("           Is Computer Model Name\n", modelName));
                Console.WriteLine(string.Join("                    Is a Computer purchase Date\n", purchaseDate));
            }
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($">.............................................................<\n");
            Console.ResetColor();
        }

        static void CreateItem()
        {
            Header("Create");

            Write("Write an Item: ");

            string newBrand = Console.ReadLine();

            Write("Write model and year: ex. Macbest 2030 ");

            string newModelName = Console.ReadLine();

            Write("Write the date of purchase! ex. 2021/12/01");

            var newPurchaseDate = DateTime.Parse(Console.ReadLine());

            Write("Write the inicial cost! ex. 13,000");

            int.TryParse(Console.ReadLine(), out var newInitialCost);

            Write("Write the Expiration date! # years from now ex.2023/12/01");

            var newExpiredDate = DateTime.Parse(Console.ReadLine());

            Write("Write the Expiration Price! To sale out");

            int.TryParse(Console.ReadLine(), out var newExpiredCost);

            var asset = new Computer(
                newBrand,
                newModelName,
                newPurchaseDate,
                newInitialCost,
                newExpiredDate,
                newExpiredCost
            );

            new ComputerService().Create(asset);
            Write("Item is now in our list! ");
            Console.ReadKey();
            PageMainMenu();
            Menu();
        }

        static void PageUpdateItems()
        {
            Header("Create");

            Console.WriteLine("Which item to update? ");

            int itemId = int.Parse(Console.ReadLine());

            Computer computer = new ComputerService().GetById(itemId);

            if (computer == null)
            {
                Console.WriteLine($"An item with id {itemId} does not exist.");
            }
            else
            {
                Console.WriteLine($"Your Actual Item id is: {computer.Id}");
            }

            Menu();
        }
        static void DeleteItem()
        {
            Header("DELETE");

            ShowAllItems();

            Console.Write("Which item to delete? ");

            int itemId = int.Parse(Console.ReadLine());

            Computer blogpost = new ComputerService().GetById(itemId);

            new ComputerService().Delete(blogpost);

            Console.WriteLine("Item is deleted.");
            Console.ReadKey();

            Menu();
        }

        static void ShowAllItems()
        {
            AssetsContext context;

            using (context = new AssetsContext())
            {
                var list = context.Computers.ToList();
                foreach (Asset bp in list)
                {
                    Console.WriteLine(bp.Id.ToString().PadRight(5) + bp.Brand.PadRight(30) +
                        bp.ModelName.PadRight(20) + bp.PurchaseDate.ToString().PadRight(5) +
                        bp.InicialCost.ToString().PadRight(5) + bp.ExpiredDate.ToString().PadRight(5) +
                        bp.ExpiredCost.ToString().PadRight(5)
                    );
                }
            }
            Console.WriteLine();
        }

        static void QuitProgram()
        {
            string insert = Console.ReadLine();
        
            {
                Console.WriteLine("\nBye, Thanks for your visit!\n");
                return;
            }

        }

        static void Menu()
        {
            Console.WriteLine("Press key A,B,C or D Instructions: \n".PadLeft(5));
            Console.WriteLine("a) Back Menu (show items)".PadLeft(5));
            Console.WriteLine("b) Create an Item".PadLeft(5));
            Console.WriteLine("c) Update an Item".PadLeft(5));
            Console.WriteLine("d) Delete an Item".PadLeft(5));
            Console.WriteLine("Key Return twices to QUIT this program".PadLeft(5));


            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($">.............................................................<\n");
            Console.ResetColor();

            ConsoleKey command = Console.ReadKey(true).Key;

            if (command == ConsoleKey.A)
                PageMainMenu();

            if (command == ConsoleKey.B)
                CreateItem();

            if (command == ConsoleKey.C)
                PageUpdateItems();

            if (command == ConsoleKey.D)
                DeleteItem();

            if (command == ConsoleKey.Enter)
                QuitProgram();

        }

        static void Header(string text)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine(text.ToUpper());
            Console.WriteLine();
        }

        static void Write(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
        }


        //             Console.WriteLine("Hello World!");
        //           using (var dbContext = new CustomTreatmentContext())
        //         {
        //           dbContext.Add(new Diet("Superduper diet", "Hard", 2, 200));
        //         dbContext.SaveChanges();
        //       var result = dbContext.Diets.ToList()
        //         .Where(d => d.DietDaysProgram > 0)
        //       .Take(5)
        //     .OrderBy(d => d.DietDaysProgram)
        //                       .Select(d => d.DietName);
        //
        //                 var resultSum = dbContext.Diets
        //                   .Where(d => d.DietDaysProgram > 0)
        //                 .OrderBy(d => d.DietDaysProgram)
        //               .GroupBy(o => 1)
        //             .Select(d =>
        //               "Average days:" + (float)d.Sum(d => d.DietDaysProgram) / (float)Math.Max(1, d.Count()) +
        //             "(total diets: " + d.Count() + ")"
        //       );
        //                   Console.WriteLine(string.Join(", ", result));
        //                 Console.WriteLine(string.Join(", ", resultSum));
        //           }
    }
}
