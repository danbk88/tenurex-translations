namespace TranslationsService.Entities.Settings
{
    public class CacheRepositoySettings : ICacheRepositoySettings
    {
        public string TranslationsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ICacheRepositoySettings
    {
        string TranslationsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}