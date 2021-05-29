namespace TranslationsService.Entities
{
    public class TranslationResultData
    {
        public TranslationResultData(string translation, bool cacheHit)
        {
            this.translation = translation;
            this.cacheHit = cacheHit;
        }

        public string translation { get; set; }
        public bool cacheHit { get; set; }
    }
}