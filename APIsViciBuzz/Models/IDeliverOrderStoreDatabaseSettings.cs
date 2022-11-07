namespace APIsViciBuzz.Models
{
    public interface IDeliverOrderStoreDatabaseSettings
    {
        public string DeliverOrderCollectionName { get; set; }

        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
