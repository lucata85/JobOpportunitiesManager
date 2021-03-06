USE [JobOpportunitiesManager]
GO
/****** Object:  Table [dbo].[Candidates]    Script Date: 20/6/2019 16:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Candidates](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[IdCard] [varchar](9) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Phone] [varchar](20) NOT NULL,
	[BirthDay] [datetime] NOT NULL,
	[Genre] [varchar](1) NOT NULL,
	[Address] [varchar](20) NOT NULL,
	[State] [varchar](20) NOT NULL,
	[City] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Candidates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobOpportunities]    Script Date: 20/6/2019 16:04:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobOpportunities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](20) NOT NULL,
	[Description] [varchar](max) NOT NULL,
	[Salary] [decimal](18, 2) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_JobOpportunities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobsCandidates]    Script Date: 20/6/2019 16:04:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobsCandidates](
	[IdJob] [int] NOT NULL,
	[IdCandidate] [int] NOT NULL
) ON [PRIMARY]
GO
