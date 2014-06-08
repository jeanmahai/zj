using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SohoWeb.Entity.Customers;
using Soho.Utility.Web.Framework;
using SohoWeb.Service.Customers;
using SohoWeb.Entity;
using SohoWeb.Entity.Enums;

namespace SohoWeb.WebUI.Controllers
{
    public class CustomerQueryCategoryController : SSLController
    {
        /// <summary>
        /// 获取分类用户查询类型枚举列表
        /// </summary>
        /// <returns></returns>
        public ActionResult GetCommonStatusList()
        {
            var dataResult = EnumsHelper.GetKeyValuePairs<CustomerQueryCategory>(EnumAppendItemType.Select);
            PortalResult result = new PortalResult()
            {
                Code = 0,
                Success = true,
                Data = dataResult,
                Message = ""
            };
            return View(result);
        }

        /// <summary>
        /// 查询分类用户
        /// </summary>
        /// <returns></returns>
        public ActionResult QueryEmailAndSMSTemplates()
        {
            var filter = GetParams<QueryCategoryCustomersFilter>();

            PortalResult result = new PortalResult()
            {
                Code = 0,
                Success = true,
                Data = QueryCategoryCustomersService.Instance.QueryCategoryCustomers(filter),
                Message = ""
            };
            return View(result);
        }

        /// <summary>
        /// 给分类查询出的用户发送邮件
        /// </summary>
        /// <returns></returns>
        public ActionResult SendMail()
        {
            var requestVM = GetParams<CategoryCustomersSendMail>();

            QueryCategoryCustomersService.Instance.SendMail(requestVM);

            PortalResult result = new PortalResult()
            {
                Code = 0,
                Success = true,
                Data = true,
                Message = ""
            };
            return View(result);
        }

        /// <summary>
        /// 给分类查询出的用户发送邮件
        /// </summary>
        /// <returns></returns>
        public ActionResult SendSMS()
        {
            var requestVM = GetParams<CategoryCustomersSendSMS>();

            QueryCategoryCustomersService.Instance.SendSMS(requestVM);

            PortalResult result = new PortalResult()
            {
                Code = 0,
                Success = true,
                Data = true,
                Message = ""
            };
            return View(result);
        }
    }
}
