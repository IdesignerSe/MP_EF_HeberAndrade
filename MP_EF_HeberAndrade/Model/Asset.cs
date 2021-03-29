using System;

namespace MP_EF_HeberAndrade
{
                    

    public class Asset : BaseEntity
    {
        public Asset() : base(default) {
        }
        public string Brand { get; set; }
        public string ModelName { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int InicialCost { get; set; }
        public DateTime ExpiredDate { get; set; }
        public int ExpiredCost { get; set; }
    }
}
