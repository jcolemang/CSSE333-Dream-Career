USE [DreamCareer]
GO

/****** Object:  Table [dbo].[Likes]    Script Date: 4/26/2016 6:18:54 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Likes](
	[UserID] [int] NULL,
	[ProfileID] [int] NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Likes]  WITH CHECK ADD FOREIGN KEY([ProfileID])
REFERENCES [dbo].[UserProfile] ([ProfileID])
GO

ALTER TABLE [dbo].[Likes]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[DreamCareerUser] ([UserID])
GO

