using System;
using System.Runtime.Serialization;

namespace SohoWeb.Entity.Statement
{
    /// <summary>
    /// 用户流失分析条件
    /// </summary>
    [Serializable]
    [DataContract]
    public class CustomersLoseAnalyzeFilter : FilterBase
    {
        /// <summary>
        /// 近几天未登陆
        /// </summary>
        [DataMember]
        public int Day { get; set; }
    }
}
