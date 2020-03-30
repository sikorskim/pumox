CREATE TABLE [Companies] (
    [Id] bigint NOT NULL IDENTITY,
    [EstablishmentYear] int NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Companies] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Employees] (
    [Id] bigint NOT NULL IDENTITY,
    [FirstName] nvarchar(max) NULL,
    [LastName] nvarchar(max) NULL,
    [DateOfBirth] datetime2 NOT NULL,
    [JobTitle] int NOT NULL,
    [CompanyId] bigint NOT NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Employees_Companies_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [Companies] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Employees_CompanyId] ON [Employees] ([CompanyId]);