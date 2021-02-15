ALTER TABLE [Users] DROP CONSTRAINT [FK_Users_Companies_CompanyName];

GO

ALTER TABLE [Users] ADD CONSTRAINT [FK_Users_Companies_CompanyName] FOREIGN KEY ([CompanyName]) REFERENCES [Companies] ([Name]) ON DELETE SET NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200602154836_Set_CASCADE_SetNull', N'3.1.4');

GO

