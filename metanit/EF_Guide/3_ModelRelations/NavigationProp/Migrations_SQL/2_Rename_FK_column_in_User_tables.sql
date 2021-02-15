ALTER TABLE [Users] DROP CONSTRAINT [FK_Users_Companies_CompanyId];

GO

DROP INDEX [IX_Users_CompanyId] ON [Users];

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'CompanyId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Users] DROP COLUMN [CompanyId];

GO

ALTER TABLE [Users] ADD [CompanyInfoKey] int NOT NULL DEFAULT 0;

GO

UPDATE [Users] SET [CompanyInfoKey] = 1
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


GO

UPDATE [Users] SET [CompanyInfoKey] = 1
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


GO

UPDATE [Users] SET [CompanyInfoKey] = 2
WHERE [Id] = 3;
SELECT @@ROWCOUNT;


GO

CREATE INDEX [IX_Users_CompanyInfoKey] ON [Users] ([CompanyInfoKey]);

GO

ALTER TABLE [Users] ADD CONSTRAINT [FK_Users_Companies_CompanyInfoKey] FOREIGN KEY ([CompanyInfoKey]) REFERENCES [Companies] ([Id]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200602145032_Rename_FK_column_in_User_tables', N'3.1.4');

GO

