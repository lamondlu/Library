USE [LibraryUserDB]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 11/17/2017 5:01:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[PersonId] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 11/17/2017 5:01:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[PersonId] [uniqueidentifier] NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [MiddleName]) VALUES (N'38073623-168c-4d64-9a64-bf434d5923ec', N'Lamond', N'Lu', NULL)
GO
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [MiddleName]) VALUES (N'0ceb1441-0d71-47ff-b065-d9c25acdd10e', N'Lily', N'Jiang', NULL)
GO
INSERT [dbo].[User] ([PersonId], [Role], [UserName], [Password]) VALUES (N'38073623-168c-4d64-9a64-bf434d5923ec', N'Admin', N'admin', N'a@12345')
GO
INSERT [dbo].[User] ([PersonId], [Role], [UserName], [Password]) VALUES (N'0ceb1441-0d71-47ff-b065-d9c25acdd10e', N'Customer', N'guest', N'a@12345')
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Person] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([PersonId])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Person]
GO
USE [master]
GO
ALTER DATABASE [LibraryUserDB] SET  READ_WRITE 
GO