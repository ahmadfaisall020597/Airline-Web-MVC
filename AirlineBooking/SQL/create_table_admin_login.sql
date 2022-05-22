use AIRLINE_BOOKING;

drop table if exists [admin_login];

CREATE TABLE [admin_login] (
	[login_id] [varchar](100) NOT NULL,
	[admin_user] [varchar](100) NOT NULL,	
	[created_at] [datetime] NOT NULL,
	[expired] [bit] NOT NULL,
	
 CONSTRAINT [PK_admin_login] PRIMARY KEY CLUSTERED 
(
	[login_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO