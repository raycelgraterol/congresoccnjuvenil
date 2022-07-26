IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726141745_Init load all tables')
BEGIN
    CREATE TABLE [Congregations] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(255) NULL,
        [Direction] nvarchar(500) NULL,
        CONSTRAINT [PK_Congregations] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726141745_Init load all tables')
BEGIN
    CREATE TABLE [Countries] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(255) NULL,
        CONSTRAINT [PK_Countries] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726141745_Init load all tables')
BEGIN
    CREATE TABLE [PodCasts] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(255) NULL,
        [Link] nvarchar(500) NULL,
        [Description] nvarchar(255) NULL,
        [TransmissionDate] datetime2 NOT NULL,
        CONSTRAINT [PK_PodCasts] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726141745_Init load all tables')
BEGIN
    CREATE TABLE [Role] (
        [Id] bigint NOT NULL IDENTITY,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_Role] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726141745_Init load all tables')
BEGIN
    CREATE TABLE [Teams] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(255) NULL,
        [Link] nvarchar(500) NULL,
        CONSTRAINT [PK_Teams] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726141745_Init load all tables')
BEGIN
    CREATE TABLE [RoleClaim] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] bigint NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_RoleClaim] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_RoleClaim_Role_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Role] ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726141745_Init load all tables')
BEGIN
    CREATE TABLE [User] (
        [Id] bigint NOT NULL IDENTITY,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        [FirstName] nvarchar(max) NULL,
        [LastName] nvarchar(max) NULL,
        [Email] nvarchar(256) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [Age] int NOT NULL,
        [Instagram] nvarchar(255) NULL,
        [Facebook] nvarchar(255) NULL,
        [TikTok] nvarchar(255) NULL,
        [Twitter] nvarchar(255) NULL,
        [NeedContact] bit NOT NULL,
        [CongregationId] int NOT NULL,
        [TeamId] int NULL,
        CONSTRAINT [PK_User] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_User_Congregations_CongregationId] FOREIGN KEY ([CongregationId]) REFERENCES [Congregations] ([Id]),
        CONSTRAINT [FK_User_Teams_TeamId] FOREIGN KEY ([TeamId]) REFERENCES [Teams] ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726141745_Init load all tables')
