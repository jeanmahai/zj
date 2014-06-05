using System;
using System.Runtime.Serialization;

using SohoWeb.Entity.Enums;

namespace SohoWeb.Entity.InfoMgt
{
    [Serializable]
    [DataContract]
    public class EmailAndSMSTemplatesQueryFilter : FilterBase
    {
        [DataMember]
        public int? SysNo { get; set; }
        /// <summary>
        /// 分类：Email-电子邮件模板；SMS-短信模板
        /// </summary>
        [DataMember]
        public string Category { get; set; }
        /// <summary>
        /// 模板内容
        /// </summary>
        [DataMember]
        public string Templates { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [DataMember]
        public CommonStatus? Status { get; set; }
    }
}
