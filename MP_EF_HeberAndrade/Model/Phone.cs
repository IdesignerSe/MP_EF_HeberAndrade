using System;

namespace MP_EF_HeberAndrade

{
    public class Phone : Asset
    {
        public Phone(string brand, string modelName, DateTime purchaseDate, int inicialCost, DateTime expiredDate, int expiredCost)
        {
            Brand = brand;
            ModelName = modelName;
            PurchaseDate = purchaseDate;
            InicialCost = inicialCost;
            ExpiredDate = expiredDate;
            ExpiredCost = expiredCost;
        }
    }
 }
