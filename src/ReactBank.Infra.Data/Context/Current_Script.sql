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
    [AccountId] uniqueidentifier NOT NULL,
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

CREATE UNIQUE INDEX [IX_Account_CustomerId] ON [Account] ([CustomerId]);
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
VALUES (N'20241023222719_InitialMigration', N'8.0.10');
GO

COMMIT;
GO

