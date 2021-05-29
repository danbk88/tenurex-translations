using System.Threading.Tasks;
using TranslationsService.Models;

namespace TranslationsService.Services
{
    public interface ITranslationService
    {
         Task<GoogleTranslation> TranslatePhrase(string fromLanguage, string toLanguage, string phrase);
         
    }
}