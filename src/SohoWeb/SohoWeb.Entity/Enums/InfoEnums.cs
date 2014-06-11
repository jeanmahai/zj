using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace SohoWeb.Entity.Enums
{
    /// <summary>
    /// 邮件/短信模板类型
    /// </summary>
    [Serializable]
    [DataContract]
    public enum EmailAndSMSTemplateCategory
    {
        /// <summary>
        /// 用户生日模板
        /// </summary>
        [EnumMember]
        [Description("用户生日模板")]
        UserBirthday = 100
    }
}
