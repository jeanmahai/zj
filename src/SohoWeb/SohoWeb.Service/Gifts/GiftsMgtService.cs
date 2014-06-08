using Soho.Utility;
using Soho.Utility.Encryption;

using SohoWeb.Entity;
using SohoWeb.Entity.Gifts;
using SohoWeb.DataAccess.Gifts;
using System;

namespace SohoWeb.Service.Gifts
{
    public class GiftsMgtService : BaseService<GiftsMgtService>
    {
        /// <summary>
        /// 添加奖品
        /// </summary>
        /// <param name="entity">奖品信息</param>
        /// <returns></returns>
        public int InsertGifts(Gift entity)
        {
            return GiftsMgtDA.InsertGifts(entity);
        }

        /// <summary>
        /// 查询奖品
        /// </summary>
        /// <param name="filter">查询条件</param>
        /// <returns></returns>
        public QueryResult<Gift> QueryGifts(GiftQueryFilter filter)
        {
            return GiftsMgtDA.QueryGifts(filter);
        }

        /// <summary>
        /// 更新奖品状态
        /// </summary>
        /// <param name="entity">奖品信息</param>
        public void UpdateGiftsStatus(Gift entity)
        {
            GiftsMgtDA.UpdateGiftsStatus(entity);
        }

        /// <summary>
        /// 添加奖品发放记录
        /// </summary>
        /// <param name="entity">奖品发放记录信息</param>
        /// <returns></returns>
        public int InsertGiftsGrantRecord(GiftsGrantRecord entity)
        {
            return GiftsMgtDA.InsertGiftsGrantRecord(entity);
        }

        /// <summary>
        /// 查询奖品发放记录
        /// </summary>
        /// <param name="filter">查询条件</param>
        /// <returns></returns>
        public QueryResult<GiftsGrantRecord> QueryGiftsGrantRecord(GiftsGrantRecordQueryFilter filter)
        {
            var data = GiftsMgtDA.QueryGiftsGrantRecord(filter);
            data.ResultList.ForEach(m =>
            {
                m.GrantDate = DateTime.Parse(m.GrantDate).ToShortDateString();
            });
            return data;
        }

        /// <summary>
        /// 删除奖品发放记录
        /// </summary>
        /// <param name="sysNo">奖品发放记录编号</param>
        public void DeleteGiftsGrantRecord(int sysNo)
        {
            GiftsMgtDA.DeleteGiftsGrantRecord(sysNo);
        }
    }
}