BEGIN
    CREATE TABLE [PodCastUsers] (
        [AppUserId] bigint NOT NULL,
        [PodCastId] int NOT NULL,
        CONSTRAINT [PK_PodCastUsers] PRIMARY KEY ([PodCastId], [AppUserId]),
        CONSTRAINT [FK_PodCastUsers_User_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [User] ([Id]),
        CONSTRAINT [FK_PodCastUsers_PodCasts_PodCastId] FOREIGN KEY ([PodCastId]) REFERENCES [PodCasts] ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726141745_Init load all tables')
BEGIN
    CREATE TABLE [UserClaim] (
        [Id] int NOT NULL IDENTITY,
        [UserId] bigint NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_UserClaim] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_UserClaim_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726141745_Init load all tables')
BEGIN
    CREATE TABLE [UserLogin] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] bigint NOT NULL,
        CONSTRAINT [PK_UserLogin] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_UserLogin_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726141745_Init load all tables')
BEGIN
    CREATE TABLE [UserRole] (
        [UserId] bigint NOT NULL,
        [RoleId] bigint NOT NULL,
        CONSTRAINT [PK_UserRole] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_UserRole_Role_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Role] ([Id]),
        CONSTRAINT [FK_UserRole_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726141745_Init load all tables')
BEGIN
    CREATE TABLE [UserToken] (
        [UserId] bigint NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_UserToken] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_UserToken_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726141745_Init load all tables')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Direction', N'Name') AND [object_id] = OBJECT_ID(N'[Congregations]'))
        SET IDENTITY_INSERT [Congregations] ON;
    INSERT INTO [Congregations] ([Id], [Direction], [Name])
    VALUES (1, N'', N'Caracas'),
    (80, N'', N'Fundación Apostólica Jesús te ama(Asociado)'),
    (79, N'', N'Centro Cristiano Restauración(Asociado)'),
    (78, N'', N'Villa Gesell'),
    (77, N'', N'Banda Rio Sali - Tucumán'),
    (76, N'', N'Ezeiza'),
    (75, N'', N'General Alvear'),
    (74, N'', N'Lanus'),
    (73, N'', N'Berazategui'),
    (72, N'', N'Huanguelen'),
    (71, N'', N'América'),
    (70, N'', N'Tucumán'),
    (69, N'', N'José León Suarez'),
    (68, N'', N'Cordoba'),
    (67, N'', N'Moreno'),
    (66, N'', N'El Palomar'),
    (65, N'', N'Morón'),
    (64, N'', N'Ciudad Ojeda'),
    (63, N'', N'Bachaquero'),
    (61, N'', N'Mérida'),
    (60, N'', N'San Cristobal'),
    (59, N'', N'Valera'),
    (58, N'', N'Santa Elena de Uairen'),
    (57, N'', N'Caicara del Orinoco'),
    (81, N'', N'Encarnación'),
    (56, N'', N'Upata'),
    (82, N'', N'Discípulos de Cristo(Asociado)'),
    (84, N'', N'Santiago'),
    (107, N'', N'Ninguna'),
    (106, N'', N'New York'),
    (105, N'', N'Sarasota'),
    (104, N'', N'Miami'),
    (103, N'', N'Coatzacoalcos / Minatitlán'),
    (102, N'', N'Leon'),
    (101, N'', N'Minatitlán'),
    (100, N'', N'Coatzacoalcos'),
    (99, N'', N'Lima'),
    (98, N'', N'Panamá'),
    (97, N'', N'Armenia'),
    (96, N'', N'Sincelejos'),
    (95, N'', N'Cúcuta'),
    (94, N'', N'Bogota'),
    (93, N'', N'Cartagena'),
    (92, N'', N'Barranquilla'),
    (91, N'', N'Madrid'),
    (90, N'', N'CT Casablanca'),
    (89, N'', N'CT Copiapó'),
    (88, N'', N'CT Chumil'),
    (87, N'', N'Lautaro'),
    (86, N'', N'Los Ángeles'),
    (85, N'', N'Rancagua'),
    (83, N'', N'Viña del Mar'),
    (55, N'', N'Ciudad Guayana'),
    (62, N'', N'Maracaibo'),
    (53, N'', N'Punta de Mata'),
    (25, N'', N'La Via'),
    (24, N'', N'Los Teques'),
    (23, N'', N'Carrizal'),
    (22, N'', N'El Rodeo'),
    (21, N'', N'Guarenas'),
    (54, N'', N'Temblador'),
    (19, N'', N'Cua'),
    (18, N'', N'Charallave'),
    (17, N'', N'Araira'),
    (16, N'', N'Caucagua'),
    (15, N'', N'San Antonio'),
    (26, N'', N'Higuerote'),
    (14, N'', N'Guatire'),
    (12, N'', N'El Hatillo'),
    (11, N'', N'Baruta'),
    (10, N'', N'Clarines'),
    (9, N'', N'Puerto la Cruz'),
    (8, N'', N'El Junquito'),
    (7, N'', N'Naiguata'),
    (6, N'', N'Punto Fijo'),
    (5, N'', N'Mariches'),
    (4, N'', N'Las Adjuntas'),
    (3, N'', N'Catia'),
    (2, N'', N'Catia La Mar'),
    (13, N'', N'Coro'),
    (27, N'', N'Rio Chico'),
    (20, N'', N'Ocumare'),
    (29, N'', N'Juan Griego'),
    (52, N'', N'Maturín'),
    (51, N'', N'San Carlos'),
    (50, N'', N'Puerto Cabello'),
    (49, N'', N'San Felipe'),
    (28, N'', N'Las Clavellinas'),
    (47, N'', N'Fundagex(Asociado)'),
    (46, N'Barinitas', N'Barinitas'),
    (45, N'', N'Chabasquen'),
    (44, N'', N'Potreritos'),
    (43, N'', N'Campo Ameno'),
    (42, N'', N' Las Tejerías'),
    (48, N'', N'Valencia'),
    (40, N'', N'Biscucuy'),
    (39, N'', N'Guárico'),
    (38, N'', N'La Victoria'),
    (37, N'', N'Maracay'),
    (36, N'', N'CT Curiepe'),
    (35, N'', N'Cumana'),
    (34, N'', N'San Diego'),
    (33, N'', N'Cantaura'),
    (32, N'', N'Anaco'),
    (31, N'', N'Yare'),
    (30, N'', N'Santa Teresa'),
    (41, N'', N'Barquisimeto');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Direction', N'Name') AND [object_id] = OBJECT_ID(N'[Congregations]'))
        SET IDENTITY_INSERT [Congregations] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726141745_Init load all tables')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Link', N'Name', N'TransmissionDate') AND [object_id] = OBJECT_ID(N'[PodCasts]'))
        SET IDENTITY_INSERT [PodCasts] ON;
    INSERT INTO [PodCasts] ([Id], [Description], [Link], [Name], [TransmissionDate])
    VALUES (7, NULL, N'#', N'Porque estar solo, nunca será mejor. Especial para solteros', '2021-08-26T16:55:00.0000000'),
    (6, NULL, N'#', N'¿Y cómo funciona esto? Especial para novios', '2021-08-26T15:55:00.0000000'),
    (5, NULL, N'#', N'Visión, emprendimiento y libertad financiera', '2021-08-26T14:50:00.0000000'),
    (2, NULL, N'#', N'Vocación, visión, llamado y productividad', '2021-08-25T15:50:00.0000000'),
    (3, NULL, N'#', N'Pandemia de Amor', '2021-08-25T16:50:00.0000000'),
    (1, NULL, N'#', N'Alabanza y adoración', '2021-08-25T14:50:00.0000000'),
    (4, NULL, N'#', N'Desenmascarando la ideología de género', '2021-08-25T17:45:00.0000000');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Link', N'Name', N'TransmissionDate') AND [object_id] = OBJECT_ID(N'[PodCasts]'))
        SET IDENTITY_INSERT [PodCasts] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726141745_Init load all tables')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[Role]'))
        SET IDENTITY_INSERT [Role] ON;
    INSERT INTO [Role] ([Id], [ConcurrencyStamp], [Name], [NormalizedName])
    VALUES (CAST(4 AS bigint), N'1209d965-96f4-4402-8f9a-991e6964728a', N'Coordinador Congreso', N'Coordinador Congreso'),
    (CAST(1 AS bigint), N'1209d965-96f4-4402-8f9a-991e6964728a', N'Admin', N'ADMIN'),
    (CAST(2 AS bigint), N'1209d965-96f4-4402-8f9a-991e6964728a', N'Lider Equipo', N'LIDER EQUIPO'),
    (CAST(3 AS bigint), N'1209d965-96f4-4402-8f9a-991e6964728a', N'Coordinador MOXA', N'COORDINADOR MOXA'),
    (CAST(5 AS bigint), N'1209d965-96f4-4402-8f9a-991e6964728a', N'Participante', N'Participante');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[Role]'))
        SET IDENTITY_INSERT [Role] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726141745_Init load all tables')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Link', N'Name') AND [object_id] = OBJECT_ID(N'[Teams]'))
        SET IDENTITY_INSERT [Teams] ON;
    INSERT INTO [Teams] ([Id], [Link], [Name])
    VALUES (1, N'https://t.me/joinchat/HZegqf-GylxlMWUx', N'M-1 MOXAGUILAS'),
    (2, N'https://t.me/joinchat/WHUPm1WLCWZjYjAx', N'M-2 Manada Divergente'),
    (3, N'https://t.me/joinchat/BmGdsXc_nUU1OTNh', N'M-3 LEGENDARIOS'),
    (4, N'https://t.me/joinchat/cdnPblmq7C0wMzVh', N'M-4 JUVENTUD DIVERGENTE');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Link', N'Name') AND [object_id] = OBJECT_ID(N'[Teams]'))
        SET IDENTITY_INSERT [Teams] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726141745_Init load all tables')
