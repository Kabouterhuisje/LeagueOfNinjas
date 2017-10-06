CREATE TABLE [dbo].[PurchasedItems]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Ninja] INT NOT NULL, 
    [Equipment] INT NOT NULL, 
    CONSTRAINT [FK_PurchasedItems_loadout] FOREIGN KEY ([Ninja]) REFERENCES [Ninja]([Id]) ON DELETE CASCADE, 
    CONSTRAINT [FK_PurchasedItems_Equipment] FOREIGN KEY ([Equipment]) REFERENCES [Equipment]([Id]) ON DELETE CASCADE
)
