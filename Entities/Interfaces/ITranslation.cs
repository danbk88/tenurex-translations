namespace TranslationsService.Entities.Models
{
    public interface ITranslation
    {
       string phrase { get; set; }
       string from_language { get; set; }
       string to_language { get; set; }
       string translation { get; set; }
    }
}