using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;

using Soho.Utility;
using Soho.Utility.Web.Framework;
using SohoWeb.Service.InfoMgt;
using SohoWeb.Entity.InfoMgt;
using SohoWeb.Entity;
using SohoWeb.Entity.Enums;

namespace SohoWeb.WebUI.Controllers
{
    public class InfoMgtController : SSLController
    {
        /// <summary>
        /// 获取奖品管理通用状态枚举列表
        /// </summary>
        /// <returns></returns>
        public ActionResult GetCommonStatusList()
        {
            PortalResult result = new PortalResult()
            {
                Code = 0,
                Success = true,
                Data = EnumsHelper.GetKeyValuePairs<CommonStatus>(EnumAppendItemType.Select),
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
    }
}
