using System;
using System.Threading.Tasks;
using TranslationsService.Entities;
using TranslationsService.Entities.Models;
using TranslationsService.Services;

namespace TranslationsService.Managers
{
    public class TranslateManager
    {
        private ITranslationService translationService;
        private ICacheService cacheService;

        public TranslateManager(ITranslationService translationService, ICacheService cacheService)
        {
            this.translationService = translationService;
            this.cacheService = cacheService;
        }

        internal async Task<TranslationResultData> translate(string from,string to,string phrase)
        {
            // Try get translation from cache:
            ITranslation translation = cacheService.Get(from, to, phrase);
            bool isCahceHit = translation != null;
            
            if(!isCahceHit){
                // Cache miss - Get translation from Google:
                translation = await translationService.TranslatePhrase(from, to, phrase);
                // Add translation to cache:
                cacheService.Create(translation);
            }

            return new TranslationResultData(translation.translation, isCahceHit);
        }
    }
}