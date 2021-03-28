namespace MP_EF_HeberAndrade
{
    public class Asset
    {
        public string Brand { get; set; }
        public string ModelName { get; set; }
        public string PurchaseDate { get; set; }
        public string InicialCost { get; set; }
        public string ExpiredDate { get; set; }
        public string ExpiredCost { get; set; }
        public int Id { get; internal set; }
    }

}
