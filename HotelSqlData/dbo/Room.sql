CREATE TABLE [dbo].[Room]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [TypeId] INT NOT NULL, 
    [RoomNumber] NCHAR(10) NOT NULL, 
    CONSTRAINT [FK_Room_ToTable] FOREIGN KEY ([TypeId]) REFERENCES [RoomType]([id])
)