BEGIN
    CREATE INDEX [IX_PodCastUsers_AppUserId] ON [PodCastUsers] ([AppUserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726141745_Init load all tables')
BEGIN
    CREATE UNIQUE INDEX [RoleNameIndex] ON [Role] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726141745_Init load all tables')
BEGIN
    CREATE INDEX [IX_RoleClaim_RoleId] ON [RoleClaim] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726141745_Init load all tables')
BEGIN
    CREATE INDEX [IX_User_CongregationId] ON [User] ([CongregationId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726141745_Init load all tables')
BEGIN
    CREATE INDEX [EmailIndex] ON [User] ([NormalizedEmail]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726141745_Init load all tables')
BEGIN
    CREATE UNIQUE INDEX [UserNameIndex] ON [User] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726141745_Init load all tables')
BEGIN
    CREATE INDEX [IX_User_TeamId] ON [User] ([TeamId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726141745_Init load all tables')
BEGIN
    CREATE INDEX [IX_UserClaim_UserId] ON [UserClaim] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726141745_Init load all tables')
BEGIN
    CREATE INDEX [IX_UserLogin_UserId] ON [UserLogin] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726141745_Init load all tables')
BEGIN
    CREATE INDEX [IX_UserRole_RoleId] ON [UserRole] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726141745_Init load all tables')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210726141745_Init load all tables', N'3.1.17');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210727183627_add congregation')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Direction', N'Name') AND [object_id] = OBJECT_ID(N'[Congregations]'))
        SET IDENTITY_INSERT [Congregations] ON;
    INSERT INTO [Congregations] ([Id], [Direction], [Name])
    VALUES (108, N'', N'Porlamar');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Direction', N'Name') AND [object_id] = OBJECT_ID(N'[Congregations]'))
        SET IDENTITY_INSERT [Congregations] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210727183627_add congregation')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210727183627_add congregation', N'3.1.17');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210727194553_add congregation news')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Direction', N'Name') AND [object_id] = OBJECT_ID(N'[Congregations]'))
        SET IDENTITY_INSERT [Congregations] ON;
    INSERT INTO [Congregations] ([Id], [Direction], [Name])
    VALUES (109, N'', N'Las Tejerías');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Direction', N'Name') AND [object_id] = OBJECT_ID(N'[Congregations]'))
        SET IDENTITY_INSERT [Congregations] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210727194553_add congregation news')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Direction', N'Name') AND [object_id] = OBJECT_ID(N'[Congregations]'))
        SET IDENTITY_INSERT [Congregations] ON;
    INSERT INTO [Congregations] ([Id], [Direction], [Name])
    VALUES (110, N'', N'Santa Bárbara');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Direction', N'Name') AND [object_id] = OBJECT_ID(N'[Congregations]'))
        SET IDENTITY_INSERT [Congregations] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210727194553_add congregation news')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Direction', N'Name') AND [object_id] = OBJECT_ID(N'[Congregations]'))
        SET IDENTITY_INSERT [Congregations] ON;
    INSERT INTO [Congregations] ([Id], [Direction], [Name])
    VALUES (111, N'', N'Guanare');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Direction', N'Name') AND [object_id] = OBJECT_ID(N'[Congregations]'))
        SET IDENTITY_INSERT [Congregations] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210727194553_add congregation news')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210727194553_add congregation news', N'3.1.17');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210727200341_add congregation others')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Direction', N'Name') AND [object_id] = OBJECT_ID(N'[Congregations]'))
        SET IDENTITY_INSERT [Congregations] ON;
    INSERT INTO [Congregations] ([Id], [Direction], [Name])
    VALUES (112, N'', N'Otra congregación');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Direction', N'Name') AND [object_id] = OBJECT_ID(N'[Congregations]'))
        SET IDENTITY_INSERT [Congregations] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210727200341_add congregation others')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210727200341_add congregation others', N'3.1.17');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210731144924_New Referred By')
