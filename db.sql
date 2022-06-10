SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shapes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[width] [float] NULL,
	[height] [float] NULL,
	[amoung_of_side] [int] NULL,
	[position_x] [float] NULL,
	[position_y] [float] NULL,
	[position_z] [float] NULL,
	[scale] [float] NULL,
	[rotation_x] [float] NULL,
	[rotation_y] [float] NULL,
	[rotation_z] [float] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[shapes] ADD PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO