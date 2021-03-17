using CustomTabDemo.Models;
using Ingeniux.CMS;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomTabDemo.Controllers
{
    [Export(typeof(CMSControllerBase))]
    [ExportMetadata("controller", "CustomTabDemoController")]
    [PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.NonShared)]
    public class CustomTabDemoController : CustomTabApplicationController
    {
        public ActionResult Index()
        {
            var model = new CustomTabModel();
            bool isDebug = true;
#if DEBUG
			isDebug = true;
#else
            isDebug = false;
#endif

            model.IsDebug = isDebug;

            using (var session = this._ContentStore.OpenReadSession(_Common.CurrentUser))
            {
                model.UserName = session.OperatingUser.Name;
                var pages = session.Site.Pages(out int pageCount);
                var pageData = pages.Select(p =>
                {
                    return new PageDataModel()
                    {
                        Id = p.Id,
                        Name = p.Name,
                        HasSEODescription = !string.IsNullOrWhiteSpace(p.Element("SEODescription")?.Value),
                        HasSEOKeywords = !string.IsNullOrWhiteSpace(p.Element("SEOKeywords")?.Value),
                        HasSEOTitle = !string.IsNullOrWhiteSpace(p.Element("SEOTitle")?.Value)
                    };
                }).ToArray();
                model.PageData = pageData;
            }

            return View(model);
        }
    }
}