CREATE TABLE [dbo].[LoadoutItems]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Loadout] INT NOT NULL, 
    [Equipment] INT NOT NULL, 
    CONSTRAINT [FK_LoadoutItems_Loadout] FOREIGN KEY ([Loadout]) REFERENCES [Loadout]([Id]) ON DELETE CASCADE, 
    CONSTRAINT [FK_LoadoutItems_Equipment] FOREIGN KEY ([Equipment]) REFERENCES [Equipment]([Id])  ON DELETE CASCADE
)
