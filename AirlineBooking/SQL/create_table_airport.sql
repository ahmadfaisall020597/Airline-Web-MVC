USE [AIRLINE_BOOKING]
GO

drop table if exists [airport];

CREATE TABLE [dbo].[airport](
	[kode_airport] [varchar](30) NOT NULL,
	[nama_airport] [varchar](60) NOT NULL,
	[propinsi] [varchar](60) NOT NULL,
	[kota] [varchar](60) NOT NULL,
	 created_at datetime not null ,
    created_by varchar(60) not null ,
    updated_at datetime null ,
    updated_by varchar(60) null ,

 CONSTRAINT [PK_airport] PRIMARY KEY CLUSTERED 
(
	[kode_airport] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


