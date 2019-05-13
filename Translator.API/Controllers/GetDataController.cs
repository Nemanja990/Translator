using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Translator.API.Business;

namespace Translator.API.Controllers
{
    public class StringClass
    {
        public string Text { get; set; }
    }

    [EnableCors("*", "*", "*")]
    public class GetDataController : ApiController
    {
        public static string FilePath = ConfigurationManager.AppSettings["FilePath"] + "Translations.xml";

        // GET: api/GetData
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/GetData/5
        [HttpGet]
        public string Get(string text)
        {
            return "";
        }

        // POST: api/GetData
        public string Post([FromBody]StringClass value)
        {
            StorageClass.CreateAndSaveXmlFile();
            var items = StorageClass.ReadXmlFile(FilePath);
            var result = StorageClass.IsMatchingData(items, value.Text);

            if (result.Equals("") || result.Equals("No"))
            {
                return "No";
            }
            else
            {
                return result;
            }
        }

        // PUT: api/GetData/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/GetData/5
        public void Delete(int id)
        {
        }
    }
}
