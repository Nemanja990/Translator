using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Translator.Web.Business
{
    public class JsonResponse
    {
        public string code { get; set; }
        public string lang { get; set; }
        public string[] text { get; set; }
        public string from { get; set; }
    }
    public class TranslateHelper
    {
        private static IRestResponse RequestService(string url, string text, string lang)
        {
            RestClient client = new RestClient()
            {
                BaseUrl = new Uri(string.Format(url, AppCache.API, text, lang))
            };

            var request = new RestRequest()
            {
                Method = Method.GET
            };

            return client.Execute(request);
        }

        public static JsonResponse TranslateText(string text)
        {
            var response = RequestService(AppCache.UrlTranslateLanguage, text, "en");

            var result = JsonConvert.DeserializeObject<JsonResponse>(response.Content);
            result.from = text;
            return result;
        }
    }
}