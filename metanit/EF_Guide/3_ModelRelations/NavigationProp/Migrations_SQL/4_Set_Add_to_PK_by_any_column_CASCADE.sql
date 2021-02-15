ALTER TABLE [Users] DROP CONSTRAINT [FK_Users_Companies_CompanyName];

GO

ALTER TABLE [Users] ADD CONSTRAINT [FK_Users_Companies_CompanyName] FOREIGN KEY ([CompanyName]) REFERENCES [Companies] ([Name]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200602152849_Set_Add_to_PK_by_any_column_CASCADE', N'3.1.4');

GO

