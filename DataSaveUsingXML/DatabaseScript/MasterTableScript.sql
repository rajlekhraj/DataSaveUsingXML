CREATE TABLE [dbo].[MasterEntry](
	[MasterType] [nvarchar](20) NOT NULL,
	[MasterValue] [nvarchar](max) NOT NULL,
	[ParentId] [nvarchar](20) NULL,
	[CreatedId] [int] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[FinYearId] [nvarchar](20) NULL,
	[FirmId] [int] NULL,	
	[MasterId] [bigint] IDENTITY(1,1) NOT NULL,
	[Remark] [nvarchar](max) NOT NULL,
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[MasterEntry] ADD  CONSTRAINT [DF_MasterEntry_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO

ALTER TABLE [dbo].[MasterEntry] ADD  CONSTRAINT [DF_MasterEntry_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO