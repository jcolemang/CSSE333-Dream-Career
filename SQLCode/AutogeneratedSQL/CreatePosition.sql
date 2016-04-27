USE [DreamCareer]
GO

/****** Object:  Table [dbo].[Position]    Script Date: 4/25/2016 1:50:16 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Position](
	[PositionID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyID] [int] NOT NULL,
	[Type] [varchar](128) NULL,
	[Location] [varchar](128) NULL,
	[Salary] [money] NULL,
	[Description] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[PositionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Position]  WITH CHECK ADD  CONSTRAINT [FK__position__Compan__37A5467C] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Company] ([CompanyID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Position] CHECK CONSTRAINT [FK__position__Compan__37A5467C]
GO

