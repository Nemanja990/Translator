using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Translator.API.Models
{
    public class TranslationInfo
    {
        public string Code { get; set; }
        public string Lang { get; set; }
        public string Text { get; set; }
        public string From { get; set; }
    }
}