USE [ShacongExpress]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 04/25/2014 11:57:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[UserPassword] [nvarchar](50) NOT NULL,
	[CompanyName] [nvarchar](100) NOT NULL,
	[Mobile] [nvarchar](11) NOT NULL,
	[OpenId] [nvarchar](50) NOT NULL,
	[UserType] [smallint] NOT NULL,
	[AuthCode] [nvarchar](50) NOT NULL,
	[AuthDateTime] [datetime] NOT NULL,
	[CreateDateTime] [datetime] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shipper]    Script Date: 04/25/2014 11:57:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shipper](
	[UserId] [int] NOT NULL,
	[CompanyAddress] [nvarchar](100) NOT NULL,
	[Zip] [nvarchar](7) NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
	[RegisteredNumber] [nvarchar](50) NOT NULL,
	[RegisteredCapital] [nvarchar](50) NOT NULL,
	[Scope] [nvarchar](100) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[RealName] [nvarchar](10) NOT NULL,
	[OperatingRealName] [nvarchar](10) NOT NULL,
	[OperatingPosition] [nvarchar](50) NOT NULL,
	[OperatingIDNumber] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Shipper] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MobileAuth]    Script Date: 04/25/2014 11:57:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MobileAuth](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Mobile] [nvarchar](11) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[SendDateTime] [datetime] NOT NULL,
	[AuthDateTime] [datetime] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_MobileAuth] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_MobileAuth_Mobile]    Script Date: 04/25/2014 11:57:25 ******/
