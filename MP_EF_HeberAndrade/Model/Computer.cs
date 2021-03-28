namespace MP_EF_HeberAndrade

{
    public class Computer : Asset
    {
        public Computer(string brand, string modelName, string purchaseDate, string inicialCost, string expiredDate, string expiredCost)
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
