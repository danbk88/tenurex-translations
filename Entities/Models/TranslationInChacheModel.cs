using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TranslationsService.Entities.Models
{
    public class TranslationInChache: ITranslation
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
         public string Id { get; set; }
         public string key { get; set; }
         public string phrase { get; set; }
        public string from_language { get; set; }
        public string to_language { get; set; }
        public string translation { get; set; }

        public TranslationInChache(ITranslation tran)
        {
            this.phrase = tran.phrase;
            this.from_language = tran.from_language;
            this.to_language = tran.to_language;
            this.translation = tran.translation;
            this.key = tran.from_language + tran.to_language + tran.phrase;
        }
    }
}