ALTER TABLE [dbo].[MobileAuth] ADD  CONSTRAINT [DF_MobileAuth_Mobile]  DEFAULT ('') FOR [Mobile]
GO
/****** Object:  Default [DF_MobileAuth_Code]    Script Date: 04/25/2014 11:57:25 ******/
ALTER TABLE [dbo].[MobileAuth] ADD  CONSTRAINT [DF_MobileAuth_Code]  DEFAULT ('') FOR [Code]
GO
/****** Object:  Default [DF_MobileAuth_SendDateTime]    Script Date: 04/25/2014 11:57:25 ******/
ALTER TABLE [dbo].[MobileAuth] ADD  CONSTRAINT [DF_MobileAuth_SendDateTime]  DEFAULT (getdate()) FOR [SendDateTime]
GO
/****** Object:  Default [DF_MobileAuth_AuthDateTime]    Script Date: 04/25/2014 11:57:25 ******/
ALTER TABLE [dbo].[MobileAuth] ADD  CONSTRAINT [DF_MobileAuth_AuthDateTime]  DEFAULT (getdate()) FOR [AuthDateTime]
GO
/****** Object:  Default [DF_MobileAuth_Status]    Script Date: 04/25/2014 11:57:25 ******/
ALTER TABLE [dbo].[MobileAuth] ADD  CONSTRAINT [DF_MobileAuth_Status]  DEFAULT ((0)) FOR [Status]
GO
/****** Object:  Default [DF_Shipper_CompanyAddress]    Script Date: 04/25/2014 11:57:25 ******/
ALTER TABLE [dbo].[Shipper] ADD  CONSTRAINT [DF_Shipper_CompanyAddress]  DEFAULT ('') FOR [CompanyAddress]
GO
/****** Object:  Default [DF_Shipper_Zip]    Script Date: 04/25/2014 11:57:25 ******/
ALTER TABLE [dbo].[Shipper] ADD  CONSTRAINT [DF_Shipper_Zip]  DEFAULT ('') FOR [Zip]
GO
/****** Object:  Default [DF_Shipper_Address]    Script Date: 04/25/2014 11:57:25 ******/
ALTER TABLE [dbo].[Shipper] ADD  CONSTRAINT [DF_Shipper_Address]  DEFAULT ('') FOR [Address]
GO
/****** Object:  Default [DF_Shipper_RegistrationNumber]    Script Date: 04/25/2014 11:57:25 ******/
ALTER TABLE [dbo].[Shipper] ADD  CONSTRAINT [DF_Shipper_RegistrationNumber]  DEFAULT ('') FOR [RegisteredNumber]
GO
/****** Object:  Default [DF_Shipper_RegisteredCapital]    Script Date: 04/25/2014 11:57:25 ******/
ALTER TABLE [dbo].[Shipper] ADD  CONSTRAINT [DF_Shipper_RegisteredCapital]  DEFAULT ('') FOR [RegisteredCapital]
GO
/****** Object:  Default [DF_Shipper_Scope]    Script Date: 04/25/2014 11:57:25 ******/
ALTER TABLE [dbo].[Shipper] ADD  CONSTRAINT [DF_Shipper_Scope]  DEFAULT ('') FOR [Scope]
GO
/****** Object:  Default [DF_Shipper_Code]    Script Date: 04/25/2014 11:57:25 ******/
ALTER TABLE [dbo].[Shipper] ADD  CONSTRAINT [DF_Shipper_Code]  DEFAULT ('') FOR [Code]
GO
/****** Object:  Default [DF_Shipper_RealName]    Script Date: 04/25/2014 11:57:25 ******/
ALTER TABLE [dbo].[Shipper] ADD  CONSTRAINT [DF_Shipper_RealName]  DEFAULT ('') FOR [RealName]
GO
/****** Object:  Default [DF_Shipper_OperatingRealName]    Script Date: 04/25/2014 11:57:25 ******/
ALTER TABLE [dbo].[Shipper] ADD  CONSTRAINT [DF_Shipper_OperatingRealName]  DEFAULT ('') FOR [OperatingRealName]
GO
/****** Object:  Default [DF_Shipper_OperatingPosition]    Script Date: 04/25/2014 11:57:25 ******/
ALTER TABLE [dbo].[Shipper] ADD  CONSTRAINT [DF_Shipper_OperatingPosition]  DEFAULT ('') FOR [OperatingPosition]
GO
/****** Object:  Default [DF_Shipper_OperatingIDNumber]    Script Date: 04/25/2014 11:57:25 ******/
ALTER TABLE [dbo].[Shipper] ADD  CONSTRAINT [DF_Shipper_OperatingIDNumber]  DEFAULT ('') FOR [OperatingIDNumber]
GO
/****** Object:  Default [DF_Users_UserName]    Script Date: 04/25/2014 11:57:25 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_UserName]  DEFAULT ('') FOR [UserName]
GO
/****** Object:  Default [DF_Users_UserPassword]    Script Date: 04/25/2014 11:57:25 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_UserPassword]  DEFAULT ('') FOR [UserPassword]
GO
/****** Object:  Default [DF_Users_CompanyName]    Script Date: 04/25/2014 11:57:25 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_CompanyName]  DEFAULT ('') FOR [CompanyName]
GO
/****** Object:  Default [DF_Users_Mobile]    Script Date: 04/25/2014 11:57:25 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Mobile]  DEFAULT ('') FOR [Mobile]
GO
/****** Object:  Default [DF_Users_OpenId]    Script Date: 04/25/2014 11:57:25 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_OpenId]  DEFAULT ('') FOR [OpenId]
GO
/****** Object:  Default [DF_Users_UserType]    Script Date: 04/25/2014 11:57:25 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_UserType]  DEFAULT ((1)) FOR [UserType]
GO
/****** Object:  Default [DF_Users_AuthCode]    Script Date: 04/25/2014 11:57:25 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_AuthCode]  DEFAULT ('') FOR [AuthCode]
GO
/****** Object:  Default [DF_Users_AuthDateTime]    Script Date: 04/25/2014 11:57:25 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_AuthDateTime]  DEFAULT (((1900)-(1))-(1)) FOR [AuthDateTime]
GO
/****** Object:  Default [DF_Users_CreateDateTime]    Script Date: 04/25/2014 11:57:25 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_CreateDateTime]  DEFAULT (getdate()) FOR [CreateDateTime]
GO
/****** Object:  Default [DF_Users_Status]    Script Date: 04/25/2014 11:57:25 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Status]  DEFAULT ((0)) FOR [Status]
GO
