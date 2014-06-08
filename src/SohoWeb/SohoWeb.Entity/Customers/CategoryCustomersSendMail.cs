using SohoWeb.Entity.Enums;

namespace SohoWeb.Entity.Customers
{
    /// <summary>
    /// 给分类查询出的用户发送邮件对象
    /// </summary>
    public class CategoryCustomersSendMail
    {
        /// <summary>
        /// 查询的分类用户类型
        /// </summary>
        public CustomerQueryCategory Category { get; set; }
        /// <summary>
        /// 邮件标题
        /// </summary>
        public string MailTitle { get; set; }
        /// <summary>
        /// 邮件内容
        /// </summary>
        public string MailBody { get; set; }
        /// <summary>
        /// 是否是HTML邮件内容
        /// </summary>
        public bool IsHtmlMail { get; set; }
    }
}
