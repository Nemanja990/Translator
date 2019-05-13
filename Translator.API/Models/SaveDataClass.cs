using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Translator.API.Models
{
    public class SaveDataClass
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string From { get; set; }
        public string To { get; set; }
    }
}