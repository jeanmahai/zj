SET IDENTITY_INSERT [Users] ON
Insert Into [Users] ([SysNo],[UserID],[UserName],[Password],[UserAuthCode],[Status],[InDate],[InUserName],[InUserSysNo],[EditDate],[EditUserName],[EditUserSysNo]) Values('1003','sohoadmin','soho����Ա','310fa523a9c8ae53518e5027dc00419d','7fdc6c89-7490-40f1-a91a-47d768999a1f','100','2014-05-12 21:19:35','System','0',null,null,null)
Insert Into [Users] ([SysNo],[UserID],[UserName],[Password],[UserAuthCode],[Status],[InDate],[InUserName],[InUserSysNo],[EditDate],[EditUserName],[EditUserSysNo]) Values('1004','testadmin','test����Ա','310fa523a9c8ae53518e5027dc00419d','7fdc6c89-7490-40f1-a91a-47d768999a1f','100','2014-05-12 21:19:35','System','0',null,null,null)
Insert Into [Users] ([SysNo],[UserID],[UserName],[Password],[UserAuthCode],[Status],[InDate],[InUserName],[InUserSysNo],[EditDate],[EditUserName],[EditUserSysNo]) Values('1006','Test002','Test001','fe9b35524d2e64764835aaa15a390c77','2bbed257-b8df-4a18-85d7-94a2215b8b8a','0','2014-05-19 22:40:15','System','0','2014-05-19 22:47:31','System','0')
SET IDENTITY_INSERT [Users] OFF

SET IDENTITY_INSERT [LogCategorys] ON
Insert Into [LogCategorys] ([SysNo],[ParentSysNo],[CategoryName],[Status]) Values('1001','0','�������','100')
Insert Into [LogCategorys] ([SysNo],[ParentSysNo],[CategoryName],[Status]) Values('1002','1001','�û�ģ��','100')
Insert Into [LogCategorys] ([SysNo],[ParentSysNo],[CategoryName],[Status]) Values('1003','1001','��ɫģ��','100')
Insert Into [LogCategorys] ([SysNo],[ParentSysNo],[CategoryName],[Status]) Values('1004','1001','Ȩ��ģ��','100')
Insert Into [LogCategorys] ([SysNo],[ParentSysNo],[CategoryName],[Status]) Values('1005','1002','�û�����','100')
Insert Into [LogCategorys] ([SysNo],[ParentSysNo],[CategoryName],[Status]) Values('1006','1003','��ɫ����','100')
Insert Into [LogCategorys] ([SysNo],[ParentSysNo],[CategoryName],[Status]) Values('1007','1004','Ȩ�޲���','100')
SET IDENTITY_INSERT [LogCategorys] OFF