using System;
using System.Linq;
using System.Collections.Generic;

namespace MP_EF_HeberAndrade
{
    class ComputerService
    {
        public Computer GetById(int itemId)
        {
            using (var context = new AssetsContext())
            {
                return context.Computers.Find(itemId);
            }
        }

        public List<Computer> GetAll()
        {
            using (var context = new AssetsContext())
            {
                return context.Computers.ToList();
            }
        }

        public void Create(Computer computer)
        {
            using (var context = new AssetsContext())
            {
                context.Computers.Add(computer);
                context.SaveChanges();
            }
        }

        public void Update(Computer computer)
        {
            using (var context = new AssetsContext())
            {
                var existingComputer = context.Computers.Find(computer.Id);
                existingComputer.Brand = computer.Brand;
                existingComputer.ModelName = computer.ModelName;
                existingComputer.PurchaseDate = computer.PurchaseDate;
                existingComputer.InicialCost = computer.InicialCost;
                existingComputer.ExpiredDate = computer.ExpiredDate;
                existingComputer.ExpiredCost = computer.ExpiredCost;
                context.SaveChanges();
            }
        }

        public void Delete(Computer computer)
        {
            using (var context = new AssetsContext())
            {
                context.Computers.Remove(computer);
                context.SaveChanges();
            }
        }
    }
}
