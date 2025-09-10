CREATE TABLE [dbo].[RoomType]
(
	[Id] INT NOT NULL PRIMARY KEY identity,                                
    [name] NVARCHAR(50) NOT NULL, 
    [descreptin] NVARCHAR(500) NOT NULL , 
    [Price] MONEY NOT  NULL
)
