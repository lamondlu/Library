USE [BookRepositoryDB]
GO
/****** Object:  Table [dbo].[BookRepository]    Script Date: 10/31/2017 5:22:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookRepository](
	[BookId] [uniqueidentifier] NOT NULL,
	[BookName] [nvarchar](max) NOT NULL,
	[ISBN] [nvarchar](max) NOT NULL,
	[DateIssued] [datetime2](7) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
USE [master]
GO
ALTER DATABASE [BookRepositoryDB] SET  READ_WRITE 
GO