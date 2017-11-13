USE [BookLeaseDB]
GO
/****** Object:  Table [dbo].[LeasingRecord]    Script Date: 11/9/2017 8:51:41 PM ******/
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
INSERT [dbo].[LeasingRecord] ([Id], [CustomerId], [BookId], [BookName], [ISBN], [ContactFirstName], [ContactLastName], [ContactMiddleName], [RentDate], [ReturnDate]) VALUES (N'f4066ce7-368b-4d78-9c92-5d35b6437bcc', N'0ceb1441-0d71-47ff-b065-d9c25acdd10e', N'd397f2ab-2a07-4c06-a901-0e7aa51f7041', N'海贼王', N'S002', N'Lily', N'Jiang', N'', CAST(N'2017-11-09 16:26:47.1221923' AS DateTime2), NULL)
GO
INSERT [dbo].[LeasingRecord] ([Id], [CustomerId], [BookId], [BookName], [ISBN], [ContactFirstName], [ContactLastName], [ContactMiddleName], [RentDate], [ReturnDate]) VALUES (N'c8f2f7d5-47a1-40ee-a1ed-680f6691fb82', N'0ceb1441-0d71-47ff-b065-d9c25acdd10e', N'46d2671a-9d9e-4b4e-bec1-2590c91c2244', N'圣斗士星矢', N'S0056', N'Lily', N'Jiang', N'', CAST(N'2017-11-09 16:30:51.5836809' AS DateTime2), NULL)
GO
INSERT [dbo].[LeasingRecord] ([Id], [CustomerId], [BookId], [BookName], [ISBN], [ContactFirstName], [ContactLastName], [ContactMiddleName], [RentDate], [ReturnDate]) VALUES (N'3912a06e-6298-4ccf-8588-8c00553ee4fb', N'0ceb1441-0d71-47ff-b065-d9c25acdd10e', N'ad00715d-fe97-481d-b131-1172b2e7b4f8', N'死神', N'S003', N'Lily', N'Jiang', N'', CAST(N'2017-11-09 16:20:46.2927650' AS DateTime2), NULL)
GO
USE [master]
GO
ALTER DATABASE [BookLeaseDB] SET  READ_WRITE 
GO
