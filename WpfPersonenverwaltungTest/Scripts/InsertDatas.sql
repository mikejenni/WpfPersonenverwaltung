USE [PersonManagementTest]

DELETE FROM PersonManagementTest.dbo.Person
GO                 
INSERT [dbo].[Person] ([Name], [SecondName], [Street], [Plz], [Place], [AbteilungId]) VALUES ('Wolfsdasda', 'Kurt', 'Dorfstrasse 143', '8400', 'Winterthur', 1)
INSERT [dbo].[Person] ([Name], [SecondName], [Street], [Plz], [Place], [AbteilungId]) VALUES ('Sandro', 'Muster', 'Stationsstrasse 29', '8001', 'Zürich', 2)
INSERT [dbo].[Person] ([Name], [SecondName], [Street], [Plz], [Place], [AbteilungId]) VALUES ('Bechtle', 'Thomas', 'Bahnhofstrasse 10', '8303', 'Bassersdorf', 3)
INSERT [dbo].[Person] ([Name], [SecondName], [Street], [Plz], [Place], [AbteilungId]) VALUES ('Beller', 'Ahmet', 'Im Feld 32', '8424', 'Embrach', 3)