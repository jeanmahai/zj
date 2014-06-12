using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SohoWeb.WebMgt.Controllers
{
    /// <summary>
    /// 母版页
    /// </summary>
    public class MasterController : SSLController
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}
