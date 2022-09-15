namespace APIsViciBuzz.Models
{
    public interface IMakeOrderStoreDatabaseSettings
    {
        public string MakeOrderCollectionName { get; set; }

        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
