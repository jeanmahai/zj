USE [SohoCRM]
GO
/****** Object:  Table [dbo].[GiftsGrantRecord]    Script Date: 06/05/2014 22:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiftsGrantRecord](
	[SysNo] [int] IDENTITY(100001,1) NOT NULL,
	[GiftSysNo] [int] NOT NULL,
	[GrantCounts] [bigint] NOT NULL,
	[GrantDate] [datetime] NULL,
	[GrantPerson] [nvarchar](20) NULL,
	[GrantPlace] [nvarchar](80) NULL,
	[InDate] [datetime] NOT NULL,
	[InUserSysNo] [int] NOT NULL,
	[InUserName] [nvarchar](60) NOT NULL,
	[EditDate] [datetime] NULL,
	[EditUserSysNo] [int] NULL,
	[EditUserName] [nvarchar](60) NULL,
 CONSTRAINT [PK_GiftsGrantRecord] PRIMARY KEY CLUSTERED 
(
	[SysNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gifts]    Script Date: 06/05/2014 22:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gifts](
	[SysNo] [int] IDENTITY(1001,1) NOT NULL,
	[GiftName] [nvarchar](40) NOT NULL,
	[GiftID] [nvarchar](60) NULL,
	[Descriptions] [nvarchar](200) NULL,
	[MarketPrice] [decimal](18, 2) NULL,
	[Status] [int] NOT NULL,
	[InDate] [datetime] NOT NULL,
	[InUserSysNo] [int] NOT NULL,
	[InUserName] [nvarchar](60) NOT NULL,
	[EditDate] [datetime] NULL,
	[EditUserSysNo] [int] NULL,
	[EditUserName] [nvarchar](60) NULL,
 CONSTRAINT [PK_Gifts] PRIMARY KEY CLUSTERED 
(
	[SysNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmailAndSMSTemplates]    Script Date: 06/05/2014 22:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmailAndSMSTemplates](
	[SysNo] [int] IDENTITY(1001,1) NOT NULL,
	[Category] [nvarchar](20) NOT NULL,
	[TemplateCategory] [int] NOT NULL,
	[TemplateName] [nvarchar](60) NOT NULL,
	[Templates] [nvarchar](max) NOT NULL,
	[Status] [int] NOT NULL,
	[InDate] [datetime] NOT NULL,
	[InUserSysNo] [int] NOT NULL,
	[InUserName] [nvarchar](60) NOT NULL,
	[EditDate] [datetime] NULL,
	[EditUserSysNo] [int] NULL,
	[EditUserName] [nvarchar](60) NULL,
 CONSTRAINT [PK_EmailAndSMSTemplates] PRIMARY KEY CLUSTERED 
(
	[SysNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
