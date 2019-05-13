using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using Translator.API.Models;

namespace Translator.API.Business
{
    public class StorageClass
    {
        public static string FilePath = HttpContext.Current.Server.MapPath(@"~\Translations\") + "Translations.xml";

        public static string SaveData(TranslationInfo translationInfo)
        {
            string filePathAndName = CreateAndSaveXmlFile();
            string ad = AddDataToXml(translationInfo);
            return filePathAndName;
        }

        public static string IsMatchingData(List<SaveDataClass> saveData, string text)
        {
            foreach (var item in saveData)
            {
                if (item.From.Equals(text))
                {
                    return item.To;
                }
            }

            return "No";
        }

        public static List<SaveDataClass> ReadXmlFile(string filePathAndName)
        {
            List<SaveDataClass> saveList = new List<SaveDataClass>();

            XmlDocument doc = new XmlDocument();
            doc.Load(filePathAndName);

            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                SaveDataClass saveData = new SaveDataClass
                {
                    Id = Convert.ToInt32(node.Attributes["id"]?.InnerText),
                    Timestamp = Convert.ToDateTime(node.Attributes["timestamp"]?.InnerText),
                    From = node.SelectSingleNode("from")?.InnerText,
                    To = node.SelectSingleNode("to")?.InnerText
                };

                saveList.Add(saveData);
            }

            return saveList;
        }

        private static string AddDataToXml(TranslationInfo translationInfo)
        {
            XDocument doc = XDocument.Load(FilePath);

            var model = ReadXmlFile(FilePath);

            var exist = model.Any(x => x.From == translationInfo.From);
            if (exist)
                return "";

            int id = doc.Root.Elements().Count() + 1;

            var newEle = new XElement("translation",
                        new XAttribute("timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                        new XAttribute("id", id++.ToString()),
                        new XElement("from", translationInfo.From),
                        new XElement("to", translationInfo.Text));

            doc.Element("translations").Add(newEle);

            doc.Save(FilePath);

            return "";
        }

        public static string CreateAndSaveXmlFile()
        {
            var path = FilePath;

            if (!Directory.Exists(HttpContext.Current.Server.MapPath(@"~\Translations\")))
            {
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(@"~\Translations\"));
            }

            if (File.Exists(path))
            {
                return path;
            }

            using (XmlWriter writer = XmlWriter.Create(path))
            {
                writer.WriteStartElement("translations");
                writer.WriteEndElement();
                writer.Flush();
            }

            return path;
        }
    }
}