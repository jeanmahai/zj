using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;

using Soho.Utility;
using Soho.Utility.Web.Framework;
using SohoWeb.Service.InfoMgt;
using SohoWeb.Entity.InfoMgt;
using SohoWeb.Entity;
using SohoWeb.Entity.Enums;
using Soho.EmailAndSMS.Service.Entity;

namespace SohoWeb.WebMgt.Controllers
{
    /// <summary>
    /// 信息管理
    /// </summary>
    public class InfoMgtController : SSLController
    {
        /// <summary>
        /// 获取电子邮件短信模板通用状态枚举列表
        /// </summary>
        /// <returns></returns>
        public ActionResult GetCommonStatusList()
        {
            var dataResult = EnumsHelper.GetKeyValuePairs<CommonStatus>(EnumAppendItemType.Select);
            dataResult.RemoveAt(1);
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
        /// 获取电子邮件短信模板类型枚举列表
        /// </summary>
        /// <returns></returns>
        public ActionResult GetTemplateCategory()
        {
            var dataResult = EnumsHelper.GetKeyValuePairs<EmailAndSMSTemplateCategory>(EnumAppendItemType.Select);
            dataResult.RemoveAt(1);
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
        /// 获取电子邮件状态枚举列表
        /// </summary>
        /// <returns></returns>
        public ActionResult GetEmailStatusList()
        {
            var dataResult = EnumsHelper.GetKeyValuePairs<EmailStatus>(EnumAppendItemType.Select);
            dataResult.RemoveAt(1);
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
        /// 获取短信状态枚举列表
        /// </summary>
        /// <returns></returns>
        public ActionResult GetSMSStatusList()
        {
            var dataResult = EnumsHelper.GetKeyValuePairs<SMSStatus>(EnumAppendItemType.Select);
            dataResult.RemoveAt(1);
            PortalResult result = new PortalResult()
            {
                Code = 0,
                Success = true,
                Data = dataResult,
                Message = ""
            };
            return View(result);
        }

        #region 邮件短信模板管理

        /// <summary>
        /// 添加邮件短信模板
        /// </summary>
        /// <returns></returns>
        public ActionResult InsertEmailAndSMSTemplates()
        {
            var requestVM = GetParams<EmailAndSMSTemplates>();
            this.SetEntityBase(requestVM, true);

            PortalResult result = new PortalResult()
            {
                Code = 0,
                Success = true,
                Data = InfoTemplatesMgtService.Instance.InsertEmailAndSMSTemplates(requestVM),
                Message = ""
            };
            return View(result);
        }

        /// <summary>
        /// 更新邮件短信模板
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateEmailAndSMSTemplates()
        {
            var requestVM = GetParams<EmailAndSMSTemplates>();
            this.SetEntityBase(requestVM, false);

            InfoTemplatesMgtService.Instance.UpdateEmailAndSMSTemplates(requestVM);

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
        /// 查询邮件短信模板
        /// </summary>
        /// <returns></returns>
        public ActionResult QueryEmailAndSMSTemplates()
        {
            var filter = GetParams<EmailAndSMSTemplatesQueryFilter>();
            PortalResult result = new PortalResult()
            {
                Code = 0,
                Success = true,
                Data = InfoTemplatesMgtService.Instance.QueryEmailAndSMSTemplates(filter),
                Message = ""
            };
            return View(result);
        }

        /// <summary>
        /// 根据邮件短信模板编号获取邮件短信模板
        /// </summary>
        /// <returns></returns>
        public ActionResult GetEmailAndSMSTemplatesBySysNo()
        {
            var request = GetParams<List<string>>();

            int sysNo = 0;
            if (request != null && request.Count > 0)
            {
                sysNo = int.Parse(request[0]);
            }

            PortalResult result = new PortalResult()
            {
                Code = 0,
                Success = true,
                Data = InfoTemplatesMgtService.Instance.GetEmailAndSMSTemplatesBySysNo(sysNo),
                Message = ""
            };
            return View(result);
        }

        /// <summary>
        /// 更新邮件短信模板状态
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateEmailAndSMSTemplatesStatus()
        {
            var _EmailAndSMSTemplates = GetParams<EmailAndSMSTemplates>();
            this.SetEntityBase(_EmailAndSMSTemplates, false);
            InfoTemplatesMgtService.Instance.UpdateEmailAndSMSTemplatesStatus(_EmailAndSMSTemplates);

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
        /// 删除邮件短信模板
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteGift()
        {
            var request = GetParams<List<string>>();

            if (request != null && request.Count > 0)
            {
                foreach (string str in request)
                {
                    EmailAndSMSTemplates entity = new EmailAndSMSTemplates()
                    {
                        SysNo = int.Parse(str),
                        Status = Entity.Enums.CommonStatus.Deleted
                    };
                    this.SetEntityBase(entity, false);
                    InfoTemplatesMgtService.Instance.UpdateEmailAndSMSTemplatesStatus(entity);
                }
            }

            PortalResult result = new PortalResult()
            {
                Code = 0,
                Success = true,
                Data = true,
                Message = ""
            };
            return View(result);
        }

        #endregion

        #region 电子邮件

        /// <summary>
        /// 添加电子邮件
        /// </summary>
        /// <returns></returns>
        public ActionResult InsertMail()
        {
            var requestVM = GetParams<EmailEntity>();
            requestVM.Status=EmailStatus.AuditPassed;

            bool bResult = EmailAndSMSService.Instance.InsertMail(requestVM);
            PortalResult result = new PortalResult()
            {
                Code = 0,
                Success = bResult,
                Data = bResult,
                Message = bResult ? "" : "添加失败！"
            };
            return View(result);
        }

        /// <summary>
        /// 批量添加电子邮件
        /// </summary>
        /// <returns></returns>
        public ActionResult BatchInsertMail()
        {
            var requestVM = GetParams<List<EmailEntity>>();

            bool bResult = EmailAndSMSService.Instance.BatchInsertMail(requestVM);
            PortalResult result = new PortalResult()
            {
                Code = 0,
                Success = bResult,
                Data = bResult,
                Message = bResult ? "" : "批量添加失败！"
            };
            return View(result);
        }

        /// <summary>
        /// 查询电子邮件
        /// </summary>
        /// <returns></returns>
        public ActionResult QueryMail()
        {
            var requestVM = GetParams<EmailQueryFilter>();

            PortalResult result = new PortalResult()
            {
                Code = 0,
                Success = true,
                Data = EmailAndSMSService.Instance.QueryMail(requestVM),
                Message = ""
            };
            return View(result);
        }

        #endregion

        #region 短信

        /// <summary>
        /// 添加短信
        /// </summary>
        /// <returns></returns>
        public ActionResult InsertSMS()
        {
            var requestVM = GetParams<SMSEntity>();

            bool bResult = EmailAndSMSService.Instance.InsertSMS(requestVM);
            PortalResult result = new PortalResult()
            {
                Code = 0,
                Success = bResult,
                Data = bResult,
                Message = bResult ? "" : "添加失败！"
            };
            return View(result);
        }

        /// <summary>
        /// 批量添加短信
        /// </summary>
        /// <returns></returns>
        public ActionResult BatchInsertSMS()
        {
            var requestVM = GetParams<List<SMSEntity>>();

            bool bResult = EmailAndSMSService.Instance.BatchInsertSMS(requestVM);
            PortalResult result = new PortalResult()
            {
                Code = 0,
                Success = bResult,
                Data = bResult,
                Message = bResult ? "" : "批量添加失败！"
            };
            return View(result);
        }

        /// <summary>
        /// 查询短信
        /// </summary>
        /// <returns></returns>
        public ActionResult QuerySMS()
        {
            var requestVM = GetParams<SMSQueryFilter>();

            PortalResult result = new PortalResult()
            {
                Code = 0,
                Success = true,
                Data = EmailAndSMSService.Instance.QuerySMS(requestVM),
                Message = ""
            };
            return View(result);
        }

        #endregion
    }
}
