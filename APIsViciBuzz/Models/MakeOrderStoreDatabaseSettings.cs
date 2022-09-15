namespace APIsViciBuzz.Models
{
    public class MakeOrderStoreDatabaseSettings : IMakeOrderStoreDatabaseSettings
    {
        public string MakeOrderCollectionName { get; set ; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set ; } = String.Empty;
    }
}
