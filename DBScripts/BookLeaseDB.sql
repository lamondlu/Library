USE [BookLeaseDB]
GO
/****** Object:  Table [dbo].[LeasingRecord]    Script Date: 11/6/2017 2:36:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeasingRecord](
	[Id] [uniqueidentifier] NOT NULL,
	[CustomerId] [uniqueidentifier] NOT NULL,
	[BookId] [uniqueidentifier] NOT NULL,
	[BookName] [nvarchar](max) NOT NULL,
	[ISBN] [nvarchar](max) NOT NULL,
	[ContactFirstName] [nvarchar](max) NULL,
	[ContactLastName] [nvarchar](max) NULL,
	[ContactMiddleName] [nvarchar](max) NULL,
	[RentDate] [datetime2](7) NOT NULL,
	[ReturnDate] [datetime2](7) NULL,
 CONSTRAINT [PK_LeasingRecord] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
USE [master]
GO
ALTER DATABASE [BookLeaseDB] SET  READ_WRITE 
GO
