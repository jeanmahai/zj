using System;
using System.Data;
using System.Collections;

using SohoWeb.Entity;
using SohoWeb.Entity.Statement;
using Soho.Utility.DataAccess;

namespace SohoWeb.DataAccess.Statement
{
    /// <summary>
    /// 报表
    /// </summary>
    public class StatementDA
    {
        /// <summary>
        /// 用户流失分析报表
        /// </summary>
        /// <param name="filter">条件</param>
        /// <returns></returns>
        public static StatementResult<ArrayList> CustomersLoseAnalyze(CustomersLoseAnalyzeFilter filter)
        {
            StatementResult<ArrayList> result = new StatementResult<ArrayList>();
            result.ServicePageIndex = filter.ServicePageIndex;
            result.PageSize = filter.PageSize;

            PagingInfoEntity page = DataAccessUtil.ToPagingInfo(filter);
            CustomDataCommand cmd = DataCommandManager.CreateCustomDataCommandFromConfig("CustomersLoseAnalyze");
            using (var sqlBuilder = new DynamicQuerySqlBuilder(cmd.CommandText, cmd, page, "LogDate ASC"))
            {
                sqlBuilder.ConditionConstructor.AddCondition(QueryConditionRelationType.AND, "LogDate", DbType.DateTime,
                    "@LogDate", QueryConditionOperatorType.LessThan, DateTime.Parse(DateTime.Now.AddDays(-1 * filter.Day).ToShortDateString()));

                cmd.CommandText = sqlBuilder.BuildQuerySql();
                result.Result = DbHelper.DatatableConvertArrayList(cmd.ExecuteDataTable());
                result.TotalCount = Convert.ToInt32(cmd.GetParameterValue("@TotalCount"));

                return result;
            }
        }

        /// <summary>
        /// 日销售情况报表
        /// </summary>
        /// <param name="filter">条件</param>
        /// <returns></returns>
        public static StatementResult<ArrayList> DaySalesData(DaySalesFilter filter)
        {
            StatementResult<ArrayList> result = new StatementResult<ArrayList>();
            result.ServicePageIndex = filter.ServicePageIndex;
            result.PageSize = filter.PageSize;

            PagingInfoEntity page = DataAccessUtil.ToPagingInfo(filter);
            CustomDataCommand cmd = DataCommandManager.CreateCustomDataCommandFromConfig("DaySalesData");
            using (var sqlBuilder = new DynamicQuerySqlBuilder(cmd.CommandText, cmd, page, "LogDate DESC"))
            {
                DateTime beginDate = DateTime.Parse(filter.Date);
                sqlBuilder.ConditionConstructor.AddCondition(QueryConditionRelationType.AND, "LogDate", DbType.DateTime,
                    "@BeginLogDate", QueryConditionOperatorType.MoreThanOrEqual, beginDate);
                DateTime endDate = beginDate.AddDays(1);
                sqlBuilder.ConditionConstructor.AddCondition(QueryConditionRelationType.AND, "LogDate", DbType.DateTime,
                    "@EndLogDate", QueryConditionOperatorType.LessThan, endDate);

                cmd.CommandText = sqlBuilder.BuildQuerySql();
                result.Result = DbHelper.DatatableConvertArrayList(cmd.ExecuteDataTable());
                result.TotalCount = Convert.ToInt32(cmd.GetParameterValue("@TotalCount"));
                result.TotalValue = Convert.ToDecimal(cmd.GetParameterValue("@TotalAmount"));

                return result;
            }
        }

        /// <summary>
        /// 月销售情况报表
        /// </summary>
        /// <param name="filter">条件</param>
        /// <returns></returns>
        public static StatementResult<ArrayList> MonthSalesData(MonthSalesFilter filter)
        {
            StatementResult<ArrayList> result = new StatementResult<ArrayList>();
            result.ServicePageIndex = filter.ServicePageIndex;
            result.PageSize = filter.PageSize;

            PagingInfoEntity page = DataAccessUtil.ToPagingInfo(filter);
            CustomDataCommand cmd = DataCommandManager.CreateCustomDataCommandFromConfig("MonthSalesData");
            using (var sqlBuilder = new DynamicQuerySqlBuilder(cmd.CommandText, cmd, page, "LogDate DESC"))
            {
                DateTime beginDate = DateTime.Parse(string.Format("{0}-{1}-01", filter.Year, filter.Month));
                sqlBuilder.ConditionConstructor.AddCondition(QueryConditionRelationType.AND, "LogDate", DbType.DateTime,
                    "@BeginLogDate", QueryConditionOperatorType.MoreThanOrEqual, beginDate);
                DateTime endDate = beginDate.AddMonths(1);
                sqlBuilder.ConditionConstructor.AddCondition(QueryConditionRelationType.AND, "LogDate", DbType.DateTime,
                    "@EndLogDate", QueryConditionOperatorType.LessThan, endDate);

                cmd.CommandText = sqlBuilder.BuildQuerySql();
                result.Result = DbHelper.DatatableConvertArrayList(cmd.ExecuteDataTable());
                result.TotalCount = Convert.ToInt32(cmd.GetParameterValue("@TotalCount"));
                result.TotalValue = Convert.ToDecimal(cmd.GetParameterValue("@TotalAmount"));

                return result;
            }
        }
    }
}
