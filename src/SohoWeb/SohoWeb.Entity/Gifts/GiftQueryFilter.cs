using System;
using System.Runtime.Serialization;

using SohoWeb.Entity.Enums;

namespace SohoWeb.Entity.Gifts
{
    [Serializable]
    [DataContract]
    public class GiftQueryFilter : FilterBase
    {
        [DataMember]
        public int? SysNo { get; set; }
        /// <summary>
        /// 奖品名称
        /// </summary>
        [DataMember]
        public string GiftName { get; set; }
        /// <summary>
        /// 奖品编号，比如：礼品卡号，物品条码号等等，做参考
        /// </summary>
        [DataMember]
        public string GiftID { get; set; }
        /// <summary>
        /// 描述，做参考
        /// </summary>
        [DataMember]
        public string Descriptions { get; set; }
        /// <summary>
        /// 市场价，做参考
        /// </summary>
        [DataMember]
        public decimal? MarketPrice { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [DataMember]
        public CommonStatus? Status { get; set; }
    }
}
