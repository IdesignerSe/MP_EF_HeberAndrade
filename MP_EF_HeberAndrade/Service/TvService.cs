using System;
using System.Linq;
using System.Collections.Generic;

namespace MP_EF_HeberAndrade
{
    class TvService
    {
        public Tv GetById(int itemId)
        {
            using (var context = new AssetsContext())
            {
                return context.Tvs.Find(itemId);
            }
        }

        public List<Tv> GetAll()
        {
            using (var context = new AssetsContext())
            {
                return context.Tvs.ToList();
            }
        }

        public void Create(Tv Tv)
        {
            using (var context = new AssetsContext())
            {
                context.Tvs.Add(Tv);
                context.SaveChanges();
            }
        }

        public void Update(Tv Tv)
        {
            using (var context = new AssetsContext())
            {
                var existingTv = context.Tvs.Find(Tv.Id);
                existingTv.Brand = Tv.Brand;
                existingTv.ModelName = Tv.ModelName;
                existingTv.PurchaseDate = Tv.PurchaseDate;
                existingTv.InicialCost = Tv.InicialCost;
                existingTv.ExpiredDate = Tv.ExpiredDate;
                existingTv.ExpiredCost = Tv.ExpiredCost;
                context.SaveChanges();
            }
        }

        public void Delete(Tv Tv)
        {
            using (var context = new AssetsContext())
            {
                context.Tvs.Remove(Tv);
                context.SaveChanges();
            }
        }
    }
}
