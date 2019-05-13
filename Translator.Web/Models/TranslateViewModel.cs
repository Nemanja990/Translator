using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Translator.Web.Business;

namespace Translator.Web.Models
{
    public class TranslateViewModel
    {
        [Required]
        public string Text { get; set; }
        public string TranslatedText { get; set; }
    }

    public class TranslateInfoViewModel
    {
        public string _code { get; set; }
        public string _lang { get; set; }
        public string _text { get; set; }
        public string _from { get; set; }

        public TranslateInfoViewModel(JsonResponse jsonResponse)
        {
            _code = jsonResponse.code;
            _lang = jsonResponse.lang;
            _text = jsonResponse.text.Length > 0 ? jsonResponse.text[0] : "";
            _from = jsonResponse.from;
        }
    }
}