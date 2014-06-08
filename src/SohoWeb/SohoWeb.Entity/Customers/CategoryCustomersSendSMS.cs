using SohoWeb.Entity.Enums;

namespace SohoWeb.Entity.Customers
{
    /// <summary>
    /// 给分类查询出的用户发送短信对象
    /// </summary>
    public class CategoryCustomersSendSMS
    {
        /// <summary>
        /// 查询的分类用户类型
        /// </summary>
        public CustomerQueryCategory Category { get; set; }
        /// <summary>
        /// 短信内容
        /// </summary>
        public string SMSBody { get; set; }
    }
}
