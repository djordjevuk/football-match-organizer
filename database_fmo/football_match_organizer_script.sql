USE [FootballMatchOrganizer]
GO
/****** Object:  Table [dbo].[Match]    Script Date: 18-Sep-2019 22:18:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Match](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MatchTime] [datetime] NOT NULL,
	[MatchPlace] [nvarchar](50) NOT NULL,
	[Status] [nvarchar](30) NOT NULL,
	[HostTeamId] [int] NOT NULL,
	[HostTeamResult] [smallint] NOT NULL,
	[GuestTeamId] [int] NOT NULL,
	[GuestTeamResult] [smallint] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Match] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Player]    Script Date: 18-Sep-2019 22:18:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Player](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](70) NOT NULL,
	[TeamId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Player] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlayerOnMatch]    Script Date: 18-Sep-2019 22:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlayerOnMatch](
	[PlayerId] [int] NOT NULL,
	[MatchId] [int] NOT NULL,
	[Score] [smallint] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[PlayerId] ASC,
	[MatchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Team]    Script Date: 18-Sep-2019 22:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Team](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Logo] [nvarchar](300) NULL,
	[Description] [nvarchar](500) NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Team] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Match] ON 

INSERT [dbo].[Match] ([Id], [MatchTime], [MatchPlace], [Status], [HostTeamId], [HostTeamResult], [GuestTeamId], [GuestTeamResult], [Deleted]) VALUES (1, CAST(N'2019-09-15T21:00:00.000' AS DateTime), N'Madrid, Spain', N'Finished', 1, 1, 5, 3, 0)
INSERT [dbo].[Match] ([Id], [MatchTime], [MatchPlace], [Status], [HostTeamId], [HostTeamResult], [GuestTeamId], [GuestTeamResult], [Deleted]) VALUES (3, CAST(N'2019-10-05T23:00:00.000' AS DateTime), N'London, UK', N'Not_started', 2, 0, 5, 0, 0)
INSERT [dbo].[Match] ([Id], [MatchTime], [MatchPlace], [Status], [HostTeamId], [HostTeamResult], [GuestTeamId], [GuestTeamResult], [Deleted]) VALUES (4, CAST(N'2019-09-15T20:00:00.000' AS DateTime), N'London, UK', N'Canceled', 2, 0, 1, 0, 0)
INSERT [dbo].[Match] ([Id], [MatchTime], [MatchPlace], [Status], [HostTeamId], [HostTeamResult], [GuestTeamId], [GuestTeamResult], [Deleted]) VALUES (5, CAST(N'2019-09-14T20:45:00.000' AS DateTime), N'Milan, Italy', N'Finished', 4, 3, 2, 2, 0)
INSERT [dbo].[Match] ([Id], [MatchTime], [MatchPlace], [Status], [HostTeamId], [HostTeamResult], [GuestTeamId], [GuestTeamResult], [Deleted]) VALUES (6, CAST(N'2019-09-15T21:00:00.000' AS DateTime), N'Belgrade, Serbia', N'Finished', 3, 2, 1, 2, 0)
INSERT [dbo].[Match] ([Id], [MatchTime], [MatchPlace], [Status], [HostTeamId], [HostTeamResult], [GuestTeamId], [GuestTeamResult], [Deleted]) VALUES (7, CAST(N'2019-09-17T20:00:00.000' AS DateTime), N'Paris, France', N'Finished', 1005, 2, 4, 0, 0)
INSERT [dbo].[Match] ([Id], [MatchTime], [MatchPlace], [Status], [HostTeamId], [HostTeamResult], [GuestTeamId], [GuestTeamResult], [Deleted]) VALUES (8, CAST(N'2019-11-20T21:00:00.000' AS DateTime), N'Barcelona, Spain', N'Not_started', 5, 0, 1005, 0, 0)
SET IDENTITY_INSERT [dbo].[Match] OFF
SET IDENTITY_INSERT [dbo].[Player] ON 

INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (1, N'Karim Benzema', 1, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (2, N'Sergio Ramos', 1, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (3, N'Toni Kroos', 1, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (4, N'Eden Hazard', 1, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (5, N'Raphael Varane', 1, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (6, N'Dani Carvajal', 1, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (7, N'Marcelo', 1, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (8, N'Casemiro', 1, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (9, N'Marco Asensio', 1, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (10, N'James Rodríguez', 1, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (11, N'Luka Jović', 1, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (12, N'Thibaut Courtois', 1, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (13, N'Ferland Mendy', 1, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (14, N'Azpilicueta', 2, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (15, N'Andreas Christensen', 2, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (16, N'Marcos Alonso', 2, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (17, N'Ross Barkley', 2, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (18, N'Jorginho', 2, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (19, N'N''Golo Kanté', 2, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (20, N'Ruben Loftus-Cheek', 2, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (21, N'Michy Batshuayi', 2, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (22, N'Willian', 2, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (23, N'Olivier Giroud', 2, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (24, N'Milan Borjan', 3, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (25, N'Miloš Degenek', 3, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (26, N'Milan Gajić', 3, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (27, N'Nemanja Milunović', 3, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (28, N'Milan Rodić', 3, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (29, N'Mirko Ivanić', 3, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (30, N'Branko Jovićić', 3, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (31, N'Marko Marin', 3, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (32, N'Richmond Boakye', 3, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (33, N'Milan Pavkov', 3, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (34, N'Veljko Simić', 3, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (35, N'Antonio Rüdiger', 2, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (36, N'Gianluigi Donnarumma', 4, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (37, N'Davide Calabria', 4, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (38, N'Andrea Conti', 4, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (39, N'Matteo Gabbia', 4, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (40, N'Ricardo Rodríguez', 4, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (41, N'Lucas Biglia', 4, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (42, N'Giacomo Bonaventura', 4, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (43, N'Franck Kessié', 4, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (44, N'Lucas Paquetá', 4, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (45, N'Fabio Borini', 4, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (46, N'Ante Rebić', 4, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (47, N'Suso', 4, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (48, N'Marc-André ter Stegen', 5, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (49, N'Jordi Alba', 5, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (50, N'Nélson Semedo', 5, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (51, N'Piqué', 5, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (52, N'Samuel Umtiti', 5, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (53, N'Busquets', 5, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (54, N'Frenkie de Jong', 5, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (55, N'Ivan Rakitić', 5, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (56, N'Sergi Roberto', 5, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (57, N'Arturo Vidal', 5, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (58, N'Ousmane Dembélé', 5, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (59, N'Antoine Griezmann', 5, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (60, N'Lionel Messi', 5, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (61, N'Luis Suárez', 5, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (62, N'Keylor Navas', 1005, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (63, N'Juan Bernat', 1005, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (64, N'Thilo Kehrer', 1005, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (65, N'Presnel Kimpembe', 1005, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (66, N'Marquinhos', 1005, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (67, N'Loïc Mbe Soh', 1005, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (68, N'Thomas Meunier', 1005, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (69, N'Thiago Silva', 1005, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (70, N'Ander Herrera', 1005, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (71, N'Pablo Sarabia', 1005, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (72, N'Marco Verratti', 1005, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (73, N'Edinson Cavani', 1005, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (74, N'Ángel Di María', 1005, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (75, N'Mauro Icardi', 1005, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (76, N'Julian Draxler', 1005, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (77, N'Kylian Mbappé', 1005, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (78, N'Neymar', 1005, 0)
INSERT [dbo].[Player] ([Id], [Name], [TeamId], [Deleted]) VALUES (79, N'Kepa Arrizabalaga', 2, 0)
SET IDENTITY_INSERT [dbo].[Player] OFF
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (1, 1, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (1, 6, 1, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (2, 1, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (2, 4, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (2, 6, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (3, 1, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (3, 6, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (4, 1, 1, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (4, 4, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (4, 6, 1, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (5, 1, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (5, 4, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (5, 6, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (6, 4, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (6, 6, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (7, 1, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (7, 4, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (7, 6, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (8, 1, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (8, 4, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (8, 6, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (9, 1, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (9, 6, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (11, 1, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (12, 1, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (12, 6, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (13, 1, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (13, 6, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (14, 3, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (14, 4, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (14, 5, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (15, 3, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (15, 5, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (16, 3, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (16, 4, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (16, 5, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (17, 3, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (18, 3, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (18, 4, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (18, 5, 1, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (19, 3, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (19, 4, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (19, 5, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (20, 3, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (20, 5, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (21, 3, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (21, 5, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (22, 3, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (22, 4, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (22, 5, 1, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (23, 3, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (23, 4, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (23, 5, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (24, 6, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (25, 6, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (26, 6, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (27, 6, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (28, 6, 1, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (29, 6, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (30, 6, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (31, 6, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (32, 6, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (33, 6, 1, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (34, 6, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (35, 3, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (35, 5, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (36, 5, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (36, 7, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (37, 5, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (37, 7, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (38, 5, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (38, 7, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (39, 5, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (39, 7, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (40, 5, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (40, 7, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (41, 5, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (41, 7, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (42, 5, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (42, 7, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (43, 5, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (43, 7, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (44, 5, 2, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (44, 7, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (45, 5, 1, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (45, 7, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (46, 5, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (47, 7, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (48, 1, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (48, 3, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (48, 8, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (49, 1, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (49, 3, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (49, 8, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (50, 1, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (50, 3, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (50, 8, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (51, 1, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (51, 3, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (51, 8, 0, 0)
GO
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (52, 3, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (52, 8, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (53, 8, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (54, 1, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (54, 3, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (55, 1, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (55, 3, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (55, 8, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (56, 3, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (57, 1, 1, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (57, 3, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (57, 8, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (58, 1, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (59, 1, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (59, 3, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (59, 8, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (60, 1, 1, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (60, 3, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (60, 8, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (61, 1, 1, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (61, 8, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (62, 7, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (62, 8, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (63, 7, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (63, 8, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (64, 7, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (64, 8, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (65, 7, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (65, 8, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (66, 7, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (66, 8, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (67, 7, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (68, 7, 1, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (68, 8, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (69, 8, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (71, 8, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (72, 7, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (72, 8, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (73, 7, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (74, 7, 1, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (77, 7, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (77, 8, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (78, 8, 0, 0)
INSERT [dbo].[PlayerOnMatch] ([PlayerId], [MatchId], [Score], [Deleted]) VALUES (79, 5, 0, 0)
SET IDENTITY_INSERT [dbo].[Team] ON 

INSERT [dbo].[Team] ([Id], [Name], [Logo], [Description], [Deleted]) VALUES (1, N'FC Real Madrid', N'1.png', NULL, 0)
INSERT [dbo].[Team] ([Id], [Name], [Logo], [Description], [Deleted]) VALUES (2, N'FC Chelsea', N'2.png', NULL, 0)
INSERT [dbo].[Team] ([Id], [Name], [Logo], [Description], [Deleted]) VALUES (3, N'FC Red Star', N'3.png', NULL, 0)
INSERT [dbo].[Team] ([Id], [Name], [Logo], [Description], [Deleted]) VALUES (4, N'AC Milan', N'4.png', NULL, 0)
INSERT [dbo].[Team] ([Id], [Name], [Logo], [Description], [Deleted]) VALUES (5, N'FC Barcelona', N'5.png', NULL, 0)
INSERT [dbo].[Team] ([Id], [Name], [Logo], [Description], [Deleted]) VALUES (1005, N'FC Paris Saint-Germain', N'1005.jpg', NULL, 0)
INSERT [dbo].[Team] ([Id], [Name], [Logo], [Description], [Deleted]) VALUES (1006, N'Borussia Dortmund', N'1006.jpg', NULL, 0)
SET IDENTITY_INSERT [dbo].[Team] OFF
ALTER TABLE [dbo].[Match] ADD  CONSTRAINT [DF_Match_Status]  DEFAULT (N'Not started') FOR [Status]
GO
ALTER TABLE [dbo].[Match] ADD  CONSTRAINT [DF_Match_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dbo].[Player] ADD  CONSTRAINT [DF_Player_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dbo].[PlayerOnMatch] ADD  CONSTRAINT [DF_PlayerOnMatch_Score]  DEFAULT ((0)) FOR [Score]
GO
ALTER TABLE [dbo].[PlayerOnMatch] ADD  CONSTRAINT [DF_PlayerOnMatch_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dbo].[Team] ADD  CONSTRAINT [DF_Team_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dbo].[Match]  WITH CHECK ADD  CONSTRAINT [FK_Match_Team] FOREIGN KEY([HostTeamId])
REFERENCES [dbo].[Team] ([Id])
GO
ALTER TABLE [dbo].[Match] CHECK CONSTRAINT [FK_Match_Team]
GO
ALTER TABLE [dbo].[Match]  WITH CHECK ADD  CONSTRAINT [FK_Match_Team1] FOREIGN KEY([GuestTeamId])
REFERENCES [dbo].[Team] ([Id])
GO
ALTER TABLE [dbo].[Match] CHECK CONSTRAINT [FK_Match_Team1]
GO
ALTER TABLE [dbo].[Player]  WITH CHECK ADD  CONSTRAINT [FK_Player_Team] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Team] ([Id])
GO
ALTER TABLE [dbo].[Player] CHECK CONSTRAINT [FK_Player_Team]
GO
ALTER TABLE [dbo].[PlayerOnMatch]  WITH CHECK ADD  CONSTRAINT [FK_PlayerOnMatch_Match] FOREIGN KEY([MatchId])
REFERENCES [dbo].[Match] ([Id])
GO
ALTER TABLE [dbo].[PlayerOnMatch] CHECK CONSTRAINT [FK_PlayerOnMatch_Match]
GO
ALTER TABLE [dbo].[PlayerOnMatch]  WITH CHECK ADD  CONSTRAINT [FK_PlayerOnMatch_Player] FOREIGN KEY([PlayerId])
REFERENCES [dbo].[Player] ([Id])
GO
ALTER TABLE [dbo].[PlayerOnMatch] CHECK CONSTRAINT [FK_PlayerOnMatch_Player]
GO
