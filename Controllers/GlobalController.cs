using addemo.Models;
using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Web.Mvc;
using Sitecore;
using Sitecore.Mvc.Presentation;
using System.Web.Mvc;

namespace addemo.Controllers
{
    public class GlobalController : GlassController
    {
        public ActionResult HeroBanner()
        {
            var model = GetDataSourceItem<HeroBanner>();
            return View("/Views/Global/HeroBanner.cshtml", model);
        }

        public ActionResult CallToAction()
        {
            var model = GetDataSourceItem<CallToAction>();
            return View("/Views/Global/CallToAction.cshtml", model);
        }
    }
}