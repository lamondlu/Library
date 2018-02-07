USE [LibraryLogDB]
GO
/****** Object:  Table [dbo].[Logs]    Script Date: 11/20/2017 8:43:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CommandLogs](
	[Id] [uniqueidentifier] NOT NULL,
	[LogType] [int] NOT NULL,
	[CommandName] [nvarchar](max) NULL,
	[CommandUniqueId] [uniqueidentifier] NULL,
	[EventName] [nvarchar](max) NULL,
	[IsSuccess] [bit] NOT NULL,
	[Message] [nvarchar](max) NULL,
	[Data] [nvarchar](max) NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO