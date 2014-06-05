using System;
using System.Runtime.Serialization;

namespace SohoWeb.Entity.Gifts
{
    public class GiftsGrantRecordQueryFilter : FilterBase
    {
        [DataMember]
        public int? SysNo { get; set; }
        /// <summary>
        /// 奖品编号
        /// </summary>
        [DataMember]
        public int? GiftSysNo { get; set; }
        /// <summary>
        /// 发放数量
        /// </summary>
        [DataMember]
        public long? GrantCounts { get; set; }
        /// <summary>
        /// 发放时间
        /// </summary>
        [DataMember]
        public string GrantDate { get; set; }
        /// <summary>
        /// 发放人
        /// </summary>
        [DataMember]
        public string GrantPerson { get; set; }
        /// <summary>
        /// 发放地点
        /// </summary>
        [DataMember]
        public string GrantPlace { get; set; }
    }
}
