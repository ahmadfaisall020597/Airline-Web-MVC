use AIRLINE_BOOKING;

drop table if exists [passenger_user];


CREATE TABLE [passenger_user] (
	[email] [varchar](30) NOT NULL,
	[password] [varchar](100) NOT NULL,
	[phone] [varchar](20) NOT NULL,		
	[username] [varchar](60) NOT NULL,
	[active] [bit] NOT NULL,
	[created_at] [datetime] NOT NULL,
	[created_by] [varchar](60) NOT NULL,
	[updated_at] [datetime] NULL,
	[updated_by] [varchar](60) NULL,
 CONSTRAINT [PK_passenger_user] PRIMARY KEY CLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO