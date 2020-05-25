namespace Recipe.API.Configuration
{
    public class AppSettings
    {
        public string DbConnection { get; set; }
        public string ConsumerGroup { get; set; }
        public string BrokersHosts { get; set; }
    }
}
