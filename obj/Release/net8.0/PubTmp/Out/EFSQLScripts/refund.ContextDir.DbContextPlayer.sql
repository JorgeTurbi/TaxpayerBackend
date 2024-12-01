IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240927005943_InitialsCreated'
)
BEGIN
    CREATE TABLE [FilingStatus] (
        [IdFilingStatus] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Created_On] datetime2 NOT NULL,
        CONSTRAINT [PK_FilingStatus] PRIMARY KEY ([IdFilingStatus])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240927005943_InitialsCreated'
)
BEGIN
    CREATE TABLE [IncomeType] (
        [IncometypeId] int NOT NULL IDENTITY,
        [Nameincometype] nvarchar(max) NOT NULL,
        [Created_On] datetime2 NOT NULL,
        CONSTRAINT [PK_IncomeType] PRIMARY KEY ([IncometypeId])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240927005943_InitialsCreated'
)
BEGIN
    CREATE TABLE [State] (
        [StateId] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_State] PRIMARY KEY ([StateId])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240927005943_InitialsCreated'
)
BEGIN
    CREATE TABLE [TaxPreparer] (
        [TaxPreparerId] int NOT NULL IDENTITY,
        [Username] nvarchar(max) NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [Brand] nvarchar(max) NULL,
        [Address] nvarchar(max) NULL,
        [Phone] nvarchar(max) NULL,
        [Created_On] datetime2 NOT NULL,
        [Updated_On] datetime2 NULL,
        CONSTRAINT [PK_TaxPreparer] PRIMARY KEY ([TaxPreparerId])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240927005943_InitialsCreated'
)
BEGIN
    CREATE TABLE [City] (
        [CityId] int NOT NULL IDENTITY,
        [StateId] int NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_City] PRIMARY KEY ([CityId]),
        CONSTRAINT [FK_City_State_StateId] FOREIGN KEY ([StateId]) REFERENCES [State] ([StateId])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240927005943_InitialsCreated'
)
BEGIN
    CREATE TABLE [TaxPlayer] (
        [TaxplayerId] int NOT NULL IDENTITY,
        [IdFilingStatus] int NOT NULL,
        [TaxPreparerId] int NULL,
        [FirstName] nvarchar(max) NOT NULL,
        [LastName] nvarchar(max) NOT NULL,
        [Datebirth] datetime2 NOT NULL,
        [SocialSecurity] nvarchar(9) NOT NULL,
        [Phone] nvarchar(max) NULL,
        [Email] nvarchar(max) NULL,
        [IncometypeId] int NOT NULL,
        [WagesIncome] decimal(18,2) NULL,
        [FederalIncomeTaxWithheld] decimal(18,2) NULL,
        [SelfEmploymentCompensation] decimal(18,2) NULL,
        [YTDEarnings] decimal(18,2) NULL,
        [YTDFederalWithholding] decimal(18,2) NULL,
        [IsActive] bit NOT NULL,
        [Created_On] datetime2 NOT NULL,
        [FilingStatusIdFilingStatus] int NOT NULL,
        CONSTRAINT [PK_TaxPlayer] PRIMARY KEY ([TaxplayerId]),
        CONSTRAINT [FK_TaxPlayer_FilingStatus_FilingStatusIdFilingStatus] FOREIGN KEY ([FilingStatusIdFilingStatus]) REFERENCES [FilingStatus] ([IdFilingStatus]) ON DELETE CASCADE,
        CONSTRAINT [FK_TaxPlayer_IncomeType_IncometypeId] FOREIGN KEY ([IncometypeId]) REFERENCES [IncomeType] ([IncometypeId]) ON DELETE CASCADE,
        CONSTRAINT [FK_TaxPlayer_TaxPreparer_TaxPreparerId] FOREIGN KEY ([TaxPreparerId]) REFERENCES [TaxPreparer] ([TaxPreparerId])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240927005943_InitialsCreated'
)
BEGIN
    CREATE TABLE [Address] (
        [IdAddress] int NOT NULL IDENTITY,
        [TaxplayerId] int NOT NULL,
        [StreetAddress] nvarchar(max) NULL,
        [CityId] int NULL,
        [StateId] int NULL,
        [ZipCode] nvarchar(max) NULL,
        [Created_On] datetime2 NOT NULL,
        CONSTRAINT [PK_Address] PRIMARY KEY ([IdAddress]),
        CONSTRAINT [FK_Address_City_CityId] FOREIGN KEY ([CityId]) REFERENCES [City] ([CityId]),
        CONSTRAINT [FK_Address_State_StateId] FOREIGN KEY ([StateId]) REFERENCES [State] ([StateId]),
        CONSTRAINT [FK_Address_TaxPlayer_TaxplayerId] FOREIGN KEY ([TaxplayerId]) REFERENCES [TaxPlayer] ([TaxplayerId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240927005943_InitialsCreated'
)
BEGIN
    CREATE TABLE [Dependents] (
        [DependentsId] int NOT NULL IDENTITY,
        [TaxplayerId] int NOT NULL,
        [Total] int NOT NULL,
        [Datebirth] datetime2 NOT NULL,
        [Created_On] datetime2 NOT NULL,
        CONSTRAINT [PK_Dependents] PRIMARY KEY ([DependentsId]),
        CONSTRAINT [FK_Dependents_TaxPlayer_TaxplayerId] FOREIGN KEY ([TaxplayerId]) REFERENCES [TaxPlayer] ([TaxplayerId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240927005943_InitialsCreated'
)
BEGIN
    CREATE TABLE [Spouse] (
        [SpouseId] int NOT NULL IDENTITY,
        [TaxplayerId] int NOT NULL,
        [SpouseFirstName] nvarchar(max) NOT NULL,
        [SpouseLastName] nvarchar(max) NOT NULL,
        [SpouseDatebirth] datetime2 NOT NULL,
        [SpouseSocialSecurity] nvarchar(9) NOT NULL,
        [SpousePhone] nvarchar(max) NULL,
        [SpouseEmail] nvarchar(max) NULL,
        [IncometypeId] int NOT NULL,
        [SpouseWagesIncome] decimal(18,2) NULL,
        [SpouseFederalIncomeTaxWithheld] decimal(18,2) NULL,
        [SpouseSelfEmploymentCompensation] decimal(18,2) NULL,
        [SpouseYTDEarnings] decimal(18,2) NULL,
        [SpouseYTDFederalWithholding] decimal(18,2) NULL,
        CONSTRAINT [PK_Spouse] PRIMARY KEY ([SpouseId]),
        CONSTRAINT [FK_Spouse_IncomeType_IncometypeId] FOREIGN KEY ([IncometypeId]) REFERENCES [IncomeType] ([IncometypeId]) ON DELETE CASCADE,
        CONSTRAINT [FK_Spouse_TaxPlayer_TaxplayerId] FOREIGN KEY ([TaxplayerId]) REFERENCES [TaxPlayer] ([TaxplayerId])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240927005943_InitialsCreated'
)
BEGIN
    CREATE INDEX [IX_Address_CityId] ON [Address] ([CityId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240927005943_InitialsCreated'
)
BEGIN
    CREATE INDEX [IX_Address_StateId] ON [Address] ([StateId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240927005943_InitialsCreated'
)
BEGIN
    CREATE UNIQUE INDEX [IX_Address_TaxplayerId] ON [Address] ([TaxplayerId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240927005943_InitialsCreated'
)
BEGIN
    CREATE INDEX [IX_City_StateId] ON [City] ([StateId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240927005943_InitialsCreated'
)
BEGIN
    CREATE INDEX [IX_Dependents_TaxplayerId] ON [Dependents] ([TaxplayerId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240927005943_InitialsCreated'
)
BEGIN
    CREATE INDEX [IX_Spouse_IncometypeId] ON [Spouse] ([IncometypeId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240927005943_InitialsCreated'
)
BEGIN
    CREATE UNIQUE INDEX [IX_Spouse_TaxplayerId] ON [Spouse] ([TaxplayerId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240927005943_InitialsCreated'
)
BEGIN
    CREATE INDEX [IX_TaxPlayer_FilingStatusIdFilingStatus] ON [TaxPlayer] ([FilingStatusIdFilingStatus]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240927005943_InitialsCreated'
)
BEGIN
    CREATE INDEX [IX_TaxPlayer_IncometypeId] ON [TaxPlayer] ([IncometypeId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240927005943_InitialsCreated'
)
BEGIN
    CREATE INDEX [IX_TaxPlayer_TaxPreparerId] ON [TaxPlayer] ([TaxPreparerId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240927005943_InitialsCreated'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240927005943_InitialsCreated', N'8.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241002142824_ClientsCreated'
)
BEGIN
    EXEC sp_rename N'[Spouse].[SpouseYTDFederalWithholding]', N'SpouseYtdIncome', N'COLUMN';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241002142824_ClientsCreated'
)
BEGIN
    EXEC sp_rename N'[Spouse].[SpouseYTDEarnings]', N'SpouseYtdFederal', N'COLUMN';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241002142824_ClientsCreated'
)
BEGIN
    EXEC sp_rename N'[Spouse].[SpouseWagesIncome]', N'SpouseWagesFederal', N'COLUMN';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241002142824_ClientsCreated'
)
BEGIN
    EXEC sp_rename N'[Spouse].[SpouseSelfEmploymentCompensation]', N'SpouseSelfEmploymentComp', N'COLUMN';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241002142824_ClientsCreated'
)
BEGIN
    EXEC sp_rename N'[Spouse].[SpouseFederalIncomeTaxWithheld]', N'SpouseGrossIncome', N'COLUMN';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241002142824_ClientsCreated'
)
BEGIN
    CREATE TABLE [AddressDto] (
        [IdAddress] int NOT NULL IDENTITY,
        [StreetAddress] nvarchar(max) NOT NULL,
        [City] nvarchar(max) NOT NULL,
        [State] nvarchar(max) NOT NULL,
        [Zip] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_AddressDto] PRIMARY KEY ([IdAddress])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241002142824_ClientsCreated'
)
BEGIN
    CREATE TABLE [SpousesDto] (
        [SpouseId] int NOT NULL IDENTITY,
        [SpouseFirstName] nvarchar(max) NOT NULL,
        [SpouseLastName] nvarchar(max) NOT NULL,
        [SpouseDob] nvarchar(max) NOT NULL,
        [SpouseAge] int NOT NULL,
        [SpouseSsn] nvarchar(max) NOT NULL,
        [SpouseIncomeType] nvarchar(max) NOT NULL,
        [SpouseGrossIncome] decimal(18,2) NOT NULL,
        [SpouseSelfEmploymentComp] decimal(18,2) NOT NULL,
        [SpouseYtdIncome] decimal(18,2) NOT NULL,
        [SpouseWagesFederal] decimal(18,2) NOT NULL,
        [SpouseYtdFederal] decimal(18,2) NOT NULL,
        CONSTRAINT [PK_SpousesDto] PRIMARY KEY ([SpouseId])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241002142824_ClientsCreated'
)
BEGIN
    CREATE TABLE [Client] (
        [ClientId] int NOT NULL IDENTITY,
        [FilingStatus] nvarchar(max) NULL,
        [FirstName] nvarchar(max) NULL,
        [LastName] nvarchar(max) NULL,
        [Dob] nvarchar(max) NULL,
        [Ssn] nvarchar(max) NULL,
        [StreetAddressIdAddress] int NULL,
        [PrimaryIncomeType] nvarchar(max) NULL,
        [PrimaryGrossIncome] decimal(18,2) NULL,
        [PrimarySelfEmploymentComp] decimal(18,2) NULL,
        [PrimaryYtdIncome] decimal(18,2) NULL,
        [PrimaryWagesFederal] decimal(18,2) NULL,
        [PrimaryYtdFederal] decimal(18,2) NULL,
        [SpousesSpouseId] int NULL,
        [GrossIncome] decimal(18,2) NULL,
        [FederalTaxWithheld] decimal(18,2) NULL,
        [StandardDeduction] decimal(18,2) NULL,
        [EstimatedTaxDue] decimal(18,2) NULL,
        [TaxableIncome] decimal(18,2) NULL,
        [SelfEmploymentTax] decimal(18,2) NULL,
        [ChildTaxCredit] decimal(18,2) NULL,
        [AdditionalChildTaxCredit] decimal(18,2) NULL,
        [EarnedIncomeTaxCredit] decimal(18,2) NULL,
        [RefundAmount] decimal(18,2) NULL,
        CONSTRAINT [PK_Client] PRIMARY KEY ([ClientId]),
        CONSTRAINT [FK_Client_AddressDto_StreetAddressIdAddress] FOREIGN KEY ([StreetAddressIdAddress]) REFERENCES [AddressDto] ([IdAddress]),
        CONSTRAINT [FK_Client_SpousesDto_SpousesSpouseId] FOREIGN KEY ([SpousesSpouseId]) REFERENCES [SpousesDto] ([SpouseId])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241002142824_ClientsCreated'
)
BEGIN
    CREATE INDEX [IX_Client_SpousesSpouseId] ON [Client] ([SpousesSpouseId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241002142824_ClientsCreated'
)
BEGIN
    CREATE INDEX [IX_Client_StreetAddressIdAddress] ON [Client] ([StreetAddressIdAddress]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241002142824_ClientsCreated'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241002142824_ClientsCreated', N'8.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241021223520_PeriodNoteField'
)
BEGIN
    ALTER TABLE [TaxPreparer] ADD [PeriodNote] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241021223520_PeriodNoteField'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241021223520_PeriodNoteField', N'8.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241021224237_PeriodNoteFieldupdated'
)
BEGIN
    EXEC sp_rename N'[TaxPreparer].[PeriodNote]', N'Messages', N'COLUMN';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241021224237_PeriodNoteFieldupdated'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241021224237_PeriodNoteFieldupdated', N'8.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241027232345_DataLogin'
)
BEGIN
    CREATE TABLE [User] (
        [UserId] int NOT NULL IDENTITY,
        [Username] nvarchar(max) NOT NULL,
        [Code] nvarchar(max) NOT NULL,
        [Lastlogin] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_User] PRIMARY KEY ([UserId])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241027232345_DataLogin'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241027232345_DataLogin', N'8.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241031210231_Addzipcode'
)
BEGIN
    ALTER TABLE [TaxPreparer] ADD [Zipcode] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241031210231_Addzipcode'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241031210231_Addzipcode', N'8.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241101013510_FieldsRange'
)
BEGIN
    ALTER TABLE [State] ADD [Range_End] bigint NOT NULL DEFAULT CAST(0 AS bigint);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241101013510_FieldsRange'
)
BEGIN
    ALTER TABLE [State] ADD [Range_Start] bigint NOT NULL DEFAULT CAST(0 AS bigint);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241101013510_FieldsRange'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241101013510_FieldsRange', N'8.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241102195242_QuestionsSecurity'
)
BEGIN
    CREATE TABLE [SecurityQuestions] (
        [QuestionID] int NOT NULL IDENTITY,
        [QuestionText] nvarchar(max) NULL,
        CONSTRAINT [PK_SecurityQuestions] PRIMARY KEY ([QuestionID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241102195242_QuestionsSecurity'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'QuestionID', N'QuestionText') AND [object_id] = OBJECT_ID(N'[SecurityQuestions]'))
        SET IDENTITY_INSERT [SecurityQuestions] ON;
    EXEC(N'INSERT INTO [SecurityQuestions] ([QuestionID], [QuestionText])
    VALUES (1, N''What is the name of your first best friend?''),
    (2, N''What is the name of the street you grew up on?''),
    (3, N''What was the name of your first pet?''),
    (4, N''What was your grandparent’s nickname?''),
    (5, N''In what city were you born?''),
    (6, N''What was the first concert you attended?''),
    (7, N''What was your favorite childhood food?''),
    (8, N''What was the name of your favorite elementary school teacher?''),
    (9, N''Where did you spend your first vacation?''),
    (10, N''What is the title of your all-time favorite movie?'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'QuestionID', N'QuestionText') AND [object_id] = OBJECT_ID(N'[SecurityQuestions]'))
        SET IDENTITY_INSERT [SecurityQuestions] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241102195242_QuestionsSecurity'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241102195242_QuestionsSecurity', N'8.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241102233701_AddQuestionSecuritytoTableUser'
)
BEGIN
    ALTER TABLE [User] ADD [Question] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241102233701_AddQuestionSecuritytoTableUser'
)
BEGIN
    ALTER TABLE [User] ADD [Response] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241102233701_AddQuestionSecuritytoTableUser'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241102233701_AddQuestionSecuritytoTableUser', N'8.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241103001235_AddQuestionSecuritytoTableUser2'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241103001235_AddQuestionSecuritytoTableUser2', N'8.0.8');
END;
GO

COMMIT;
GO

