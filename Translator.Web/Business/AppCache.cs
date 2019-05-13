using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Translator.Web.Business
{
    public class AppCache
    {
        public static string API { get; } = @"trnsl.1.1.20190511T143454Z.288376b40efe0f5c.33c3a0b78ea83e85ca44d964e6f569d7adf73238";
        public static string UrlGetAvailableLanguages { get; } = @"https://translate.yandex.net/api/v1.5/tr.json/getLangs?key={0}&ui={1}";
        public static string UrlDetectSourceLanguage { get; } = @"https://translate.yandex.net/api/v1.5/tr.json/detect?key={0}&text={1}";
        public static string UrlTranslateLanguage { get; } = @"https://translate.yandex.net/api/v1.5/tr.json/translate?key={0}&text={1}&lang={2}";
    }
}