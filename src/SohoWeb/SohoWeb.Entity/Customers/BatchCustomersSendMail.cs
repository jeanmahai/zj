using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SohoWeb.Entity.Customers
{
    /// <summary>
    /// 给批量用户发送邮件对象
    /// </summary>
    [Serializable]
    [DataContract]
    public class BatchCustomersSendMail
    {
        /// <summary>
        /// 用户编号列表
        /// </summary>
        [DataMember]
        public List<int> CustomerIDList { get; set; }
        /// <summary>
        /// 邮件标题
        /// </summary>
        [DataMember]
        public string MailTitle { get; set; }
        /// <summary>
        /// 邮件内容
        /// </summary>
        [DataMember]
        public string MailBody { get; set; }
        /// <summary>
        /// 是否是HTML邮件内容
        /// </summary>
        [DataMember]
        public bool IsHtmlMail { get; set; }
    }
}
