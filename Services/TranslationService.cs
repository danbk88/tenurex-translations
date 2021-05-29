using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TranslationsService.Models;

namespace TranslationsService.Services
{
    public class TranslationService: ITranslationService
    {
            readonly string NODE_RED_URL = "http://localhost:1880/translate?"; 

        public async Task<GoogleTranslation> TranslatePhrase(string fromLanguage, string toLanguage, string phrase){

            using (var client = new HttpClient())
            {
                string url = NODE_RED_URL + "phrase=" + phrase;
                var response = await client.GetAsync(url);
                // if(!response){
                //     return null;
                // }

                string resJson;
                using (var content = response.Content)
                {
                    resJson = await content.ReadAsStringAsync();
                    GoogleTranslation res = JsonSerializer.Deserialize<GoogleTranslation>(resJson);
                    res.from_language = fromLanguage;
                    res.to_language = toLanguage;

                    return res;
                }
            }
            // return null;
        }
    }
}