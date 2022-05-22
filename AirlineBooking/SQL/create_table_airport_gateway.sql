USE [AIRLINE_BOOKING]
GO

drop table if exists airport_gateway;

CREATE TABLE [dbo].[airport_gateway](
	[id_gateway] [bigint] IDENTITY(1,1) NOT NULL,
	[kode_airport] [varchar](30) NOT NULL,
	[nomor_gate] [varchar](5) NOT NULL,
	[nomor_pintu] [varchar](5) NOT NULL,
	[created_at] [datetime] NOT NULL,
	[created_by] varchar(60) NOT NULL,
 CONSTRAINT [PK_airport_gateway] PRIMARY KEY CLUSTERED 
(
	[id_gateway] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


