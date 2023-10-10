CREATE TABLE [dbo].PermissionType (
	[Id] [int] IDENTITY(1,1) NOT NULL,	
	[Description] [nvarchar](200) NULL,	
	CONSTRAINT PermissionType_PK PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].Permission (
	[Id] [int] IDENTITY(1,1) NOT NULL,	
	[PermissionType_Id] [int] NOT NULL,	
	[EmployeeName] [nvarchar](100) NOT NULL,	
	[EmployeeSurname] [nvarchar](100)  NOT NULL,	
	[PermissionDate] [datetime] NOT NULL,		  	
	CONSTRAINT Permission_PK PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].Permission WITH CHECK ADD CONSTRAINT [FK_Permission_dbo.PermissionType_Id] FOREIGN KEY(PermissionType_Id)
REFERENCES [dbo].[PermissionType] ([Id])
GO

ALTER TABLE [dbo].Permission CHECK CONSTRAINT [FK_Permission_dbo.PermissionType_Id]
GO


insert into PermissionType(Description)
values
('Admin'),
('Basic'),
('Full');
