using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Translator.API.Business;
using Translator.API.Models;

namespace Translator.API.Controllers
{
    [EnableCors("*", "*", "*")]
    public class SaveDataController : ApiController
    {
        // GET: api/SaveData
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/SaveData/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/SaveData
        public HttpResponseMessage Post([FromBody]TranslationInfo translationInfo)
        {
            var storagePath = StorageClass.SaveData(translationInfo);
            var name = Path.GetFileName(storagePath);

            var bytes = File.ReadAllBytes(storagePath);
            var dataStream = new MemoryStream(bytes);
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
            httpResponseMessage.Content = new StreamContent(dataStream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = "Translations.xml";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            return httpResponseMessage;
        }

        // PUT: api/SaveData/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SaveData/5
        public void Delete(int id)
        {
        }
    }
}
