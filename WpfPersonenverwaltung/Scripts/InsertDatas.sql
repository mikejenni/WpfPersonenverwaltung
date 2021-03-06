USE [PersonManagement]
GO

SET IDENTITY_INSERT [dbo].[Abteilung] ON 

INSERT [dbo].[Abteilung] ([AbteilungId], [Name]) VALUES (1, N'Finanzen')
INSERT [dbo].[Abteilung] ([AbteilungId], [Name]) VALUES (2, N'Informatik')
INSERT [dbo].[Abteilung] ([AbteilungId], [Name]) VALUES (3, N'Controlling')
INSERT [dbo].[Abteilung] ([AbteilungId], [Name]) VALUES (4, N'Verkauf')
SET IDENTITY_INSERT [dbo].[Abteilung] OFF
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([Id], [Name], [SecondName], [Street], [Plz], [Place], [AbteilungId]) VALUES (1, N'Wolfsdasda', N'Kurt', N'Dorfstrasse 143', N'8400', N'Winterthur', 1)
INSERT [dbo].[Person] ([Id], [Name], [SecondName], [Street], [Plz], [Place], [AbteilungId]) VALUES (2, N'Sandro', N'Muster', N'Stationsstrasse 29', N'8001', N'Zürich', 2)
INSERT [dbo].[Person] ([Id], [Name], [SecondName], [Street], [Plz], [Place], [AbteilungId]) VALUES (3, N'Bechtle', N'Thomas', N'Bahnhofstrasse 10', N'8303', N'Bassersdorf', 3)
INSERT [dbo].[Person] ([Id], [Name], [SecondName], [Street], [Plz], [Place], [AbteilungId]) VALUES (14, N'Beller', N'Ahmet', N'Im Feld 32', N'8424', N'Embrach', 3)
SET IDENTITY_INSERT [dbo].[Person] OFF
