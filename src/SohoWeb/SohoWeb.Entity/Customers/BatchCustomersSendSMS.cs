using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SohoWeb.Entity.Customers
{
    /// <summary>
    /// 给分类查询出的用户发送短信对象
    /// </summary>
    [Serializable]
    [DataContract]
    public class BatchCustomersSendSMS
    {
        /// <summary>
        /// 用户编号列表
        /// </summary>
        [DataMember]
        public List<int> CustomerIDList { get; set; }
        /// <summary>
        /// 短信内容
        /// </summary>
        [DataMember]
        public string SMSBody { get; set; }
    }
}
