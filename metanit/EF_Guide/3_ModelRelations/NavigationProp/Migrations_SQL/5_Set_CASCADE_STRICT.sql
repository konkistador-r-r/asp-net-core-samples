ALTER TABLE [Users] DROP CONSTRAINT [FK_Users_Companies_CompanyName];

GO

ALTER TABLE [Users] ADD CONSTRAINT [FK_Users_Companies_CompanyName] FOREIGN KEY ([CompanyName]) REFERENCES [Companies] ([Name]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200602154606_Set_CASCADE_STRICT', N'3.1.4');

GO

