using System;
using SohoWeb.Entity;
using System.Collections;
using SohoWeb.Entity.Customers;
using Soho.Utility.DataAccess;

namespace SohoWeb.DataAccess.Customers
{
    public class QueryCategoryCustomersDA
    {
        /// <summary>
        /// 查询大于等于30天没登录过的用户
        /// </summary>
        /// <param name="filter">查询条件</param>
        /// <returns></returns>
        public static QueryResult<ArrayList> QueryThirtyDayNotLoginCustomers(QueryCategoryCustomersFilter filter)
        {
            QueryResult<ArrayList> result = new QueryResult<ArrayList>();
            result.ServicePageIndex = filter.ServicePageIndex;
            result.PageSize = filter.PageSize;

            PagingInfoEntity page = DataAccessUtil.ToPagingInfo(filter);
            CustomDataCommand cmd = DataCommandManager.CreateCustomDataCommandFromConfig("QueryThirtyDayNotLoginCustomers");
            using (var sqlBuilder = new DynamicQuerySqlBuilder(cmd.CommandText, cmd, page, "CustomerID DESC"))
            {
                cmd.CommandText = sqlBuilder.BuildQuerySql();
                result.Result = DbHelper.DatatableConvertArrayList(cmd.ExecuteDataTable());
                result.TotalCount = Convert.ToInt32(cmd.GetParameterValue("@TotalCount"));

                return result;
            }
        }

        /// <summary>
        /// 查询从未下过订单的用户
        /// </summary>
        /// <param name="filter">查询条件</param>
        /// <returns></returns>
        public static QueryResult<ArrayList> QueryNotHaveOrderCustomers(QueryCategoryCustomersFilter filter)
        {
            QueryResult<ArrayList> result = new QueryResult<ArrayList>();
            result.ServicePageIndex = filter.ServicePageIndex;
            result.PageSize = filter.PageSize;

            PagingInfoEntity page = DataAccessUtil.ToPagingInfo(filter);
            CustomDataCommand cmd = DataCommandManager.CreateCustomDataCommandFromConfig("QueryNotHaveOrderCustomers");
            using (var sqlBuilder = new DynamicQuerySqlBuilder(cmd.CommandText, cmd, page, "CustomerID DESC"))
            {
                cmd.CommandText = sqlBuilder.BuildQuerySql();
                result.Result = DbHelper.DatatableConvertArrayList(cmd.ExecuteDataTable());
                result.TotalCount = Convert.ToInt32(cmd.GetParameterValue("@TotalCount"));

                return result;
            }
        }

        /// <summary>
        /// 查询近7天未下过订单的用户
        /// </summary>
        /// <param name="filter">查询条件</param>
        /// <returns></returns>
        public static QueryResult<ArrayList> QuerySevenDayNotHaveOrder(QueryCategoryCustomersFilter filter)
        {
            QueryResult<ArrayList> result = new QueryResult<ArrayList>();
            result.ServicePageIndex = filter.ServicePageIndex;
            result.PageSize = filter.PageSize;

            PagingInfoEntity page = DataAccessUtil.ToPagingInfo(filter);
            CustomDataCommand cmd = DataCommandManager.CreateCustomDataCommandFromConfig("QuerySevenDayNotHaveOrder");
            using (var sqlBuilder = new DynamicQuerySqlBuilder(cmd.CommandText, cmd, page, "CustomerID DESC"))
            {
                cmd.CommandText = sqlBuilder.BuildQuerySql();
                result.Result = DbHelper.DatatableConvertArrayList(cmd.ExecuteDataTable());
                result.TotalCount = Convert.ToInt32(cmd.GetParameterValue("@TotalCount"));

                return result;
            }
        }

        /// <summary>
        /// 根据用户编号获取用户
        /// </summary>
        /// <param name="customerID">用户编号</param>
        /// <returns></returns>
        public static ArrayList GetCustomerByCustomerID(int customerID)
        {
            DataCommand cmd = DataCommandManager.GetDataCommand("GetCustomerByCustomerID");
            cmd.SetParameterValue("@CustomerID", customerID);
            return DbHelper.DatatableConvertArrayList(cmd.ExecuteDataTable());
        }
    }
}
