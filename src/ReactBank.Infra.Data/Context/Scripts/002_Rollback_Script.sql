BEGIN TRANSACTION;
GO

DELETE FROM [Account]
WHERE [Id] = 'ba669725-8233-434a-9b1e-751dd752e419';
SELECT @@ROWCOUNT;

GO

DELETE FROM [Account]
WHERE [Id] = 'ba769725-8233-434a-9b1e-751dd752e419';
SELECT @@ROWCOUNT;

GO

DELETE FROM [Account]
WHERE [Id] = 'ba869725-8233-434a-9b1e-751dd752e419';
SELECT @@ROWCOUNT;

GO

DELETE FROM [Customer]
WHERE [Id] = '849b24e4-f29a-4fb4-91b7-7a9b65795bf6';
SELECT @@ROWCOUNT;

GO

DELETE FROM [Customer]
WHERE [Id] = '888b24e4-f29a-4fb4-91b7-7a9b65795bf6';
SELECT @@ROWCOUNT;

GO

DELETE FROM [Customer]
WHERE [Id] = '889b24e4-f29a-4fb4-91b7-7a9b65795bf6';
SELECT @@ROWCOUNT;

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Account]') AND [c].[name] = N'AccountType');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Account] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Account] ALTER COLUMN [AccountType] varchar(2000) NOT NULL;
GO

DELETE FROM [__EFMigrationsHistory]
WHERE [MigrationId] = N'20241026195453_SeedDataBase';
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DROP TABLE [Loan];
GO

DROP TABLE [Transaction];
GO

DROP TABLE [Account];
GO

DROP TABLE [Customer];
GO

DELETE FROM [__EFMigrationsHistory]
WHERE [MigrationId] = N'20241025122501_InitialMigration';
GO

COMMIT;
GO

