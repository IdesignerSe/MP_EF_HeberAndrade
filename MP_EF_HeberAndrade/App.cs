using System;
using System.Collections.Generic;
using System.Text;

namespace MP_EF_HeberAndrade
{
    public class App
    {
        static AssetsContext context = new AssetsContext();

        public void Run()
        {
            Functions.ClearDatabase();                //Körs en gång sedan kommenteras ut
            Functions.AddSomeTitles();                //Körs en gång sedan kommenteras ut
            MainMenu();
        }
        public void MainMenu()
        {
            Header("Huvudmeny");

            ShowAllBlogPostsBrief();

            Console.WriteLine("\nWhat do you want to do?");
            Console.WriteLine("a) Gå till huvudmeny");
            Console.WriteLine("b) Uppdatera en blogpost");
            ConsoleKey command = Console.ReadKey(true).Key;

            if (command == ConsoleKey.A)
                MainMenu();

            if (command == ConsoleKey.B)
                PageUpdatePost();
        }

        private void PageUpdatePost()
        {
            Header("Uppdatera");

            ShowAllBlogPostsBrief();

            Write("\nVilken bloggpost vill du uppdatera? ");

            int blogPostId = int.Parse(Console.ReadLine());

            var blogPost = context.Computers.Find(blogPostId);

            WriteLine("Den nuvarande titeln är: " + blogPost.Brand);

            Write("Skriv in ny titel: ");

            string newTitle = Console.ReadLine();

            blogPost.Brand = newTitle;

            context.Computers.Update(blogPost);
            context.SaveChanges();

            Write("Bloggposten uppdaterad.");
            Console.ReadKey();
            MainMenu();
        }

        private void ShowAllBlogPostsBrief()
        {
            foreach (var x in context.Computers)
            {
                WriteLine(x.Id.ToString().PadRight(5) + x.Brand.PadRight(30) + x.ModelName.PadRight(20));
            }
        }

        private void Header(string text)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine();
            Console.WriteLine(text.ToUpper());
            Console.WriteLine();
        }
        private void WriteLine(string text = "")
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(text);
        }

        private void Write(string text)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(text);
        }
    }

}
