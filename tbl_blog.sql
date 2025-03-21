USE [DotNetTrainingBatch4]
GO
/****** Object:  Table [dbo].[Tbl_Blog]    Script Date: 3/18/2025 11:17:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Blog](
	[BlogId] [int] IDENTITY(1,1) NOT NULL,
	[BlogTitle] [varchar](50) NOT NULL,
	[BlogAuthor] [varchar](50) NOT NULL,
	[BlogContent] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Tbl_Blog] PRIMARY KEY CLUSTERED 
(
	[BlogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tbl_Blog] ON 

INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (1, N'North to the west', N'min min', N'This is a kid story.')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (2, N'Test Title', N'Test Author', N' Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (3, N'Test Title', N'Test Author', N' Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (4, N'Test Title', N'Test Author', N' Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (5, N'Test Title', N'Test Author', N' Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (6, N'Test Title', N'Test Author', N' Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (7, N'Test Title', N'Test Author', N' Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (8, N'Test Title', N'Test Author', N' Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (9, N'Test Title', N'Test Author', N' Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (10, N'Test Title', N'Test Author', N' Test Content')
SET IDENTITY_INSERT [dbo].[Tbl_Blog] OFF
GO
