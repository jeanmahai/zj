using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace SohoWeb.Entity.Enums
{
    [Serializable]
    [DataContract]
    public enum CustomerQueryCategory
    {
        /// <summary>
        /// 大于等于30天没登录过的用户
        /// </summary>
        [EnumMember]
        [Description("大于等于30天没登录过的用户")]
        ThirtyDayNotLogin = 100,
        /// <summary>
        /// 从未下过订单的用户
        /// </summary>
        [EnumMember]
        [Description("从未下过订单的用户")]
        NotHaveOrder = 200,
        /// <summary>
        /// 近7天未下过订单的用户
        /// </summary>
        [EnumMember]
        [Description("近7天未下过订单的用户")]
        SevenDayNotHaveOrder = 300,
    }
}
