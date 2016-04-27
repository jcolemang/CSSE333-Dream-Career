USE [DreamCareer]
GO

/****** Object:  Table [dbo].[UserProfile]    Script Date: 4/25/2016 2:04:43 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[UserProfile](
	[ProfileID] [int] NOT NULL,
	[Name] [char](50) NULL,
	[Gender] [char](10) NULL,
	[Major] [char](50) NULL,
	[Experience] [varchar](max) NULL,
	[Street] [varchar](128) NULL,
	[City] [varchar](128) NULL,
	[State] [varchar](50) NULL,
	[Zipcode] [char](5) NULL,
 CONSTRAINT [profileIDprimary] PRIMARY KEY CLUSTERED 
(
	[ProfileID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[UserProfile]  WITH CHECK ADD  CONSTRAINT [FK__UserProfi__Profi__49C3F6B7] FOREIGN KEY([ProfileID])
REFERENCES [dbo].[DreamCareerUser] ([UserID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[UserProfile] CHECK CONSTRAINT [FK__UserProfi__Profi__49C3F6B7]
GO

