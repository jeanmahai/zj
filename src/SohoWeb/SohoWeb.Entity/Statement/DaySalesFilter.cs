using System;
using System.Runtime.Serialization;

namespace SohoWeb.Entity.Statement
{
    /// <summary>
    /// 日销售情况条件
    /// </summary>
    [Serializable]
    [DataContract]
    public class DaySalesFilter : FilterBase
    {
        /// <summary>
        /// 日期
        /// </summary>
        public string Date { get; set; }
    }
}
