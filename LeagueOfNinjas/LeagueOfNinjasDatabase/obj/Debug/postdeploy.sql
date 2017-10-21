/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
INSERT INTO Category
VALUES ('Head'), ('Shoulders'), ('Chest'), ('Belt'), ('Legs'), ('Boots');

INSERT INTO Ninja
--      gold name
VALUES ('0', 'Dennis'), ('100', 'Ryan'), ('500', 'Chinghar'), ('279', 'Jurgen'), ('1245', 'Stijn');

INSERT INTO Equipment
--      type        value	    Strength	Intelligence	Agility	Name                  Image
VALUES ('Head',		'3500',		null,		'100',			null,	'Veil of Steel',	null),
	   ('Shoulders','500',		'10',		null,			'-10',	'Glorious Balor Pauldrons',		null),
	   ('Chest',	'100',		'80',		null,			null,	'Heart of Iron',		null),
	   ('Belt',		'75',		'15',		null,			'-15',	'Hide Belt',			null),
	   ('Legs',		'150',		'10',		null,			'25',	'Mystery Pants',	null),
	   ('Boots',		'250',		null,		null,			'60',	'Mystery Boots',	null),
	   ('Chest',	'100',		'40',		'-5',			null,	'Chain Mail',			null),
	   ('Head',		'500',		'20',		'10',			'60',	'Warhelm of Kassar',		null),
	   ('Shoulders','250',		null,		null,			'60',	'Homing Pads',		null),
	   ('Belt',		'2000',		'70',		null,			'80',	'Mystery Belt',		null),
	   ('Legs',		'350',		null,		null,			'60',	'Hide Pants',			null),
	   ('Shoulders','500',		null,		'100',			'20',	'Mystery Shoulders',		null),
	   ('Head',		'700',		null,		'300',			'20',	'Leorics Crown',		null),
	   ('Boots',		'250',		null,		null,			'60',	'Rivera Dancers',		null),
	   ('Boots',		'50',		'45',		null,			'10',	'Lut Boots',	null

); 


INSERT INTO PurchasedItems
--       ninja	    equipment
VALUES	 ('1',		'4'),
		 ('2',		'5'),
		 ('3',		'6'),
		 ('4',		'8'),
		 ('2',		'1'),
		 ('5',		'4');

INSERT INTO Loadout
--		name			ninja
VALUES	('Loadout #1',	'1'),
		('Loadout #2',	'2'),
		('Loadout #3',	'3'),
		('Loadout #4',	'4'),
		('Loadout #5',	'5'),
		('Loadout #6',	'2'); 

INSERT INTO LoadoutItems
--		Loadout   Equipment
VALUES ('1', '4'), ('2', '5'), ('3', '6'), ('4', '8'), ('5', '4'), ('6', '1'), ('6', '5');
GO
