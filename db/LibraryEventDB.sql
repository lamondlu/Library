USE [LibraryEventDB]
GO
/****** Object:  Table [dbo].[Events]    Script Date: 11/17/2017 5:00:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[AggregateRootId] [uniqueidentifier] NOT NULL,
	[Version] [int] NOT NULL,
	[EventName] [nvarchar](max) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[OccurredOn] [datetime2](7) NOT NULL,
	[AssemblyName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Events_1] PRIMARY KEY CLUSTERED 
(
	[AggregateRootId] ASC,
	[Version] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