BEGIN
    ALTER TABLE [User] ADD [IsReferred] bit NOT NULL DEFAULT CAST(0 AS bit);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210731144924_New Referred By')
BEGIN
    ALTER TABLE [User] ADD [ReferredBy] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210731144924_New Referred By')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210731144924_New Referred By', N'3.1.17');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210823192523_New Converted')
BEGIN
    ALTER TABLE [User] ADD [IsNewConverted] bit NOT NULL DEFAULT CAST(0 AS bit);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210823192523_New Converted')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210823192523_New Converted', N'3.1.17');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220713023433_No need 2021 propierties.')
BEGIN
    DELETE FROM [PodCasts]
    WHERE [Id] = 4;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220713023433_No need 2021 propierties.')
BEGIN
    DELETE FROM [PodCasts]
    WHERE [Id] = 5;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220713023433_No need 2021 propierties.')
BEGIN
    DELETE FROM [PodCasts]
    WHERE [Id] = 6;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220713023433_No need 2021 propierties.')
BEGIN
    DELETE FROM [PodCasts]
    WHERE [Id] = 7;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220713023433_No need 2021 propierties.')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[User]') AND [c].[name] = N'IsReferred');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [User] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [User] DROP COLUMN [IsReferred];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220713023433_No need 2021 propierties.')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[User]') AND [c].[name] = N'ReferredBy');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [User] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [User] DROP COLUMN [ReferredBy];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220713023433_No need 2021 propierties.')
