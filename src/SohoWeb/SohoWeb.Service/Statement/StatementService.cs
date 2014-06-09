using System;
using System.Collections;

using Soho.Utility;
using SohoWeb.Entity;
using SohoWeb.Entity.Statement;
using SohoWeb.DataAccess.Statement;

namespace SohoWeb.Service.Statement
{
    public class StatementService : BaseService<StatementService>
    {
        /// <summary>
        /// 用户流失分析报表
        /// </summary>
        /// <param name="filter">条件</param>
        /// <returns></returns>
        public QueryResult<ArrayList> CustomersLoseAnalyze(CustomersLoseAnalyzeFilter filter)
        {
            if (filter.Day <= 0)
            {
                throw new BusinessException("请输入正确的天数！"); 
            }
            return StatementDA.CustomersLoseAnalyze(filter);
        }

        /// <summary>
        /// 日销售情况报表
        /// </summary>
        /// <param name="filter">条件</param>
        /// <returns></returns>
        public QueryResult<ArrayList> DaySalesData(DaySalesFilter filter)
        {
            DateTime dtNow = DateTime.Now;
            if (!DateTime.TryParse(filter.Date, out dtNow))
            {
                throw new BusinessException("请输入正确的日期！");
            }

            return StatementDA.DaySalesData(filter);
        }

        /// <summary>
        /// 月销售情况报表
        /// </summary>
        /// <param name="filter">条件</param>
        /// <returns></returns>
        public QueryResult<ArrayList> MonthSalesData(MonthSalesFilter filter)
        {
            DateTime dtNow = DateTime.Now;
            if (!DateTime.TryParse(string.Format("{0}-01-01", filter.Year), out dtNow))
            {
                throw new BusinessException("请输入正确的年份！");
            }
            if (!DateTime.TryParse(string.Format("{0}-{1}-01", filter.Year, filter.Month), out dtNow))
            {
                throw new BusinessException("请输入正确的月份！");
            }

            return StatementDA.MonthSalesData(filter);
        }
    }
}
