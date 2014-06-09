using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Soho.Utility.Web.Framework;
using SohoWeb.Entity.Statement;
using SohoWeb.Service.Statement;

namespace SohoWeb.WebUI.Controllers
{
    /// <summary>
    /// 报表
    /// </summary>
    public class StatementController : SSLController
    {
        /// <summary>
        /// 用户流失分析报表
        /// </summary>
        /// <returns></returns>
        public ActionResult CustomersLoseAnalyzeFilter()
        {
            var filter = GetParams<CustomersLoseAnalyzeFilter>();

            PortalResult result = new PortalResult()
            {
                Code = 0,
                Success = true,
                Data = StatementService.Instance.CustomersLoseAnalyze(filter),
                Message = ""
            };
            return View(result);
        }

        /// <summary>
        /// 日销售情况报表
        /// </summary>
        /// <returns></returns>
        public ActionResult DaySalesData()
        {
            var filter = GetParams<DaySalesFilter>();

            PortalResult result = new PortalResult()
            {
                Code = 0,
                Success = true,
                Data = StatementService.Instance.DaySalesData(filter),
                Message = ""
            };
            return View(result);
        }

        /// <summary>
        /// 月销售情况报表
        /// </summary>
        /// <returns></returns>
        public ActionResult MonthSalesData()
        {
            var filter = GetParams<MonthSalesFilter>();

            PortalResult result = new PortalResult()
            {
                Code = 0,
                Success = true,
                Data = StatementService.Instance.MonthSalesData(filter),
                Message = ""
            };
            return View(result);
        }
    }
}
