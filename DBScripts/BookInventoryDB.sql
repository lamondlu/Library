USE [BookRepositoryDB]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 11/9/2017 8:52:43 PM ******/
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
/****** Object:  Table [dbo].[BookRepository]    Script Date: 11/9/2017 8:52:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookRepository](
	[BookRepositoryId] [uniqueidentifier] NOT NULL,
	[BookId] [uniqueidentifier] NOT NULL,
	[Status] [int] NOT NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_BookRepository] PRIMARY KEY CLUSTERED 
(
	[BookRepositoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[History]    Script Date: 11/9/2017 8:52:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[History](
	[HistoryId] [uniqueidentifier] NOT NULL,
	[BookId] [uniqueidentifier] NOT NULL,
	[BookRepositoryId] [uniqueidentifier] NOT NULL,
	[Note] [nvarchar](max) NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_History] PRIMARY KEY CLUSTERED 
(
	[HistoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[Book] ([BookId], [BookName], [ISBN], [DateIssued], [Description]) VALUES (N'e8b39da3-cabe-48ad-b635-2729c7df204a', N'死神', N'S003', CAST(N'2017-11-10 00:00:00.0000000' AS DateTime2), N'test')
GO
INSERT [dbo].[Book] ([BookId], [BookName], [ISBN], [DateIssued], [Description]) VALUES (N'265380e1-d01b-410a-a754-44aa16cab38e', N'闪电11人', N'S006', CAST(N'2017-11-02 00:00:00.0000000' AS DateTime2), N'test')
GO
INSERT [dbo].[Book] ([BookId], [BookName], [ISBN], [DateIssued], [Description]) VALUES (N'7a103421-88ce-48d7-8e49-5fbe24ca067e', N'火影忍者', N'S001', CAST(N'2017-11-01 00:00:00.0000000' AS DateTime2), N'test')
GO
INSERT [dbo].[Book] ([BookId], [BookName], [ISBN], [DateIssued], [Description]) VALUES (N'8e5aff08-b44c-4569-9259-7ca6c5d5d041', N'海贼王', N'S002', CAST(N'2017-11-29 00:00:00.0000000' AS DateTime2), N'test')
GO
INSERT [dbo].[Book] ([BookId], [BookName], [ISBN], [DateIssued], [Description]) VALUES (N'10f62ef0-68bd-4d70-aa36-a86f99eea2d5', N'圣斗士星矢', N'S0056', CAST(N'2017-11-08 00:00:00.0000000' AS DateTime2), N'est')
GO
INSERT [dbo].[Book] ([BookId], [BookName], [ISBN], [DateIssued], [Description]) VALUES (N'5cfc0ccb-f975-43e5-bb04-e4a3d001c91a', N'蜡笔小新', N'S007', CAST(N'2017-11-02 00:00:00.0000000' AS DateTime2), N'test')
GO
INSERT [dbo].[Book] ([BookId], [BookName], [ISBN], [DateIssued], [Description]) VALUES (N'1ee98f79-83e1-46f1-8749-f023784bb8ad', N'我是谁', N'S943', CAST(N'2017-11-01 00:00:00.0000000' AS DateTime2), N'test')
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'2ec7ac07-6313-4cb0-802b-00d7f55fff63', N'e8b39da3-cabe-48ad-b635-2729c7df204a', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'7fef3925-f273-46de-a1dd-02d71470b2dd', N'e8b39da3-cabe-48ad-b635-2729c7df204a', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'a170293c-c69c-42f0-83d7-0c3b26b416e8', N'e8b39da3-cabe-48ad-b635-2729c7df204a', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'0f8b26cc-2804-4e33-8771-0e6d8317de31', N'265380e1-d01b-410a-a754-44aa16cab38e', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'd397f2ab-2a07-4c06-a901-0e7aa51f7041', N'8e5aff08-b44c-4569-9259-7ca6c5d5d041', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'ad00715d-fe97-481d-b131-1172b2e7b4f8', N'e8b39da3-cabe-48ad-b635-2729c7df204a', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'55084f19-ffb0-4b14-a7ec-17ef984da324', N'265380e1-d01b-410a-a754-44aa16cab38e', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'092cc2ad-216e-4353-a560-19750746cf03', N'e8b39da3-cabe-48ad-b635-2729c7df204a', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'9e827045-45d7-443b-a8e6-1b617ada8849', N'8e5aff08-b44c-4569-9259-7ca6c5d5d041', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'9ce723e6-dff0-40d0-a43d-1cb8c62846a6', N'265380e1-d01b-410a-a754-44aa16cab38e', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'54e5923b-d107-4a5e-9a25-1d0cdcd3af19', N'265380e1-d01b-410a-a754-44aa16cab38e', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'2970b580-348f-4c73-aa31-1dfe486cef5c', N'5cfc0ccb-f975-43e5-bb04-e4a3d001c91a', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'46d2671a-9d9e-4b4e-bec1-2590c91c2244', N'10f62ef0-68bd-4d70-aa36-a86f99eea2d5', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'9c7070e6-6745-4e22-8c36-2708240cac13', N'e8b39da3-cabe-48ad-b635-2729c7df204a', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'd45a85b1-d5da-4ee1-9f32-2bdb8ac3de37', N'265380e1-d01b-410a-a754-44aa16cab38e', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'f3c321e2-9d73-4a2f-b2ea-3446f7bbb301', N'5cfc0ccb-f975-43e5-bb04-e4a3d001c91a', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'098d8e36-2630-449a-a37c-43c2a94bc46c', N'8e5aff08-b44c-4569-9259-7ca6c5d5d041', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'998229a3-2393-40e1-8fac-44ab20fa344b', N'10f62ef0-68bd-4d70-aa36-a86f99eea2d5', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'38dab1bf-9b70-4f94-bf1e-459c0f488c37', N'10f62ef0-68bd-4d70-aa36-a86f99eea2d5', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'ed94db17-96e8-40c2-b0a7-4970b751ee37', N'e8b39da3-cabe-48ad-b635-2729c7df204a', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'3abfbf55-373f-483f-bcce-4eb2c83b84ad', N'265380e1-d01b-410a-a754-44aa16cab38e', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'bd2f59b5-109e-4d47-b01b-4fd807922e68', N'e8b39da3-cabe-48ad-b635-2729c7df204a', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'e0658f3d-5fd1-4c90-9fa4-5035feb52177', N'8e5aff08-b44c-4569-9259-7ca6c5d5d041', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'11469d7b-1585-4c73-90f4-5134cd1e4da7', N'265380e1-d01b-410a-a754-44aa16cab38e', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'0347ed20-7512-4739-8315-526c136651c1', N'5cfc0ccb-f975-43e5-bb04-e4a3d001c91a', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'4f42ef0f-3ed0-4c6c-aaad-53bf43c6e67d', N'e8b39da3-cabe-48ad-b635-2729c7df204a', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'd4663575-7ab4-4ad2-9c2f-53cfcfaff74f', N'5cfc0ccb-f975-43e5-bb04-e4a3d001c91a', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'2fae2ba6-1e20-4c86-9c8d-540ec50c74c0', N'10f62ef0-68bd-4d70-aa36-a86f99eea2d5', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'f5aaa8cb-dc23-43b2-8309-578d65f775a1', N'e8b39da3-cabe-48ad-b635-2729c7df204a', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'baa1f7a7-0ac6-4f76-bb93-579b225acfcf', N'5cfc0ccb-f975-43e5-bb04-e4a3d001c91a', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'58e32d5d-75ec-4240-a75d-580d058398b8', N'8e5aff08-b44c-4569-9259-7ca6c5d5d041', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'c40a7774-0617-4fc1-9c85-5cd9ba7564d2', N'e8b39da3-cabe-48ad-b635-2729c7df204a', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'6eacd0ae-2b26-46a1-b90f-672349607121', N'8e5aff08-b44c-4569-9259-7ca6c5d5d041', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'5e8fed36-82ae-46c0-b3ca-6957b1b8f182', N'8e5aff08-b44c-4569-9259-7ca6c5d5d041', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'1d90cb12-6a2e-454b-97b0-6ba33bfb2a88', N'5cfc0ccb-f975-43e5-bb04-e4a3d001c91a', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'a74dbb10-9815-454e-ac48-6ed1c6f48d63', N'265380e1-d01b-410a-a754-44aa16cab38e', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'6ebbc584-5dcd-45db-819c-78183228a2d3', N'265380e1-d01b-410a-a754-44aa16cab38e', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'a94b788f-7811-4580-a0f3-7e8d4e8f99e3', N'e8b39da3-cabe-48ad-b635-2729c7df204a', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'caac8537-76f9-4048-b7de-7f6b106eacc2', N'e8b39da3-cabe-48ad-b635-2729c7df204a', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'f29c0e0f-4047-4319-b6b7-7f8cf0003b46', N'e8b39da3-cabe-48ad-b635-2729c7df204a', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'6965a906-3e0d-49a2-8bab-86676676e157', N'265380e1-d01b-410a-a754-44aa16cab38e', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'909fb161-55a8-4314-b9e4-88f02d4d8c63', N'e8b39da3-cabe-48ad-b635-2729c7df204a', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'9e3564d6-4996-4be2-a990-90519395a777', N'10f62ef0-68bd-4d70-aa36-a86f99eea2d5', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'afe5d45f-c0c3-40fb-bca5-91a59c76c144', N'e8b39da3-cabe-48ad-b635-2729c7df204a', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'24535f99-f6aa-4174-b557-96576e546f6a', N'e8b39da3-cabe-48ad-b635-2729c7df204a', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'c090fa1a-ca77-4b09-b496-98df1fc8caa4', N'8e5aff08-b44c-4569-9259-7ca6c5d5d041', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'b08a1e8a-2680-457e-84f1-9bf9c7a35a54', N'265380e1-d01b-410a-a754-44aa16cab38e', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'e8fc9300-be61-43f1-a177-9d9178b84ddc', N'e8b39da3-cabe-48ad-b635-2729c7df204a', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'996f3a85-0d4d-43be-8a09-9f3f7a45f18c', N'265380e1-d01b-410a-a754-44aa16cab38e', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'fd9180ff-0501-4550-9874-a3ddc0a0aaf3', N'10f62ef0-68bd-4d70-aa36-a86f99eea2d5', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'54fa0755-6c13-4dd0-99cf-a61933d697cf', N'10f62ef0-68bd-4d70-aa36-a86f99eea2d5', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'5f276ba4-8cb7-4c58-b3ab-a89a4ab26060', N'e8b39da3-cabe-48ad-b635-2729c7df204a', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'346c5233-f065-409e-b3b3-ab86c3ad71ae', N'e8b39da3-cabe-48ad-b635-2729c7df204a', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'551a2859-7151-40cb-acec-ae19fa8dd95f', N'5cfc0ccb-f975-43e5-bb04-e4a3d001c91a', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'bb583751-a682-44e2-bde2-b04ae675b9e7', N'e8b39da3-cabe-48ad-b635-2729c7df204a', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'90e1487f-4d22-4616-a620-b2cdd2d6e5ad', N'10f62ef0-68bd-4d70-aa36-a86f99eea2d5', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'5f6808d9-5f09-4046-87a3-b6eaa9a49073', N'e8b39da3-cabe-48ad-b635-2729c7df204a', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'9baff069-1692-4852-94a3-bbf91c8a4996', N'e8b39da3-cabe-48ad-b635-2729c7df204a', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'58dabfaf-693f-464e-b19b-bc0a327142a1', N'e8b39da3-cabe-48ad-b635-2729c7df204a', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'72eb1c2f-2d1e-4549-bdd9-bed5b4cbdb83', N'265380e1-d01b-410a-a754-44aa16cab38e', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'70589129-14be-4451-a663-c110ed42da63', N'e8b39da3-cabe-48ad-b635-2729c7df204a', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'334b1952-975c-4f04-871f-c140b6ee927c', N'e8b39da3-cabe-48ad-b635-2729c7df204a', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'73b597dd-0f06-4baa-a810-c5b0e1ea125c', N'5cfc0ccb-f975-43e5-bb04-e4a3d001c91a', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'21e1f28f-9cdf-4edb-92b1-cb4b882f6a76', N'5cfc0ccb-f975-43e5-bb04-e4a3d001c91a', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'b43b6a34-76c9-408e-9bab-cf335e5b66da', N'265380e1-d01b-410a-a754-44aa16cab38e', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'a19c1b6c-ef49-46ef-9e72-d195f8df5e1e', N'265380e1-d01b-410a-a754-44aa16cab38e', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'158becd2-5b3b-440f-9cf9-d1ee95389884', N'265380e1-d01b-410a-a754-44aa16cab38e', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'5c382321-d00a-4e2a-95ba-d271ca57ece3', N'8e5aff08-b44c-4569-9259-7ca6c5d5d041', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'eea65a98-1336-4d9e-b298-d71c762f012f', N'265380e1-d01b-410a-a754-44aa16cab38e', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'62060c7f-457d-4a53-86d7-db7c2a2084fb', N'10f62ef0-68bd-4d70-aa36-a86f99eea2d5', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'9164b097-507e-41c1-a02b-df5886e3eb15', N'10f62ef0-68bd-4d70-aa36-a86f99eea2d5', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'ec7c46f5-0d52-41aa-b4e5-e4f174c9e733', N'e8b39da3-cabe-48ad-b635-2729c7df204a', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'25d5d1b3-1dcc-4461-b04e-ea95b3e169ca', N'5cfc0ccb-f975-43e5-bb04-e4a3d001c91a', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'42dbfdf4-afc3-40a1-8a02-efa49a9f6933', N'8e5aff08-b44c-4569-9259-7ca6c5d5d041', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'e096acf5-d4f1-487c-b96f-f01003aafc7f', N'265380e1-d01b-410a-a754-44aa16cab38e', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'39bc8701-94f7-451e-976e-f41273305503', N'265380e1-d01b-410a-a754-44aa16cab38e', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'12c9eeb0-18cf-4fc1-96c1-f80a35d52807', N'e8b39da3-cabe-48ad-b635-2729c7df204a', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'6e803760-3c5a-4bc5-960b-f95a518311b7', N'e8b39da3-cabe-48ad-b635-2729c7df204a', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'abcc3731-5bae-4a19-8e56-fe6c9c481d31', N'e8b39da3-cabe-48ad-b635-2729c7df204a', 1, 0)
GO
INSERT [dbo].[BookRepository] ([BookRepositoryId], [BookId], [Status], [IsRemoved]) VALUES (N'73cd8722-6001-47c4-8de8-ffcf212660d0', N'265380e1-d01b-410a-a754-44aa16cab38e', 1, 0)
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'1e864990-446e-4fda-93e6-0366efda3ca9', N'265380e1-d01b-410a-a754-44aa16cab38e', N'996f3a85-0d4d-43be-8a09-9f3f7a45f18c', N'Bulk Imported.', CAST(N'2017-11-03 16:57:37.3367923' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'18d832d7-5df3-4a41-944b-0487827fb61c', N'265380e1-d01b-410a-a754-44aa16cab38e', N'3abfbf55-373f-483f-bcce-4eb2c83b84ad', N'Bulk Imported.', CAST(N'2017-11-03 16:57:34.1065209' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'ff6b13a1-0ba4-41b3-9d34-0e2cce309df3', N'e8b39da3-cabe-48ad-b635-2729c7df204a', N'5f276ba4-8cb7-4c58-b3ab-a89a4ab26060', N'Bulk Imported.', CAST(N'2017-11-08 16:21:24.0287917' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'3353dc46-0dc0-4d59-97f3-0efb3034ef1d', N'265380e1-d01b-410a-a754-44aa16cab38e', N'd45a85b1-d5da-4ee1-9f32-2bdb8ac3de37', N'Bulk Imported.', CAST(N'2017-11-03 16:57:34.1065269' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'76d4caaa-81fc-40f3-acf4-13c8f8db6b24', N'8e5aff08-b44c-4569-9259-7ca6c5d5d041', N'42dbfdf4-afc3-40a1-8a02-efa49a9f6933', N'Bulk Imported.', CAST(N'2017-11-03 17:01:55.1606199' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'24fd19d4-39b8-493e-9ef7-1466f3409f6b', N'265380e1-d01b-410a-a754-44aa16cab38e', N'b08a1e8a-2680-457e-84f1-9bf9c7a35a54', N'Bulk Imported.', CAST(N'2017-11-03 16:57:37.3368002' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'1860cb9f-d8b2-45c6-b110-1553a1fdea8c', N'5cfc0ccb-f975-43e5-bb04-e4a3d001c91a', N'551a2859-7151-40cb-acec-ae19fa8dd95f', N'Bulk Imported.', CAST(N'2017-11-03 17:01:48.6824115' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'ff2bbe11-623a-4cbd-9d17-180a9cee7bd6', N'e8b39da3-cabe-48ad-b635-2729c7df204a', N'5f6808d9-5f09-4046-87a3-b6eaa9a49073', N'Bulk Imported.', CAST(N'2017-11-08 16:21:24.0287928' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'318f01e8-a094-4189-81d1-18391fb43b84', N'5cfc0ccb-f975-43e5-bb04-e4a3d001c91a', N'0347ed20-7512-4739-8315-526c136651c1', N'Bulk Imported.', CAST(N'2017-11-03 17:01:48.6824364' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'28811cac-425f-4cd3-9dc8-22b24a6ec501', N'10f62ef0-68bd-4d70-aa36-a86f99eea2d5', N'62060c7f-457d-4a53-86d7-db7c2a2084fb', N'Bulk Imported.', CAST(N'2017-11-03 17:01:53.0959759' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'a04a7ae5-1516-41b9-9187-23d7b71a3eb7', N'5cfc0ccb-f975-43e5-bb04-e4a3d001c91a', N'2970b580-348f-4c73-aa31-1dfe486cef5c', N'Bulk Imported.', CAST(N'2017-11-03 17:01:48.6824150' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'099e7690-2a5d-46d6-b64b-26f198521569', N'8e5aff08-b44c-4569-9259-7ca6c5d5d041', N'd397f2ab-2a07-4c06-a901-0e7aa51f7041', N'Bulk Imported.', CAST(N'2017-11-03 17:01:55.1606188' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'26dc8b9d-6dea-44c0-9588-2a0ba41ee005', N'10f62ef0-68bd-4d70-aa36-a86f99eea2d5', N'38dab1bf-9b70-4f94-bf1e-459c0f488c37', N'Bulk Imported.', CAST(N'2017-11-03 17:01:53.0959791' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'50c79e24-6262-43d4-8bf9-30ae83173450', N'10f62ef0-68bd-4d70-aa36-a86f99eea2d5', N'46d2671a-9d9e-4b4e-bec1-2590c91c2244', N'Bulk Imported.', CAST(N'2017-11-03 17:01:53.0959617' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'2ecf8c1d-4ee7-450b-ab15-34b6b1805781', N'10f62ef0-68bd-4d70-aa36-a86f99eea2d5', N'54fa0755-6c13-4dd0-99cf-a61933d697cf', N'Bulk Imported.', CAST(N'2017-11-03 17:01:53.0959680' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'6452fdf8-c283-463e-bfed-443ed1261b31', N'e8b39da3-cabe-48ad-b635-2729c7df204a', N'ed94db17-96e8-40c2-b0a7-4970b751ee37', N'Bulk Imported.', CAST(N'2017-11-08 16:21:24.0287889' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'0bd9a6b8-f9ce-4081-bcaa-463bab821fd5', N'265380e1-d01b-410a-a754-44aa16cab38e', N'6ebbc584-5dcd-45db-819c-78183228a2d3', N'Bulk Imported.', CAST(N'2017-11-03 16:57:34.1065063' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'e0055895-2aef-464b-a508-4675d6056e09', N'265380e1-d01b-410a-a754-44aa16cab38e', N'73cd8722-6001-47c4-8de8-ffcf212660d0', N'Bulk Imported.', CAST(N'2017-11-03 16:57:37.3367911' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'ce253bd9-e09e-4548-afc0-4d3c3d81588a', N'e8b39da3-cabe-48ad-b635-2729c7df204a', N'7fef3925-f273-46de-a1dd-02d71470b2dd', N'Bulk Imported.', CAST(N'2017-11-09 16:33:19.5792807' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'5fd7d8a6-a39b-48ef-b6cc-50472e84f525', N'e8b39da3-cabe-48ad-b635-2729c7df204a', N'909fb161-55a8-4314-b9e4-88f02d4d8c63', N'Bulk Imported.', CAST(N'2017-11-08 16:21:24.0287739' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'48a87dd3-65bf-41a9-9275-517bb208c3a8', N'5cfc0ccb-f975-43e5-bb04-e4a3d001c91a', N'baa1f7a7-0ac6-4f76-bb93-579b225acfcf', N'Bulk Imported.', CAST(N'2017-11-03 17:01:48.6824257' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'4a531fba-6624-4b97-a27f-5529975d904a', N'8e5aff08-b44c-4569-9259-7ca6c5d5d041', N'6eacd0ae-2b26-46a1-b90f-672349607121', N'Bulk Imported.', CAST(N'2017-11-03 17:01:55.1606172' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'b91c407c-b217-4a05-8a8f-55349ab127b0', N'265380e1-d01b-410a-a754-44aa16cab38e', N'55084f19-ffb0-4b14-a7ec-17ef984da324', N'Bulk Imported.', CAST(N'2017-11-03 16:57:37.3367990' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'8007b906-f89b-49be-a71f-581b10b3f8e0', N'e8b39da3-cabe-48ad-b635-2729c7df204a', N'bd2f59b5-109e-4d47-b01b-4fd807922e68', N'Bulk Imported.', CAST(N'2017-11-08 16:21:24.0288011' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'1b9a159e-b6a9-4d01-8c50-581b1c27d34e', N'5cfc0ccb-f975-43e5-bb04-e4a3d001c91a', N'f3c321e2-9d73-4a2f-b2ea-3446f7bbb301', N'Bulk Imported.', CAST(N'2017-11-03 17:01:48.6824135' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'6cc2d364-e7ef-4d0c-ad19-60b09e8932ae', N'e8b39da3-cabe-48ad-b635-2729c7df204a', N'a170293c-c69c-42f0-83d7-0c3b26b416e8', N'Bulk Imported.', CAST(N'2017-11-09 16:33:19.5792791' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'bd2d909d-29fb-4d7c-83bf-632a8a2b9bf1', N'5cfc0ccb-f975-43e5-bb04-e4a3d001c91a', N'1d90cb12-6a2e-454b-97b0-6ba33bfb2a88', N'Bulk Imported.', CAST(N'2017-11-03 17:01:48.6824194' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'f2690e5d-1249-4c3c-a047-66e241c59fbf', N'e8b39da3-cabe-48ad-b635-2729c7df204a', N'9c7070e6-6745-4e22-8c36-2708240cac13', N'Bulk Imported.', CAST(N'2017-11-09 16:33:19.5792728' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'8af114f0-9570-4fa7-b76c-69f7e3605e32', N'e8b39da3-cabe-48ad-b635-2729c7df204a', N'6e803760-3c5a-4bc5-960b-f95a518311b7', N'Bulk Imported.', CAST(N'2017-11-09 16:33:19.5792712' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'9b39ec35-0377-4a1e-b1f0-6bd5b1272176', N'e8b39da3-cabe-48ad-b635-2729c7df204a', N'a94b788f-7811-4580-a0f3-7e8d4e8f99e3', N'Bulk Imported.', CAST(N'2017-11-08 16:21:24.0287944' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'aea141ef-4ba5-490b-a1d6-6f1720e3e86e', N'8e5aff08-b44c-4569-9259-7ca6c5d5d041', N'098d8e36-2630-449a-a37c-43c2a94bc46c', N'Bulk Imported.', CAST(N'2017-11-03 17:01:55.1606527' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'55390484-612a-4788-b4e0-792e8c1ec198', N'e8b39da3-cabe-48ad-b635-2729c7df204a', N'ec7c46f5-0d52-41aa-b4e5-e4f174c9e733', N'Bulk Imported.', CAST(N'2017-11-09 16:33:19.5792823' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'09892a4f-c2f7-4538-820a-8c9f477dfd4b', N'5cfc0ccb-f975-43e5-bb04-e4a3d001c91a', N'd4663575-7ab4-4ad2-9c2f-53cfcfaff74f', N'Bulk Imported.', CAST(N'2017-11-03 17:01:48.6824237' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'fe16af92-0396-4d36-bc59-8d889572e259', N'265380e1-d01b-410a-a754-44aa16cab38e', N'9ce723e6-dff0-40d0-a43d-1cb8c62846a6', N'Bulk Imported.', CAST(N'2017-11-03 16:57:34.1065281' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'33f8a2f6-b95f-4aa5-b1d5-8e68137dcac5', N'8e5aff08-b44c-4569-9259-7ca6c5d5d041', N'5e8fed36-82ae-46c0-b3ca-6957b1b8f182', N'Bulk Imported.', CAST(N'2017-11-03 17:01:55.1606160' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'd706b01c-3a5b-48ef-bf31-91e3ace7f50c', N'e8b39da3-cabe-48ad-b635-2729c7df204a', N'bb583751-a682-44e2-bde2-b04ae675b9e7', N'Bulk Imported.', CAST(N'2017-11-08 16:21:24.0287763' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'41c52c5e-8379-474e-b574-92398b766367', N'e8b39da3-cabe-48ad-b635-2729c7df204a', N'ad00715d-fe97-481d-b131-1172b2e7b4f8', N'Bulk Imported.', CAST(N'2017-11-08 16:21:24.0287774' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'9519cfef-2463-4142-a436-94123dd8e0cc', N'265380e1-d01b-410a-a754-44aa16cab38e', N'158becd2-5b3b-440f-9cf9-d1ee95389884', N'Bulk Imported.', CAST(N'2017-11-03 16:57:34.1065178' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'bda4e1e5-6b4d-49fa-ae11-95376eeb1924', N'10f62ef0-68bd-4d70-aa36-a86f99eea2d5', N'9164b097-507e-41c1-a02b-df5886e3eb15', N'Bulk Imported.', CAST(N'2017-11-03 17:01:53.0959692' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'b4eed89d-7e5a-4ebc-880b-9ae661e46e2f', N'10f62ef0-68bd-4d70-aa36-a86f99eea2d5', N'2fae2ba6-1e20-4c86-9c8d-540ec50c74c0', N'Bulk Imported.', CAST(N'2017-11-03 17:01:53.0959704' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'52ce69e5-c22b-45e1-b45c-9d79c614bf64', N'e8b39da3-cabe-48ad-b635-2729c7df204a', N'9baff069-1692-4852-94a3-bbf91c8a4996', N'Bulk Imported.', CAST(N'2017-11-08 16:21:24.0287510' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'99b789cc-35f6-48b2-a972-9e1214c1c610', N'265380e1-d01b-410a-a754-44aa16cab38e', N'a74dbb10-9815-454e-ac48-6ed1c6f48d63', N'Bulk Imported.', CAST(N'2017-11-03 16:57:37.3367975' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'34165b48-acd2-4234-8042-a0e0e38bbb65', N'10f62ef0-68bd-4d70-aa36-a86f99eea2d5', N'90e1487f-4d22-4616-a620-b2cdd2d6e5ad', N'Bulk Imported.', CAST(N'2017-11-03 17:01:53.0959779' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'31dc4e51-7e02-4980-a435-a72b72e45cf1', N'265380e1-d01b-410a-a754-44aa16cab38e', N'11469d7b-1585-4c73-90f4-5134cd1e4da7', N'Bulk Imported.', CAST(N'2017-11-03 16:57:34.1065340' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'bc241f1a-e57f-4062-adc4-acbafdcfd952', N'e8b39da3-cabe-48ad-b635-2729c7df204a', N'58dabfaf-693f-464e-b19b-bc0a327142a1', N'Bulk Imported.', CAST(N'2017-11-09 16:33:19.5792906' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'35cd375b-3638-4c0a-ba86-b1bace8fd2ae', N'8e5aff08-b44c-4569-9259-7ca6c5d5d041', N'5c382321-d00a-4e2a-95ba-d271ca57ece3', N'Bulk Imported.', CAST(N'2017-11-03 17:01:55.1606610' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'635b7cb6-0776-4cb4-8eb0-b5797c57a1bb', N'265380e1-d01b-410a-a754-44aa16cab38e', N'39bc8701-94f7-451e-976e-f41273305503', N'Bulk Imported.', CAST(N'2017-11-03 16:57:34.1065194' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'218733d7-2ef1-43f1-aa2b-b7b4bc9c0ee7', N'265380e1-d01b-410a-a754-44aa16cab38e', N'72eb1c2f-2d1e-4549-bdd9-bed5b4cbdb83', N'Bulk Imported.', CAST(N'2017-11-03 16:57:34.1065257' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'c0c31945-17d1-4c21-8be1-b8dd3cc54769', N'e8b39da3-cabe-48ad-b635-2729c7df204a', N'afe5d45f-c0c3-40fb-bca5-91a59c76c144', N'Bulk Imported.', CAST(N'2017-11-09 16:33:19.5792550' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'579faa39-a980-4d7c-8cc5-bbb4eca95475', N'8e5aff08-b44c-4569-9259-7ca6c5d5d041', N'c090fa1a-ca77-4b09-b496-98df1fc8caa4', N'Bulk Imported.', CAST(N'2017-11-03 17:01:55.1606650' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'87426feb-4a83-4375-a6b0-bf17cdb43812', N'10f62ef0-68bd-4d70-aa36-a86f99eea2d5', N'998229a3-2393-40e1-8fac-44ab20fa344b', N'Bulk Imported.', CAST(N'2017-11-03 17:01:53.0959629' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'5c1cd744-533f-4815-8a32-c1595026b0e8', N'10f62ef0-68bd-4d70-aa36-a86f99eea2d5', N'9e3564d6-4996-4be2-a990-90519395a777', N'Bulk Imported.', CAST(N'2017-11-03 17:01:53.0959720' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'a7eddff5-42e2-46b5-8f4e-c469d15c2d71', N'265380e1-d01b-410a-a754-44aa16cab38e', N'eea65a98-1336-4d9e-b298-d71c762f012f', N'Bulk Imported.', CAST(N'2017-11-03 16:57:34.1065296' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'ce01e0e7-03be-4363-ba0d-c77e88bd37f2', N'8e5aff08-b44c-4569-9259-7ca6c5d5d041', N'9e827045-45d7-443b-a8e6-1b617ada8849', N'Bulk Imported.', CAST(N'2017-11-03 17:01:55.1606124' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'264ca01e-acd3-4980-965c-cbc977a157ef', N'e8b39da3-cabe-48ad-b635-2729c7df204a', N'2ec7ac07-6313-4cb0-802b-00d7f55fff63', N'Bulk Imported.', CAST(N'2017-11-09 16:33:19.5792886' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'e00a89ae-1b4a-440a-a5b1-d0af6da7e172', N'265380e1-d01b-410a-a754-44aa16cab38e', N'0f8b26cc-2804-4e33-8771-0e6d8317de31', N'Bulk Imported.', CAST(N'2017-11-03 16:57:37.3367900' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'64f23f6a-0620-4338-a707-d2194e427cd7', N'10f62ef0-68bd-4d70-aa36-a86f99eea2d5', N'fd9180ff-0501-4550-9874-a3ddc0a0aaf3', N'Bulk Imported.', CAST(N'2017-11-03 17:01:53.0959594' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'53e29dcd-9ff3-4773-8021-d54ab97b83ea', N'265380e1-d01b-410a-a754-44aa16cab38e', N'6965a906-3e0d-49a2-8bab-86676676e157', N'Bulk Imported.', CAST(N'2017-11-03 16:57:37.3367805' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'9451bb15-d3a9-4e6a-8c5d-d553fb273b2d', N'265380e1-d01b-410a-a754-44aa16cab38e', N'b43b6a34-76c9-408e-9bab-cf335e5b66da', N'Bulk Imported.', CAST(N'2017-11-03 16:57:37.3367848' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'd747e460-af18-4f87-ac29-ded1545fc8e2', N'8e5aff08-b44c-4569-9259-7ca6c5d5d041', N'58e32d5d-75ec-4240-a75d-580d058398b8', N'Bulk Imported.', CAST(N'2017-11-03 17:01:55.1606591' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'3807631a-0165-4cce-9fe4-e13f0532ccc1', N'e8b39da3-cabe-48ad-b635-2729c7df204a', N'24535f99-f6aa-4174-b557-96576e546f6a', N'Bulk Imported.', CAST(N'2017-11-09 16:33:19.5792834' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'73804361-6040-43e9-93dc-e13fb37097fb', N'265380e1-d01b-410a-a754-44aa16cab38e', N'54e5923b-d107-4a5e-9a25-1d0cdcd3af19', N'Bulk Imported.', CAST(N'2017-11-03 16:57:34.1065162' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'd41a9468-6bf6-4ad3-9967-e60dd31a7d83', N'e8b39da3-cabe-48ad-b635-2729c7df204a', N'abcc3731-5bae-4a19-8e56-fe6c9c481d31', N'Bulk Imported.', CAST(N'2017-11-08 16:21:24.0287782' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'2ac9e58f-f09e-4cb0-85f0-e9666a4438c1', N'265380e1-d01b-410a-a754-44aa16cab38e', N'e096acf5-d4f1-487c-b96f-f01003aafc7f', N'Bulk Imported.', CAST(N'2017-11-03 16:57:37.3367864' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'fc12fc07-c2b1-4e53-8b3d-e9aa3cb1d1c4', N'5cfc0ccb-f975-43e5-bb04-e4a3d001c91a', N'73b597dd-0f06-4baa-a810-c5b0e1ea125c', N'Bulk Imported.', CAST(N'2017-11-03 17:01:48.6824289' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'a8d108cd-f5e2-49e6-9e7a-e9d92e8ec09d', N'5cfc0ccb-f975-43e5-bb04-e4a3d001c91a', N'21e1f28f-9cdf-4edb-92b1-cb4b882f6a76', N'Bulk Imported.', CAST(N'2017-11-03 17:01:48.6824020' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'11f07a46-d161-415e-9d91-f1903e244610', N'265380e1-d01b-410a-a754-44aa16cab38e', N'a19c1b6c-ef49-46ef-9e72-d195f8df5e1e', N'Bulk Imported.', CAST(N'2017-11-03 16:57:37.3367959' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'9164d12f-4237-476f-806a-f648382c083c', N'5cfc0ccb-f975-43e5-bb04-e4a3d001c91a', N'25d5d1b3-1dcc-4461-b04e-ea95b3e169ca', N'Bulk Imported.', CAST(N'2017-11-03 17:01:48.6824273' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'b6576622-f242-486e-a06c-fa7a63d2dd24', N'e8b39da3-cabe-48ad-b635-2729c7df204a', N'f5aaa8cb-dc23-43b2-8309-578d65f775a1', N'Bulk Imported.', CAST(N'2017-11-09 16:33:19.5792696' AS DateTime2))
GO
INSERT [dbo].[History] ([HistoryId], [BookId], [BookRepositoryId], [Note], [CreatedOn]) VALUES (N'26693905-91b6-468b-9595-ff109ad4ef37', N'8e5aff08-b44c-4569-9259-7ca6c5d5d041', N'e0658f3d-5fd1-4c90-9fa4-5035feb52177', N'Bulk Imported.', CAST(N'2017-11-03 17:01:55.1606622' AS DateTime2))
GO
ALTER TABLE [dbo].[BookRepository]  WITH CHECK ADD  CONSTRAINT [FK_BookRepository_Book] FOREIGN KEY([BookId])
REFERENCES [dbo].[Book] ([BookId])
GO
ALTER TABLE [dbo].[BookRepository] CHECK CONSTRAINT [FK_BookRepository_Book]
GO
ALTER TABLE [dbo].[History]  WITH CHECK ADD  CONSTRAINT [FK_History_BookRepository] FOREIGN KEY([BookRepositoryId])
REFERENCES [dbo].[BookRepository] ([BookRepositoryId])
GO
ALTER TABLE [dbo].[History] CHECK CONSTRAINT [FK_History_BookRepository]
GO
ALTER TABLE [dbo].[History]  WITH CHECK ADD  CONSTRAINT [FK_History_History] FOREIGN KEY([BookId])
REFERENCES [dbo].[Book] ([BookId])
GO
ALTER TABLE [dbo].[History] CHECK CONSTRAINT [FK_History_History]
GO
USE [master]
GO
ALTER DATABASE [BookRepositoryDB] SET  READ_WRITE 
GO