BEGIN
    UPDATE [Congregations] SET [Name] = N'Guanare'
    WHERE [Id] = 107;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220713023433_No need 2021 propierties.')
BEGIN
    UPDATE [Congregations] SET [Direction] = N'Otra congregación', [Name] = N''
    WHERE [Id] = 111;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220713023433_No need 2021 propierties.')
BEGIN
    UPDATE [Congregations] SET [Name] = N'Ninguna'
    WHERE [Id] = 112;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220713023433_No need 2021 propierties.')
BEGIN
    UPDATE [PodCasts] SET [Name] = N'Jueves - Día 1', [TransmissionDate] = '2022-08-01T08:00:00.0000000'
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220713023433_No need 2021 propierties.')
BEGIN
    UPDATE [PodCasts] SET [Name] = N'Viernes - Día 2', [TransmissionDate] = '2022-08-01T08:00:00.0000000'
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220713023433_No need 2021 propierties.')
BEGIN
    UPDATE [PodCasts] SET [Name] = N'Sabado - Día 3', [TransmissionDate] = '2022-08-01T08:00:00.0000000'
    WHERE [Id] = 3;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220713023433_No need 2021 propierties.')
BEGIN
    UPDATE [Teams] SET [Name] = N'Equipo 1 Guardianes'
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220713023433_No need 2021 propierties.')
BEGIN
    UPDATE [Teams] SET [Name] = N'Equipo-2 Transformados'
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220713023433_No need 2021 propierties.')
BEGIN
    UPDATE [Teams] SET [Name] = N'Equipo-3 Trascendentes'
    WHERE [Id] = 3;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220713023433_No need 2021 propierties.')
BEGIN
    UPDATE [Teams] SET [Name] = N'Equipo-4 Titanes'
    WHERE [Id] = 4;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220713023433_No need 2021 propierties.')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Link', N'Name') AND [object_id] = OBJECT_ID(N'[Teams]'))
        SET IDENTITY_INSERT [Teams] ON;
    INSERT INTO [Teams] ([Id], [Link], [Name])
    VALUES (5, N'https://t.me/joinchat/cdnPblmq7C0wMzVh', N'Equipo-5 Rompetechos'),
    (6, N'https://t.me/joinchat/cdnPblmq7C0wMzVh', N'Equipo-6 Centinelas');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Link', N'Name') AND [object_id] = OBJECT_ID(N'[Teams]'))
        SET IDENTITY_INSERT [Teams] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220713023433_No need 2021 propierties.')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220713023433_No need 2021 propierties.', N'3.1.17');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719025413_Teams with telegram')
