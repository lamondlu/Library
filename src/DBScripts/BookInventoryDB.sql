USE [BookInventoryDB]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 11/17/2017 5:00:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[BookId] [uniqueidentifier] NOT NULL,
	[BookName] [nvarchar](max) NOT NULL,
	[ISBN] [nvarchar](max) NOT NULL,
	[DateIssued] [datetime2](7) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BookInventory]    Script Date: 11/17/2017 5:00:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookInventory](
	[BookInventoryId] [uniqueidentifier] NOT NULL,
	[BookId] [uniqueidentifier] NOT NULL,
	[Status] [int] NOT NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_BookRepository] PRIMARY KEY CLUSTERED 
(
	[BookInventoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[History]    Script Date: 11/17/2017 5:00:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[History](
	[HistoryId] [uniqueidentifier] NOT NULL,
	[BookInventoryId] [uniqueidentifier] NOT NULL,
	[Note] [nvarchar](max) NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_History] PRIMARY KEY CLUSTERED 
(
	[HistoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[BookInventory]  WITH CHECK ADD  CONSTRAINT [FK_BookRepository_Book] FOREIGN KEY([BookId])
REFERENCES [dbo].[Book] ([BookId])
GO
ALTER TABLE [dbo].[BookInventory] CHECK CONSTRAINT [FK_BookRepository_Book]
GO
ALTER TABLE [dbo].[History]  WITH CHECK ADD  CONSTRAINT [FK_History_BookRepository] FOREIGN KEY([BookInventoryId])
REFERENCES [dbo].[BookInventory] ([BookInventoryId])
GO
ALTER TABLE [dbo].[History] CHECK CONSTRAINT [FK_History_BookRepository]
GO
