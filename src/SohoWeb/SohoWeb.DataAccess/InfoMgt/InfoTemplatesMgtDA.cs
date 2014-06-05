using System;
using System.Data;
using System.Collections.Generic;

using SohoWeb.Entity;
using SohoWeb.Entity.InfoMgt;
using Soho.Utility.DataAccess;
using SohoWeb.Entity.Enums;

namespace SohoWeb.DataAccess.InfoMgt
{
    public class InfoTemplatesMgtDA
    {
        /// <summary>
        /// 添加邮件短信模板
        /// </summary>
        /// <param name="entity">邮件短信模板信息</param>
        /// <returns></returns>
        public static int InsertEmailAndSMSTemplates(EmailAndSMSTemplates entity)
        {
            DataCommand cmd = DataCommandManager.GetDataCommand("InsertEmailAndSMSTemplates");
            cmd.SetParameterValue<EmailAndSMSTemplates>(entity);
            cmd.ExecuteNonQuery();
            return Convert.ToInt32(cmd.GetParameterValue("@SysNo"));
        }

        /// <summary>
        /// 更新邮件短信模板
        /// </summary>
        /// <param name="entity">邮件短信模板信息</param>
        public static void UpdateEmailAndSMSTemplates(EmailAndSMSTemplates entity)
        {
            DataCommand cmd = DataCommandManager.GetDataCommand("UpdateEmailAndSMSTemplates");
            cmd.SetParameterValue<EmailAndSMSTemplates>(entity);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// 查询邮件短信模板
        /// </summary>
        /// <param name="filter">查询条件</param>
        /// <returns></returns>
        public static QueryResult<EmailAndSMSTemplates> QueryEmailAndSMSTemplates(EmailAndSMSTemplatesQueryFilter filter)
        {
            QueryResult<EmailAndSMSTemplates> result = new QueryResult<EmailAndSMSTemplates>();
            result.ServicePageIndex = filter.ServicePageIndex;
            result.PageSize = filter.PageSize;

            PagingInfoEntity page = DataAccessUtil.ToPagingInfo(filter);
            CustomDataCommand cmd = DataCommandManager.CreateCustomDataCommandFromConfig("QueryEmailAndSMSTemplates");
            using (var sqlBuilder = new DynamicQuerySqlBuilder(cmd.CommandText, cmd, page, "SysNo DESC"))
            {
                sqlBuilder.ConditionConstructor.AddCondition(QueryConditionRelationType.AND, "Status", DbType.Int32,
                    "@Status1", QueryConditionOperatorType.NotEqual, CommonStatus.Deleted);
                sqlBuilder.ConditionConstructor.AddCondition(QueryConditionRelationType.AND, "SysNo", DbType.Int32,
                    "@SysNo", QueryConditionOperatorType.Equal, filter.SysNo);
                sqlBuilder.ConditionConstructor.AddCondition(QueryConditionRelationType.AND, "Category", DbType.String,
                    "@Category", QueryConditionOperatorType.Like, filter.Category);
                sqlBuilder.ConditionConstructor.AddCondition(QueryConditionRelationType.AND, "Templates", DbType.String,
                    "@Templates", QueryConditionOperatorType.Like, filter.Templates);
                sqlBuilder.ConditionConstructor.AddCondition(QueryConditionRelationType.AND, "Status", DbType.Int32,
                    "@Status", QueryConditionOperatorType.Equal, filter.Status);

                cmd.CommandText = sqlBuilder.BuildQuerySql();
                result.ResultList = cmd.ExecuteEntityList<EmailAndSMSTemplates>();
                result.TotalCount = Convert.ToInt32(cmd.GetParameterValue("@TotalCount"));

                return result;
            }
        }

        /// <summary>
        /// 根据模板编号获取邮件短信模板
        /// </summary>
        /// <param name="sysNo">邮件短信模板编号</param>
        /// <returns></returns>
        public static EmailAndSMSTemplates GetEmailAndSMSTemplatesBySysNo(int sysNo)
        {
            DataCommand cmd = DataCommandManager.GetDataCommand("GetEmailAndSMSTemplatesBySysNo");
            cmd.SetParameterValue("@SysNo", sysNo);
            return cmd.ExecuteEntity<EmailAndSMSTemplates>();
        }

        /// <summary>
        /// 更新邮件短信模板状态
        /// </summary>
        /// <param name="entity">邮件短信模板信息</param>
        public static void UpdateEmailAndSMSTemplatesStatus(EmailAndSMSTemplates entity)
        {
            DataCommand cmd = DataCommandManager.GetDataCommand("UpdateEmailAndSMSTemplatesStatus");
            cmd.SetParameterValue<EmailAndSMSTemplates>(entity);
            cmd.ExecuteNonQuery();
        }
    }
}
