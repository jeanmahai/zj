using System.Collections.Generic;

using Soho.EmailAndSMS.Service.Processor;
using Soho.EmailAndSMS.Service.Entity;

namespace SohoWeb.Service.InfoMgt
{
    public class EmailAndSMSService : BaseService<EmailAndSMSService>
    {
        /// <summary>
        /// 插入单条电子邮件
        /// </summary>
        /// <param name="entity">邮件信息</param>
        /// <returns></returns>
        public bool InsertMail(EmailEntity entity)
        {
             return EmailProcessor.Instance.InsertMail(entity);
        }

        /// <summary>
        /// 批量插入电子邮件
        /// </summary>
        /// <param name="entityList">邮件信息</param>
        /// <returns></returns>
        public bool BatchInsertMail(List<EmailEntity> entityList)
        {
            return EmailProcessor.Instance.BatchInsertMail(entityList);
        }

        /// <summary>
        /// 查询邮件
        /// </summary>
        /// <param name="filter">查询条件</param>
        /// <returns></returns>
        public QueryResult<EmailEntity> QueryMail(EmailQueryFilter filter)
        {
            return EmailProcessor.Instance.QueryMail(filter);
        }

        /// <summary>
        /// 插入短信
        /// </summary>
        /// <param name="entity">短信信息</param>
        /// <returns></returns>
        public bool InsertSMS(SMSEntity entity)
        {
            return SMSProcessor.Instance.InsertSMS(entity);
        }

        /// <summary>
        /// 批量插入短信
        /// </summary>
        /// <param name="entityList">短信信息</param>
        /// <returns></returns>
        public bool BatchInsertSMS(List<SMSEntity> entityList)
        {
            return SMSProcessor.Instance.BatchInsertSMS(entityList);
        }

        /// <summary>
        /// 查询短息
        /// </summary>
        /// <param name="filter">查询条件</param>
        /// <returns></returns>
        public QueryResult<SMSEntity> QuerySMS(SMSQueryFilter filter)
        {
            return SMSProcessor.Instance.QuerySMS(filter);
        }
    }
}
