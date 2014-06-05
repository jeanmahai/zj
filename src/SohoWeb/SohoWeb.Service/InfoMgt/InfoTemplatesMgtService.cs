using Soho.Utility;
using Soho.Utility.Encryption;

using SohoWeb.Entity;
using SohoWeb.Entity.InfoMgt;
using SohoWeb.DataAccess.InfoMgt;

namespace SohoWeb.Service.InfoMgt
{
    public class InfoTemplatesMgtService : BaseService<InfoTemplatesMgtService>
    {
        /// <summary>
        /// 添加邮件短信模板
        /// </summary>
        /// <param name="entity">邮件短信模板信息</param>
        /// <returns></returns>
        public int InsertEmailAndSMSTemplates(EmailAndSMSTemplates entity)
        {
            return InfoTemplatesMgtDA.InsertEmailAndSMSTemplates(entity);
        }

        /// <summary>
        /// 更新邮件短信模板
        /// </summary>
        /// <param name="entity">邮件短信模板信息</param>
        public void UpdateEmailAndSMSTemplates(EmailAndSMSTemplates entity)
        {
            InfoTemplatesMgtDA.UpdateEmailAndSMSTemplates(entity);
        }

        /// <summary>
        /// 查询邮件短信模板
        /// </summary>
        /// <param name="filter">查询条件</param>
        /// <returns></returns>
        public QueryResult<EmailAndSMSTemplates> QueryEmailAndSMSTemplates(EmailAndSMSTemplatesQueryFilter filter)
        {
            return InfoTemplatesMgtDA.QueryEmailAndSMSTemplates(filter);
        }
        
        /// <summary>
        /// 根据模板编号获取邮件短信模板
        /// </summary>
        /// <param name="sysNo">邮件短信模板编号</param>
        /// <returns></returns>
        public EmailAndSMSTemplates GetEmailAndSMSTemplatesBySysNo(int sysNo)
        {
            return InfoTemplatesMgtDA.GetEmailAndSMSTemplatesBySysNo(sysNo);
        }

        /// <summary>
        /// 更新邮件短信模板状态
        /// </summary>
        /// <param name="entity">邮件短信模板信息</param>
        public void UpdateEmailAndSMSTemplatesStatus(EmailAndSMSTemplates entity)
        {
            InfoTemplatesMgtDA.UpdateEmailAndSMSTemplatesStatus(entity);
        }
    }
}
