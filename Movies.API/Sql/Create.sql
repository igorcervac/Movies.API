USE [Subscription1DB]
GO

/****** Object:  Table [FavouriteMovies].[FavouriteMovies]    Script Date: 2/9/2025 3:40:32 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE SCHEMA Movies
GO

CREATE TABLE [Movies].[Movies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ImdbID] [nvarchar](50) NULL,
	[Type] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NULL,
	[Year] [nvarchar](50) NULL,
	[Poster] [nvarchar](max) NULL,
 CONSTRAINT [PK_Movies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


