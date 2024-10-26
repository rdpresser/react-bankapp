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

CREATE TABLE [Customer] (
    [Id] uniqueidentifier NOT NULL,
    [Name] varchar(2000) NOT NULL,
    [Email] varchar(2000) NOT NULL,
    [Phone] varchar(2000) NOT NULL,
    [StreetAddress] varchar(2000) NOT NULL,
    [City] varchar(2000) NULL,
    [State] varchar(2000) NULL,
    [ZipCode] varchar(2000) NOT NULL,
    [DateOfBirth] datetime2 NOT NULL,
    [IdentityDocument] varchar(2000) NOT NULL,
    [IsActive] bit NOT NULL,
    CONSTRAINT [PK_Customer] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Account] (
    [Id] uniqueidentifier NOT NULL,
    [AccountNumber] varchar(2000) NOT NULL,
    [Balance] decimal(18,2) NOT NULL,
    [Currency] varchar(2000) NOT NULL,
    [AccountType] varchar(2000) NOT NULL,
    [IsActive] bit NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [CustomerId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Account] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Account_Customer_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customer] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Loan] (
    [Id] uniqueidentifier NOT NULL,
    [Amount] decimal(18,2) NOT NULL,
    [InterestRate] decimal(18,2) NOT NULL,
    [StartDate] datetime2 NOT NULL,
    [EndDate] datetime2 NOT NULL,
    [AccountId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Loan] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Loan_Account_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [Account] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Transaction] (
    [Id] uniqueidentifier NOT NULL,
    [TransactionType] varchar(2000) NOT NULL,
    [Amount] decimal(18,2) NOT NULL,
    [Currency] varchar(2000) NOT NULL,
    [DateTime] datetime2 NOT NULL,
    [SourceAccountId] uniqueidentifier NOT NULL,
    [DestinationAccountId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Transaction] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Transaction_Account_DestinationAccountId] FOREIGN KEY ([DestinationAccountId]) REFERENCES [Account] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Transaction_Account_SourceAccountId] FOREIGN KEY ([SourceAccountId]) REFERENCES [Account] ([Id]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_Account_AccountNumber] ON [Account] ([AccountNumber]);
GO

CREATE INDEX [IX_Account_CreatedAt] ON [Account] ([CreatedAt]);
GO

CREATE INDEX [IX_Account_CustomerId] ON [Account] ([CustomerId]);
GO

CREATE INDEX [IX_Customer_Email] ON [Customer] ([Email]);
GO

CREATE INDEX [IX_Customer_Name] ON [Customer] ([Name]);
GO

CREATE INDEX [IX_Loan_AccountId] ON [Loan] ([AccountId]);
GO

CREATE INDEX [IX_Transaction_DateTime] ON [Transaction] ([DateTime]);
GO

CREATE INDEX [IX_Transaction_DestinationAccountId] ON [Transaction] ([DestinationAccountId]);
GO

CREATE INDEX [IX_Transaction_SourceAccountId] ON [Transaction] ([SourceAccountId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241025122501_InitialMigration', N'8.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Account]') AND [c].[name] = N'AccountType');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Account] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Account] ALTER COLUMN [AccountType] varchar(100) NOT NULL;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'City', N'DateOfBirth', N'Email', N'IdentityDocument', N'IsActive', N'Name', N'Phone', N'State', N'StreetAddress', N'ZipCode') AND [object_id] = OBJECT_ID(N'[Customer]'))
    SET IDENTITY_INSERT [Customer] ON;
INSERT INTO [Customer] ([Id], [City], [DateOfBirth], [Email], [IdentityDocument], [IsActive], [Name], [Phone], [State], [StreetAddress], [ZipCode])
VALUES ('849b24e4-f29a-4fb4-91b7-7a9b65795bf6', 'New York', '1980-01-01T00:00:00.0000000', 'john.doe@gmail.com', '123456789', CAST(1 AS bit), 'John Doe', '123456789', 'NY', '123 Main St', '12345'),
('888b24e4-f29a-4fb4-91b7-7a9b65795bf6', 'New York', '1995-01-02T00:00:00.0000000', 'son.doe@gmail.com', '823456789', CAST(0 AS bit), 'Son Doe', '823456789', 'NY', '125 Main St', '12347'),
('889b24e4-f29a-4fb4-91b7-7a9b65795bf6', 'New York', '1980-01-02T00:00:00.0000000', 'mary.doe@gmail.com', '923456789', CAST(1 AS bit), 'Mary Doe', '923456789', 'NY', '124 Main St', '12346');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'City', N'DateOfBirth', N'Email', N'IdentityDocument', N'IsActive', N'Name', N'Phone', N'State', N'StreetAddress', N'ZipCode') AND [object_id] = OBJECT_ID(N'[Customer]'))
    SET IDENTITY_INSERT [Customer] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccountNumber', N'AccountType', N'Balance', N'CreatedAt', N'Currency', N'CustomerId', N'IsActive') AND [object_id] = OBJECT_ID(N'[Account]'))
    SET IDENTITY_INSERT [Account] ON;
INSERT INTO [Account] ([Id], [AccountNumber], [AccountType], [Balance], [CreatedAt], [Currency], [CustomerId], [IsActive])
VALUES ('ba669725-8233-434a-9b1e-751dd752e419', '123456789', 'CheckingAccount', 1000.0, '2021-01-01T00:00:00.0000000', 'US$', '849b24e4-f29a-4fb4-91b7-7a9b65795bf6', CAST(1 AS bit)),
('ba769725-8233-434a-9b1e-751dd752e419', '923456789', 'SavingsAccount', 900.0, '2020-02-02T00:00:00.0000000', 'US$', '889b24e4-f29a-4fb4-91b7-7a9b65795bf6', CAST(1 AS bit)),
('ba869725-8233-434a-9b1e-751dd752e419', '823456789', 'StudentAccount', 850.0, '2023-03-03T00:00:00.0000000', 'US$', '888b24e4-f29a-4fb4-91b7-7a9b65795bf6', CAST(0 AS bit));
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccountNumber', N'AccountType', N'Balance', N'CreatedAt', N'Currency', N'CustomerId', N'IsActive') AND [object_id] = OBJECT_ID(N'[Account]'))
    SET IDENTITY_INSERT [Account] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241026195453_SeedDataBase', N'8.0.10');
GO

COMMIT;
GO

