USE [www.bkcoding.com]
GO
/****** Object:  Table [dbo].[release]    Script Date: 10/11/2017 14:26:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[release](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[postsID] [int] NOT NULL,
	[mfcID] [int] NOT NULL,
	[mfcOtherName] [nvarchar](50) NOT NULL,
	[time] [datetime] NOT NULL,
	[isTop] [bit] NOT NULL,
 CONSTRAINT [PK_release] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[posts]    Script Date: 10/11/2017 14:26:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[posts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[createTime] [datetime] NOT NULL,
	[writer] [nvarchar](20) NOT NULL,
	[isDel] [bit] NOT NULL,
	[title] [nvarchar](50) NOT NULL,
	[pic] [varchar](150) NOT NULL,
	[excerpt] [nvarchar](150) NOT NULL,
	[readcount] [decimal](18, 0) NOT NULL,
	[content] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_posts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[mfc]    Script Date: 10/11/2017 14:26:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[mfc](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[otherName] [nvarchar](50) NOT NULL,
	[type] [nvarchar](50) NOT NULL,
	[orderby] [int] NOT NULL,
	[icon] [varchar](20) NULL,
 CONSTRAINT [PK_mfc] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[mfc] ON
INSERT [dbo].[mfc] ([id], [name], [otherName], [type], [orderby], [icon]) VALUES (1, N'网站首页', N'home', N'home', 1, N'')
INSERT [dbo].[mfc] ([id], [name], [otherName], [type], [orderby], [icon]) VALUES (2, N'日常随笔', N'note', N'posts', 2, N'')
INSERT [dbo].[mfc] ([id], [name], [otherName], [type], [orderby], [icon]) VALUES (3, N'程序人生', N'programmer', N'posts', 3, N'')
INSERT [dbo].[mfc] ([id], [name], [otherName], [type], [orderby], [icon]) VALUES (4, N'资源分享', N'file', N'file', 4, N'')
INSERT [dbo].[mfc] ([id], [name], [otherName], [type], [orderby], [icon]) VALUES (5, N'关于本站', N'about', N'posts', 5, N'')
SET IDENTITY_INSERT [dbo].[mfc] OFF
