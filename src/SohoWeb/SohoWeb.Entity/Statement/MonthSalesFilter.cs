using System;
using System.Runtime.Serialization;

namespace SohoWeb.Entity.Statement
{
    /// <summary>
    /// 月销售情况条件
    /// </summary>
    [Serializable]
    [DataContract]
    public class MonthSalesFilter : FilterBase
    {
        /// <summary>
        /// 年
        /// </summary>
        [DataMember]
        public int Year { get; set; }
        /// <summary>
        /// 月
        /// </summary>
        [DataMember]
        public int Month { get; set; }
    }
}
