using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MP_EF_HeberAndrade
{
    class Program
    {
        private static readonly IEnumerable<Asset> list;

        static void Main(string[] args)
        {
            
            using (var dbContext = new AssetsContext())
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($">.............................................................<\n");
                Console.WriteLine($"       Welcomen to IDESIGNER.SE\n");
                Console.WriteLine($">.............................................................<\n");
               
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"            ASSETS  INVENTORY        \n");
                Console.WriteLine($">.............................................................<\n");
                Console.ResetColor();


                //(string brand, string modelName, int purchaseDate, int inicialCost, int expiredDate, int expiredCost)
                // new Asset("MacBook", "Pro 2018 15 inch ", 20180101, 13000, 20211201, 8000),
                dbContext.Add(new Computer("MacBook", "Pro 2018 15 inch ", 20180101, 13000, 20211201, 8000));
                dbContext.Add(new Phone("Iphuff", "Pro 2018 15 inch ", 20180101, 13000, 20211201, 8000));
                dbContext.Add(new Tv("SamAbsurd", "Pro 2018 15 inch ", 20180101, 13000, 20211201, 8000));
                dbContext.SaveChanges();
                
                 var brand = dbContext.Computers.ToList()
                   .Select(brand => brand.Brand);

                var modelName = dbContext.Computers.ToList()
                  .Select(modelName => modelName.ModelName);
                Console.WriteLine();

                var purchaseDate = dbContext.Computers.ToList()
                  .Select(purchaseDate => purchaseDate.PurchaseDate);

                var inicialCost = dbContext.Computers.ToList()
                 .Select(inicialCost => inicialCost.InicialCost);

                var expiredDate = dbContext.Computers.ToList()
                  .Select(expiredDate => expiredDate.ExpiredDate);

                var expiredCost = dbContext.Computers.ToList()
                  .Select(expiredCost => expiredCost.ExpiredCost);

                Console.WriteLine(string.Join("                     Is a Computer Brand.\n", brand));
                Console.WriteLine(string.Join("           Is Computer Model Name\n", modelName));
                Console.WriteLine(string.Join("                    Is a Computer purchase Date\n", purchaseDate));

                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($">.............................................................<\n");
                Console.ResetColor();

                PageMainMenu();

                void PageMainMenu()
                {
                    Menu();
                }

                void CreateItem()
                {
                    Header("Create");
                    Menu();
             
                }
                void PageUpdateItems()
                {
                    Header("Create");

                    Console.WriteLine("Witch Item to update? ");

                    int ItemId = int.Parse(Console.ReadLine());

                    AssetsContext context;

                    using (context = new AssetsContext())
                    {
                        var list = context.Computers.ToList();
                    }

                    Computer computer = DbContext.GetItemById(ItemId);

                    Console.WriteLine("Your Actual Item is: " + computer.Id);

                    Menu();
                }
                void DeleteItem()
                {
                    Header("Create");
                    Menu();
                }

                void ShowAllItems()
                {
                    AssetsContext context;

                    using (context = new AssetsContext())
                    {
                        var list = context.Computers.ToList();
                    }
                    foreach (Asset bp in list)
                    {
                        Console.WriteLine(bp.Id.ToString().PadRight(5) + bp.Brand.PadRight(30) +
                            bp.ModelName.PadRight(20) + bp.PurchaseDate.ToString().PadRight(5) +
                            bp.InicialCost.ToString().PadRight(5) + bp.ExpiredDate.ToString().PadRight(5) +
                            bp.ExpiredCost.ToString().PadRight(5)
                        );
                    }
                    Console.WriteLine();
                }

                void QuitProgram()
                {
                    string insert = Console.ReadLine();
        
                    {
                        Console.WriteLine("\nBye, Thanks for your visit!\n");
                        return;
                    }

                }

                void Menu()
                {
                    Console.WriteLine("Press key A,B,C or D Instructions: \n".PadLeft(5));
                    Console.WriteLine("a) Back Menu".PadLeft(5));
                    Console.WriteLine("b) Create an Item".PadLeft(5));
                    Console.WriteLine("c) Update and Item".PadLeft(5));
                    Console.WriteLine("d) Delete and Item".PadLeft(5));
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

                void Header(string text)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.WriteLine(text.ToUpper());
                    Console.WriteLine();
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
    }
}
