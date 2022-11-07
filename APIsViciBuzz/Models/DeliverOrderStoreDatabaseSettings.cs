namespace APIsViciBuzz.Models
{
    public class DeliverOrderStoreDatabaseSettings : IDeliverOrderStoreDatabaseSettings     
    {
        public string DeliverOrderCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
