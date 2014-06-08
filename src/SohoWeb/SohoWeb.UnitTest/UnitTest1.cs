using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SohoWeb.Service.Gifts;
using SohoWeb.Entity.Gifts;
using SohoWeb.Service.InfoMgt;
using SohoWeb.Entity.InfoMgt;
using SohoWeb.Entity.Enums;

namespace SohoWeb.UnitTest
{
    /// <summary>
    /// UnitTest1 的摘要说明
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，该上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        //
        // 编写测试时，可以使用以下附加特性:
        //
        // 在运行类中的第一个测试之前使用 ClassInitialize 运行代码
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // 在类中的所有测试都已运行之后使用 ClassCleanup 运行代码
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // 在运行每个测试之前，使用 TestInitialize 来运行代码
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // 在每个测试运行完之后，使用 TestCleanup 来运行代码
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethodQueryGiftsGrantRecord()
        {
            GiftsGrantRecordQueryFilter filter = new GiftsGrantRecordQueryFilter()
            {
                PageIndex = 1,
                PageSize = 10
            };
            var data = GiftsMgtService.Instance.QueryGiftsGrantRecord(filter);
        }

        [TestMethod]
        public void TestMethodQueryGifts()
        {
            GiftQueryFilter filter = new GiftQueryFilter()
            {
                PageIndex = 1,
                PageSize = 10,
                SysNo = 1003
            };
            var data = GiftsMgtService.Instance.QueryGifts(filter); 
        }

        [TestMethod]
        public void TestMethodDeleteGiftsGrantRecord()
        {
            GiftsMgtService.Instance.DeleteGiftsGrantRecord(100002);
        }



        [TestMethod]
        public void TestMethodInsertEmailAndSMSTemplates()
        {
            InfoTemplatesMgtService.Instance.InsertEmailAndSMSTemplates(new EmailAndSMSTemplates()
            {
                Category = "SMS",
                Templates = "您好，您的购物卡已经发放！",
                Status = Entity.Enums.CommonStatus.Valid,
                InUserSysNo = 0,
                InUserName = "Tester"
            });
        }

        [TestMethod]
        public void TestMethodUpdateEmailAndSMSTemplates()
        {
            InfoTemplatesMgtService.Instance.UpdateEmailAndSMSTemplates(new EmailAndSMSTemplates()
            {
                SysNo = 1002,
                Category = "Email",
                Templates = "您好，您的购物卡已经发放入账！",
                Status = Entity.Enums.CommonStatus.InValid,
                EditUserSysNo = 0,
                EditUserName = "Tester"
            });
        }
        
        [TestMethod]
        public void TestMethodUpdateEmailAndSMSTemplatesStatus()
        {
            InfoTemplatesMgtService.Instance.UpdateEmailAndSMSTemplatesStatus(new EmailAndSMSTemplates()
            {
                SysNo = 1002,
                Status = Entity.Enums.CommonStatus.Valid,
                EditUserSysNo = 0,
                EditUserName = "Tester"
            });
        }

        [TestMethod]
        public void TestMethodGetEmailAndSMSTemplatesBySysNo()
        {
            var data = InfoTemplatesMgtService.Instance.GetEmailAndSMSTemplatesBySysNo(1001);
        }

        [TestMethod]
        public void TestMethodQueryEmailAndSMSTemplates()
        {
            EmailAndSMSTemplatesQueryFilter filter = new EmailAndSMSTemplatesQueryFilter()
            {
                PageIndex = 1,
                PageSize = 10,
                Category = "SMS",
                Templates = "您",
                Status = CommonStatus.Valid,
                SysNo = 1001
            };
            var data = InfoTemplatesMgtService.Instance.QueryEmailAndSMSTemplates(filter);
        }
    }
}
