using Google.Apis.Auth.OAuth2;
using Google.Cloud.Translation.V2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslationFileEditor.Services
{
    public class GoogleTranslationService
    {
        private GoogleCredential Credentials { get; set; }
        private TranslationClient TranslationClient { get; set; }

        public GoogleTranslationService()
        {
            string json = File.ReadAllText(@"C:\Users\Maxime\Source\Repos\TranslationFileEditor\TranslationFileEditor\Credentials\GoogleTranslationApi.json");
            Credentials = GoogleCredential.FromJson(json);
            TranslationClient = TranslationClient.Create(Credentials);
        }

        public string Translate(string text, string sourceLanguage, string targetLanguage)
        {
            TranslationResult response = TranslationClient.TranslateText(text, targetLanguage, sourceLanguage);

            return response.TranslatedText;
        }
    }
}