BEGIN
    UPDATE [Teams] SET [Link] = N'https://t.me/+lb3zWHUEX_RlZDlh'
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719025413_Teams with telegram')
BEGIN
    UPDATE [Teams] SET [Link] = N'https://t.me/+scShTrVhdJ1kMjJh'
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719025413_Teams with telegram')
BEGIN
    UPDATE [Teams] SET [Link] = N'https://t.me/+igdFNnHL5k5iMTNh'
    WHERE [Id] = 3;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719025413_Teams with telegram')
BEGIN
    UPDATE [Teams] SET [Link] = N'https://t.me/+YFa4bjX2QD43M2Zh'
    WHERE [Id] = 4;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719025413_Teams with telegram')
BEGIN
    UPDATE [Teams] SET [Link] = N'https://t.me/+1KPM9wahKmw1NTEx'
    WHERE [Id] = 5;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719025413_Teams with telegram')
BEGIN
    UPDATE [Teams] SET [Link] = N'https://t.me/+64zUs09alEg5NzYx'
    WHERE [Id] = 6;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719025413_Teams with telegram')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220719025413_Teams with telegram', N'3.1.17');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719032945_Type Visitors')
BEGIN
    ALTER TABLE [User] ADD [TypeVisitors] int NOT NULL DEFAULT 1;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719032945_Type Visitors')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220719032945_Type Visitors', N'3.1.17');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719180136_Remove type visitors')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[User]') AND [c].[name] = N'TypeVisitors');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [User] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [User] DROP COLUMN [TypeVisitors];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719180136_Remove type visitors')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220719180136_Remove type visitors', N'3.1.17');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719180450_New question comment about moxa 2022')
BEGIN
    ALTER TABLE [User] ADD [CommentMOXA2022] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719180450_New question comment about moxa 2022')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220719180450_New question comment about moxa 2022', N'3.1.17');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220725234906_New CCN')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Direction', N'Name') AND [object_id] = OBJECT_ID(N'[Congregations]'))
        SET IDENTITY_INSERT [Congregations] ON;
    INSERT INTO [Congregations] ([Id], [Direction], [Name])
    VALUES (113, N'', N'Sotillo');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Direction', N'Name') AND [object_id] = OBJECT_ID(N'[Congregations]'))
        SET IDENTITY_INSERT [Congregations] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220725234906_New CCN')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220725234906_New CCN', N'3.1.17');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220726000553_New CCN 25 julio 2022 agregadas congregaciones')
BEGIN
    UPDATE [Congregations] SET [Name] = N'Curiepe'
    WHERE [Id] = 36;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220726000553_New CCN 25 julio 2022 agregadas congregaciones')
BEGIN
    UPDATE [Congregations] SET [Name] = N'San Juan de los Morros'
    WHERE [Id] = 39;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220726000553_New CCN 25 julio 2022 agregadas congregaciones')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Direction', N'Name') AND [object_id] = OBJECT_ID(N'[Congregations]'))
        SET IDENTITY_INSERT [Congregations] ON;
    INSERT INTO [Congregations] ([Id], [Direction], [Name])
    VALUES (114, N'', N'23 de enero'),
    (115, N'', N'Carayaca'),
    (116, N'', N'Caucaguita'),
    (117, N'', N'Santa Lucía'),
    (118, N'', N'Palo Negro'),
    (119, N'', N'Pijiguaos'),
    (120, N'', N'San felix');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Direction', N'Name') AND [object_id] = OBJECT_ID(N'[Congregations]'))
        SET IDENTITY_INSERT [Congregations] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220726000553_New CCN 25 julio 2022 agregadas congregaciones')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220726000553_New CCN 25 julio 2022 agregadas congregaciones', N'3.1.17');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220726022159_Fixed error another congregations')
BEGIN
    UPDATE [Congregations] SET [Direction] = N'', [Name] = N'Otra congregación'
    WHERE [Id] = 111;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220726022159_Fixed error another congregations')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220726022159_Fixed error another congregations', N'3.1.17');
END;

GO

