CREATE TABLE [dbo].[Equipment]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Type] VARCHAR(45) NOT NULL, 
    [Value] INT NOT NULL, 
    [Strength] INT NULL, 
    [Intelligence] INT NULL, 
    [Agility] INT NULL, 
    [Name] VARCHAR(MAX) NOT NULL, 
    [Image] VARBINARY(MAX) NULL, 
    CONSTRAINT [FK_Equipment_Category] FOREIGN KEY ([Type]) REFERENCES [Category]([Type]) ON DELETE CASCADE
)
