using System;
using System.Collections;
using System.Collections.Generic;

using Soho.Utility;

using SohoWeb.Entity;
using SohoWeb.Entity.Enums;
using SohoWeb.Entity.Customers;
using SohoWeb.Service.InfoMgt;
using SohoWeb.DataAccess.Customers;

namespace SohoWeb.Service.Customers
{
    public class QueryCategoryCustomersService : BaseService<QueryCategoryCustomersService>
    {
        /// <summary>
        /// 查询分类用户
        /// </summary>
        /// <param name="filter">查询条件</param>
        /// <returns></returns>
        public QueryResult<ArrayList> QueryCategoryCustomers(QueryCategoryCustomersFilter filter)
        {
            QueryResult<ArrayList> data = null;

            switch (filter.Category)
            {
                case CustomerQueryCategory.ThirtyDayNotLogin:
                    data = QueryCategoryCustomersDA.QueryThirtyDayNotLoginCustomers(filter);
                    break;
                case CustomerQueryCategory.NotHaveOrder:
                    data = QueryCategoryCustomersDA.QueryNotHaveOrderCustomers(filter);
                    break;
                case CustomerQueryCategory.SevenDayNotHaveOrder:
                    data = QueryCategoryCustomersDA.QuerySevenDayNotHaveOrder(filter);
                    break;
            }

            return data;
        }

        /// <summary>
        /// 给分类查询出的用户发送邮件
        /// </summary>
        /// <param name="entity">邮件内容</param>
        public void SendMail(CategoryCustomersSendMail entity)
        {
            if (string.IsNullOrWhiteSpace(entity.MailTitle))
                throw new BusinessException("请输入邮件标题！");
            if (string.IsNullOrWhiteSpace(entity.MailBody))
                throw new BusinessException("请输入邮件内容！");

            QueryCategoryCustomersFilter filter = new QueryCategoryCustomersFilter()
            {
                PageIndex = 1,
                PageSize = 100000000,
                Category = entity.Category
            };
            QueryResult<ArrayList> queryUsers = QueryCategoryCustomers(filter);
            if (queryUsers != null && queryUsers.ResultList != null && queryUsers.PageCount > 0)
            {
                Soho.EmailAndSMS.Service.Entity.EmailEntity mailEntity = new Soho.EmailAndSMS.Service.Entity.EmailEntity();
                mailEntity.Status = Soho.EmailAndSMS.Service.Entity.EmailStatus.AuditPassed;
                mailEntity.IsBodyHtml = entity.IsHtmlMail;
                mailEntity.InDate = DateTime.Now;
                mailEntity.EmailTitle = entity.MailTitle;
                mailEntity.EmailPriority = System.Net.Mail.MailPriority.Normal;
                mailEntity.EmailBody = entity.MailBody;
                List<Soho.EmailAndSMS.Service.Entity.EmailEntity> sendMailList = new List<Soho.EmailAndSMS.Service.Entity.EmailEntity>();

                ArrayList users = queryUsers.ResultList[0];
                for (int i = 0; i < users.Count; i++)
                {
                    Dictionary<string, object> item = users[i] as Dictionary<string, object>;
                    foreach (var obj in item)
                    {
                        if (obj.Key.Equals("CustomerID"))
                            mailEntity.UserSysNo = int.Parse(obj.Value.ToString());
                        if (obj.Key.Equals("TrueName"))
                            mailEntity.ReceiveName = obj.Value.ToString();
                        if (obj.Key.Equals("Email"))
                            mailEntity.ReceiveAddress = obj.Value.ToString();
                    }
                    if (!string.IsNullOrEmpty(mailEntity.ReceiveAddress))
                    { 
                        sendMailList.Add(mailEntity);
                    }
                }
                EmailAndSMSService.Instance.BatchInsertMail(sendMailList);
            }
        }

        /// <summary>
        /// 给分类查询出的用户发送短信
        /// </summary>
        /// <param name="entity">短信内容</param>
        public void SendSMS(CategoryCustomersSendSMS entity)
        {
            if (string.IsNullOrWhiteSpace(entity.SMSBody))
                throw new BusinessException("请输入短信内容！");

            QueryCategoryCustomersFilter filter = new QueryCategoryCustomersFilter()
            {
                PageIndex = 1,
                PageSize = 100000000,
                Category = entity.Category
            };
            QueryResult<ArrayList> queryUsers = QueryCategoryCustomers(filter);
            if (queryUsers != null && queryUsers.ResultList != null && queryUsers.PageCount > 0)
            {
                Soho.EmailAndSMS.Service.Entity.SMSEntity smsEntity = new Soho.EmailAndSMS.Service.Entity.SMSEntity();
                smsEntity.Status = Soho.EmailAndSMS.Service.Entity.SMSStatus.AuditPassed;
                smsEntity.InDate = DateTime.Now;
                smsEntity.SMSBody = entity.SMSBody;
                List<Soho.EmailAndSMS.Service.Entity.SMSEntity> sendSMSList = new List<Soho.EmailAndSMS.Service.Entity.SMSEntity>();

                ArrayList users = queryUsers.ResultList[0];
                for (int i = 0; i < users.Count; i++)
                {
                    Dictionary<string, object> item = users[i] as Dictionary<string, object>;
                    foreach (var obj in item)
                    {
                        if (obj.Key.Equals("CustomerID"))
                            smsEntity.UserSysNo = int.Parse(obj.Value.ToString());
                        if (obj.Key.Equals("TrueName"))
                            smsEntity.ReceiveName = obj.Value.ToString();
                        if (obj.Key.Equals("ComMobile"))
                            smsEntity.ReceivePhoneNumber = obj.Value.ToString();
                    }
                    if (!string.IsNullOrEmpty(smsEntity.ReceivePhoneNumber))
                    {
                        sendSMSList.Add(smsEntity);
                    }
                }
                EmailAndSMSService.Instance.BatchInsertSMS(sendSMSList);
            }
        }
    }
}
