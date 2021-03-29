using System;
using System.Linq;
using System.Collections.Generic;

namespace MP_EF_HeberAndrade
{
    class PhoneService
    {
        public Phone GetById(int itemId)
        {
            using (var context = new AssetsContext())
            {
                return context.Phones.Find(itemId);
            }
        }

        public List<Phone> GetAll()
        {
            using (var context = new AssetsContext())
            {
                return context.Phones.ToList();
            }
        }

        public void Create(Phone Phone)
        {
            using (var context = new AssetsContext())
            {
                context.Phones.Add(Phone);
                context.SaveChanges();
            }
        }

        public void Update(Phone Phone)
        {
            using (var context = new AssetsContext())
            {
                var existingPhone = context.Phones.Find(Phone.Id);
                existingPhone.Brand = Phone.Brand;
                existingPhone.ModelName = Phone.ModelName;
                existingPhone.PurchaseDate = Phone.PurchaseDate;
                existingPhone.InicialCost = Phone.InicialCost;
                existingPhone.ExpiredDate = Phone.ExpiredDate;
                existingPhone.ExpiredCost = Phone.ExpiredCost;
                context.SaveChanges();
            }
        }

        public void Delete(Phone Phone)
        {
            using (var context = new AssetsContext())
            {
                context.Phones.Remove(Phone);
                context.SaveChanges();
            }
        }
    }
}
