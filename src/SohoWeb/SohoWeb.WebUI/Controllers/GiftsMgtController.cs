using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;

using Soho.Utility;
using Soho.Utility.Web.Framework;
using SohoWeb.Service.Gifts;
using SohoWeb.Entity.Gifts;
using SohoWeb.Entity;
using SohoWeb.Entity.Enums;

namespace SohoWeb.WebUI.Controllers
{
    /// <summary>
    /// 奖品管理
    /// </summary>
    public class GiftsMgtController : SSLController
    {
        /// <summary>
        /// 获取奖品管理通用状态枚举列表
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

        #region 奖品

        /// <summary>
        /// 添加奖品
        /// </summary>
        /// <returns></returns>
        public ActionResult InsertGifts()
        {
            var requestVM = GetParams<Gift>();
            this.SetEntityBase(requestVM, true);

            PortalResult result = new PortalResult()
            {
                Code = 0,
                Success = true,
                Data = GiftsMgtService.Instance.InsertGifts(requestVM),
                Message = ""
            };
            return View(result);
        }

        /// <summary>
        /// 查询奖品
        /// </summary>
        /// <returns></returns>
        public ActionResult QueryGifts()
        {
            var filter = GetParams<GiftQueryFilter>();
            PortalResult result = new PortalResult()
            {
                Code = 0,
                Success = true,
                Data = GiftsMgtService.Instance.QueryGifts(filter),
                Message = ""
            };
            return View(result);
        }

        /// <summary>
        /// 删除奖品
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteGift()
        {
            var request = GetParams<List<string>>();

            if (request != null && request.Count > 0)
            {
                foreach (string str in request)
                {
                    Gift entity = new Gift()
                    {
                        SysNo = int.Parse(str),
                        Status = Entity.Enums.CommonStatus.Deleted
                    };
                    this.SetEntityBase(entity, false);
                    GiftsMgtService.Instance.UpdateGiftsStatus(entity);
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

        /// <summary>
        /// 更新奖品状态
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateGiftsStatus()
        {
            var gift = GetParams<Gift>();
            this.SetEntityBase(gift, false);
            GiftsMgtService.Instance.UpdateGiftsStatus(gift);

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

        #region 奖品发放记录

        /// <summary>
        /// 添加奖品发放记录
        /// </summary>
        /// <returns></returns>
        public ActionResult InsertGiftsGrantRecord()
        {
            var requestVM = GetParams<GiftsGrantRecord>();
            this.SetEntityBase(requestVM, true);

            PortalResult result = new PortalResult()
            {
                Code = 0,
                Success = true,
                Data = GiftsMgtService.Instance.InsertGiftsGrantRecord(requestVM),
                Message = ""
            };
            return View(result);
        }

        /// <summary>
        /// 查询奖品发放记录
        /// </summary>
        /// <returns></returns>
        public ActionResult QueryGiftsGrantRecord()
        {
            var filter = GetParams<GiftsGrantRecordQueryFilter>();
            PortalResult result = new PortalResult()
            {
                Code = 0,
                Success = true,
                Data = GiftsMgtService.Instance.QueryGiftsGrantRecord(filter),
                Message = ""
            };
            return View(result);
        }

        /// <summary>
        /// 删除奖品发放记录
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteGiftsGrantRecord()
        {
            var request = GetParams<List<string>>();

            int sysNo = 0;
            if (request != null && request.Count > 0)
            {
                sysNo = int.Parse(request[0]);
            }
            GiftsMgtService.Instance.DeleteGiftsGrantRecord(sysNo);

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
