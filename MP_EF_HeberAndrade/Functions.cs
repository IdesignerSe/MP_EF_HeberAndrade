using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MP_EF_HeberAndrade
{
    public class Functions
    {
        static AssetsContext context = new AssetsContext();

        public static void ClearDatabase()
        {
            context.RemoveRange(context.Computers);
            context.SaveChanges();
        }

       

        public static void AddComputers()
        {

            Computer computerItem4 = new Computer("NoteBook", "2011 15 inch ", 20180101, 3000, 20211201, 1000);
            Computer computerItem5 = new Computer("NoteBook", "2019 15 inch ", 20180101, 3000, 20211201, 500);


            using (var context = new AssetsContext())
            {
                context.Computers.AddRange(computerItem4, computerItem5);
                context.SaveChanges();
            }
        }
    }
}
