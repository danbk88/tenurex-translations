using System;
using System.Collections.Generic;
using MongoDB.Driver;
using TranslationsService.Entities.Models;
using TranslationsService.Entities.Settings;

namespace TranslationsService.Services
{
    public class CacheService : ICacheService
    {
        private readonly IMongoCollection<TranslationInChache> _translations;

        public CacheService(ICacheRepositoySettings settings)
        {
            _translations = initCahce(settings);
        }

        private IMongoCollection<TranslationInChache> initCahce(ICacheRepositoySettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            // Create Capped collection for cache:
            var options = new CreateCollectionOptions();
            options.Capped = true;
            options.MaxSize = 5242880;
            options.MaxDocuments = 5000;
            database.CreateCollection(settings.TranslationsCollectionName, options);

            return database.GetCollection<TranslationInChache>(settings.TranslationsCollectionName);
        }

        public List<TranslationInChache> Get()
        {
            return _translations.Find(translation => true).ToList();
        }

        public TranslationInChache Get(string from, string to, string phrase)
        {
            string key = from + to + phrase;
            return _translations.Find<TranslationInChache>(translation => translation.key == key).FirstOrDefault();
        }

        public TranslationInChache Create(ITranslation translation)
        {
            TranslationInChache tic = new TranslationInChache(translation);
            _translations.InsertOne(tic);
            return tic;
        }

        public void Update(string id, TranslationInChache translationIn)
        {
            _translations.ReplaceOne(translation => translation.Id == id, translationIn);
        }

        public void Remove(TranslationInChache translationIn)
        {
            _translations.DeleteOne(translation => translation.Id == translationIn.Id);
        }

        public void Remove(string id)
        {
            _translations.DeleteOne(translation => translation.Id == id);
        }
    }
}