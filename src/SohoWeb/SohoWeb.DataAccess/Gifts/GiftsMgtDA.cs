using System;
using System.Data;
using System.Collections.Generic;

using SohoWeb.Entity;
using SohoWeb.Entity.Gifts;
using Soho.Utility.DataAccess;
using SohoWeb.Entity.Enums;

namespace SohoWeb.DataAccess.Gifts
{
    public class GiftsMgtDA
    {
        /// <summary>
        /// 添加奖品
        /// </summary>
        /// <param name="entity">奖品信息</param>
        /// <returns></returns>
        public static int InsertGifts(Gift entity)
        {
            DataCommand cmd = DataCommandManager.GetDataCommand("InsertGifts");
            cmd.SetParameterValue<Gift>(entity);
            cmd.ExecuteNonQuery();
            return Convert.ToInt32(cmd.GetParameterValue("@SysNo"));
        }

        /// <summary>
        /// 查询奖品
        /// </summary>
        /// <param name="filter">查询条件</param>
        /// <returns></returns>
        public static QueryResult<Gift> QueryGifts(GiftQueryFilter filter)
        {
            QueryResult<Gift> result = new QueryResult<Gift>();
            result.ServicePageIndex = filter.ServicePageIndex;
            result.PageSize = filter.PageSize;

            PagingInfoEntity page = DataAccessUtil.ToPagingInfo(filter);
            CustomDataCommand cmd = DataCommandManager.CreateCustomDataCommandFromConfig("QueryGifts");
            using (var sqlBuilder = new DynamicQuerySqlBuilder(cmd.CommandText, cmd, page, "SysNo DESC"))
            {
                sqlBuilder.ConditionConstructor.AddCondition(QueryConditionRelationType.AND, "Status", DbType.Int32,
                    "@Status1", QueryConditionOperatorType.NotEqual, CommonStatus.Deleted);
                sqlBuilder.ConditionConstructor.AddCondition(QueryConditionRelationType.AND, "SysNo", DbType.Int32,
                    "@SysNo", QueryConditionOperatorType.Equal, filter.SysNo);
                sqlBuilder.ConditionConstructor.AddCondition(QueryConditionRelationType.AND, "GiftName", DbType.String,
                    "@GiftName", QueryConditionOperatorType.Like, filter.GiftName);
                sqlBuilder.ConditionConstructor.AddCondition(QueryConditionRelationType.AND, "GiftID", DbType.String,
                    "@GiftID", QueryConditionOperatorType.Like, filter.GiftID);
                sqlBuilder.ConditionConstructor.AddCondition(QueryConditionRelationType.AND, "Descriptions", DbType.String,
                    "@Descriptions", QueryConditionOperatorType.Like, filter.Descriptions);
                sqlBuilder.ConditionConstructor.AddCondition(QueryConditionRelationType.AND, "MarketPrice", DbType.Decimal,
                    "@MarketPrice", QueryConditionOperatorType.Like, filter.MarketPrice);
                sqlBuilder.ConditionConstructor.AddCondition(QueryConditionRelationType.AND, "Status", DbType.Int32,
                    "@Status", QueryConditionOperatorType.Equal, filter.Status);

                cmd.CommandText = sqlBuilder.BuildQuerySql();
                result.ResultList = cmd.ExecuteEntityList<Gift>();
                result.TotalCount = Convert.ToInt32(cmd.GetParameterValue("@TotalCount"));

                return result;
            }
        }

        /// <summary>
        /// 更新奖品状态
        /// </summary>
        /// <param name="entity">奖品信息</param>
        public static void UpdateGiftsStatus(Gift entity)
        {
            DataCommand cmd = DataCommandManager.GetDataCommand("UpdateGiftsStatus");
            cmd.SetParameterValue<Gift>(entity);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// 添加奖品发放记录
        /// </summary>
        /// <param name="entity">奖品发放记录信息</param>
        /// <returns></returns>
        public static int InsertGiftsGrantRecord(GiftsGrantRecord entity)
        {
            DataCommand cmd = DataCommandManager.GetDataCommand("InsertGiftsGrantRecord");
            cmd.SetParameterValue<GiftsGrantRecord>(entity);
            cmd.ExecuteNonQuery();
            return Convert.ToInt32(cmd.GetParameterValue("@SysNo"));
        }

        /// <summary>
        /// 查询奖品发放记录
        /// </summary>
        /// <param name="filter">查询条件</param>
        /// <returns></returns>
        public static QueryResult<GiftsGrantRecord> QueryGiftsGrantRecord(GiftsGrantRecordQueryFilter filter)
        {
            QueryResult<GiftsGrantRecord> result = new QueryResult<GiftsGrantRecord>();
            result.ServicePageIndex = filter.ServicePageIndex;
            result.PageSize = filter.PageSize;

            PagingInfoEntity page = DataAccessUtil.ToPagingInfo(filter);
            CustomDataCommand cmd = DataCommandManager.CreateCustomDataCommandFromConfig("QueryGifts");
            using (var sqlBuilder = new DynamicQuerySqlBuilder(cmd.CommandText, cmd, page, "M.SysNo DESC"))
            {
                sqlBuilder.ConditionConstructor.AddCondition(QueryConditionRelationType.AND, "M.SysNo", DbType.Int32,
                    "@SysNo", QueryConditionOperatorType.Equal, filter.SysNo);
                sqlBuilder.ConditionConstructor.AddCondition(QueryConditionRelationType.AND, "M.GiftSysNo", DbType.Int32,
                    "@GiftSysNo", QueryConditionOperatorType.Equal, filter.GiftSysNo);
                sqlBuilder.ConditionConstructor.AddCondition(QueryConditionRelationType.AND, "M.GrantCounts", DbType.Int64,
                    "@GrantCounts", QueryConditionOperatorType.Like, filter.GrantCounts);
                sqlBuilder.ConditionConstructor.AddCondition(QueryConditionRelationType.AND, "M.GrantDate", DbType.DateTime,
                    "@GrantDate", QueryConditionOperatorType.Like, filter.GrantDate);
                sqlBuilder.ConditionConstructor.AddCondition(QueryConditionRelationType.AND, "M.GrantPerson", DbType.String,
                    "@GrantPerson", QueryConditionOperatorType.Like, filter.GrantPerson);
                sqlBuilder.ConditionConstructor.AddCondition(QueryConditionRelationType.AND, "M.GrantPlace", DbType.String,
                    "@GrantPlace", QueryConditionOperatorType.Like, filter.GrantPlace);

                cmd.CommandText = sqlBuilder.BuildQuerySql();
                result.ResultList = cmd.ExecuteEntityList<GiftsGrantRecord>();
                result.TotalCount = Convert.ToInt32(cmd.GetParameterValue("@TotalCount"));

                return result;
            }
        }
    }
}
