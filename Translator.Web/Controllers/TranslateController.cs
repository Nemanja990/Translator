using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Translator.Web.Business;
using Translator.Web.Models;

namespace Translator.Web.Controllers
{
    public class TranslateController : Controller
    {
        // GET: Translate
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TextTranslated(TranslateViewModel translateViewModel)
        {
            if (ModelState.IsValid)
            {
                var res = TranslateHelper.TranslateText(translateViewModel.Text);
                TranslateInfoViewModel translateInfoViewModel = new TranslateInfoViewModel(res);
                return View(translateInfoViewModel);
            }
            return View("Index");
        }

        public ActionResult CheckIfTranslated(string text)
        {
            return View();
        }
    }
}