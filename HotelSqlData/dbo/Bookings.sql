CREATE TABLE [dbo].[Bookings]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [startDate] DATETIME2 NOT NULL, 
    [endDate] DATETIME2 NOT NULL, 
    [RoomId] INT NOT NULL, 
    [guestId] INT NOT NULL, 
    [isChekedIn] BIT NOT NULL DEFAULT 0, 
    [totelPrice] MONEY NOT NULL, 
    [RoomNumber] NCHAR(10) NOT NULL, 
    CONSTRAINT [FK_Bookings_ToTable] FOREIGN KEY ([roomId]) REFERENCES Room(id), 
    CONSTRAINT [FK_Bookings_ToTable_1] FOREIGN KEY ([guestId]) REFERENCES gusest(Id)
)
