﻿namespace MP_EF_HeberAndrade
{
    public class Asset
    {
        public string Brand { get; set; }
        public string ModelName { get; set; }
        public int PurchaseDate { get; set; }
        public int InicialCost { get; set; }
        public int ExpiredDate { get; set; }
        public int ExpiredCost { get; set; }
        public int Id { get; internal set; }
    }

}
