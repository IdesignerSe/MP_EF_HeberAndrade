﻿namespace MP_EF_HeberAndrade

{
    public class Computer : Asset
    {
        public Computer(string brand, string modelName, int purchaseDate, int inicialCost, int expiredDate, int expiredCost)
        {
            Brand = brand;
            ModelName = modelName;
            PurchaseDate = purchaseDate;
            InicialCost = inicialCost;
            ExpiredDate = expiredDate;
            ExpiredCost = expiredCost;
        }
        public int Id { get; set; }
    }
}
