USE [OnlineLibrary-Asp.net]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 01.05.2019 17:40:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Comment] [nvarchar](max) NULL,
	[BookId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Comments] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[Comments] ON 
INSERT [dbo].[Comments] ([ID], [Comment],[BookId]) VALUES  (1, N'Super książka', 1)
INSERT [dbo].[Comments] ([ID], [Comment],[BookId]) VALUES  (2, N'Całkiem niezła', 1)
INSERT [dbo].[Comments] ([ID], [Comment],[BookId]) VALUES  (3, N'Super książka', 2)
INSERT [dbo].[Comments] ([ID], [Comment],[BookId]) VALUES  (4, N'Świetny Autor', 3)
INSERT [dbo].[Comments] ([ID], [Comment],[BookId]) VALUES  (5, N'Wybitne dzieło', 3)
INSERT [dbo].[Comments] ([ID], [Comment],[BookId]) VALUES  (6, N'Niesamowity utwór', 3)

SET IDENTITY_INSERT [dbo].[Comments] OFF
 
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Comments_dbo.Book_BookId] FOREIGN KEY([BookId])
REFERENCES [dbo].[Book] ([ID])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_dbo.Comments_dbo.Book_BookId]
GO
