using System.Collections.Generic;
using TranslationsService.Entities.Models;

namespace TranslationsService.Services
{
    public interface ICacheService
    {
        List<TranslationInChache> Get();
        TranslationInChache Get(string from, string to, string phrase);
        TranslationInChache Create(ITranslation translation);
        void Update(string id, TranslationInChache translationIn);
        void Remove(TranslationInChache translationIn);
        void Remove(string id);
    }
}