using System;
using System.Web.Mvc;
using System.Collections.Generic;
using DevExpress.Web.Mvc;


namespace CS.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            ViewData["CmbValue"] = "Blue";
             return View(LargeDatabaseDataProvider.GetColors());
        }

        public ActionResult DataBindingToLargeDatabasePartial() {
            ViewData["CmbValue"] = Request.Params["cmbValue"];
            return PartialView("GridViewPartial");
        }
    }
}
