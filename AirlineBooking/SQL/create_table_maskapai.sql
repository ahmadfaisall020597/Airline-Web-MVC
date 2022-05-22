USE [AIRLINE_BOOKING]
GO

drop table if exists [maskapai];

CREATE TABLE [maskapai](
	[kode_maskapai] [varchar](30) NOT NULL,
	[nama_maskapai] [varchar](60) NOT NULL,
	 created_at datetime not null ,
    created_by varchar(60) not null ,
    updated_at datetime null ,
    updated_by varchar null ,

 CONSTRAINT [PK_maskapai] PRIMARY KEY CLUSTERED 
(
	[kode_maskapai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


