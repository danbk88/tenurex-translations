using TranslationsService.Entities.Models;

namespace TranslationsService.Models
{
    public class GoogleTranslation: ITranslation
    {
        public string phrase { get; set; }
        public string from_language { get; set; }
        public string to_language { get; set; }
        public string translation { get; set; }
    }
}