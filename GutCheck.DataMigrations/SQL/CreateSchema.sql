﻿DROP TABLE IF EXISTS dbo.Users;

CREATE TABLE [dbo].[Users]
(
    [Id] [INT] IDENTITY(1, 1) NOT NULL,
    [Username] [NVARCHAR](128) NOT NULL,
    [Email] [NVARCHAR](128) NOT NULL,
    [HashedPassword] [NVARCHAR](128) NOT NULL,
    [Role] [NVARCHAR](32) NOT NULL,
    [IsConfirmed] [BIT] NOT NULL,
    CONSTRAINT [PK_Users]
        PRIMARY KEY CLUSTERED ([Id] ASC)
        WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON,
              ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF
             ) ON [PRIMARY]
) ON [PRIMARY];

/****** Object:  Table [dbo].[FoodRecords]    Script Date: 10/7/2024 8:09:43 AM ******/
DROP TABLE IF EXISTS [dbo].[FoodRecords]

CREATE TABLE [dbo].[FoodRecords](
	[FoodRecordId] [INT] IDENTITY(1,1) NOT NULL,
	[UserId] [INT] NOT NULL,
	[Description] [NVARCHAR](255) NOT NULL,
	[Date] [DATE] NOT NULL,
	[HealthScore] [SMALLINT] NOT NULL,
	[PortionSize] [SMALLINT] NOT NULL,
 CONSTRAINT [PK_FoodRecords] PRIMARY KEY CLUSTERED 
(
	[FoodRecordId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[WeightRecords]    Script Date: 10/7/2024 8:11:18 AM ******/
DROP TABLE IF EXISTS [dbo].[WeightRecords]

CREATE TABLE [dbo].[WeightRecords](
	[WeightRecordId] [INT] IDENTITY(1,1) NOT NULL,
	[UserId] [INT] NOT NULL,
	[Weight] [DECIMAL](6, 2) NOT NULL,
	[Date] [DATE] NOT NULL,
 CONSTRAINT [PK_WeightRecords1] PRIMARY KEY CLUSTERED 
(
	[WeightRecordId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]