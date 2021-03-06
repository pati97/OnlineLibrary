USE [OnlineLibrary-Asp.net]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 01.05.2019 15:42:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[Title] [nvarchar](75) NOT NULL,
	[Author] [nvarchar](100) NULL,
	[Description] [nvarchar](max) NULL,
	[YearOfPublication] [int] NOT NULL,
	[CategoryID] [int] NOT NULL,
	[FilePath] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Book] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Book] ON 

INSERT [dbo].[Book] ([ID], [UserId], [Title], [Author], [Description], [YearOfPublication], [CategoryID], [FilePath]) VALUES (1, N'4ac5ccdc-cfd9-4007-8875-79b3796ea5d2', N'Hamlet', N'William Shakespeare', N'A description of Hamlet', 1599, 7, N'C:\Users\pati\Desktop\semestr 6\OnlineLibrary\Web App\OnlineLibrary\OnlineLibrary\Files\Hamlet.pdf')
INSERT [dbo].[Book] ([ID], [UserId], [Title], [Author], [Description], [YearOfPublication], [CategoryID], [FilePath]) VALUES (2, N'4ac5ccdc-cfd9-4007-8875-79b3796ea5d2', N'It', N'Stephen King', N'A description of It', 1986, 3, N'C:\Users\pati\Desktop\semestr 6\OnlineLibrary\Web App\OnlineLibrary\OnlineLibrary\Files\It.pdf')
INSERT [dbo].[Book] ([ID], [UserId], [Title], [Author], [Description], [YearOfPublication], [CategoryID], [FilePath]) VALUES (3, N'4ac5ccdc-cfd9-4007-8875-79b3796ea5d2', N'MacBeth', N'William Shakespeare', N'A description of MacBeth', 1606, 7, N'C:\Users\pati\Desktop\semestr 6\OnlineLibrary\Web App\OnlineLibrary\OnlineLibrary\Files\MacBeth.pdf')
SET IDENTITY_INSERT [dbo].[Book] OFF
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Book_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_dbo.Book_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Book_dbo.Category_Category_ID] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([ID])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_dbo.Book_dbo.Category_Category_ID]
GO
