USE [BookRentalDB]
GO
/****** Object:  Table [dbo].[RentalRecord]    Script Date: 11/17/2017 5:02:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RentalRecord](
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
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_LeasingRecord] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[RentalRecord] ADD  CONSTRAINT [DF_RentalRecord_IsDeleted]  DEFAULT ((1)) FOR [IsDeleted]
GO

