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

CREATE TABLE [Customers] (
    [Id] int NOT NULL,
    [PersonType] int NOT NULL,
    [TableNbr] nvarchar(max) NULL,
    [NbrInParty] int NOT NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Employees] (
    [Id] int NOT NULL,
    [FirstName] nvarchar(max) NULL,
    [LastName] nvarchar(max) NULL,
    [PrimaryPhone] nvarchar(max) NULL,
    [SecondaryPhone] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [EmployeeType] int NOT NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Events] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [StartDate] datetime2 NOT NULL,
    [EndDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Events] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [InventoryItems] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [condition] int NOT NULL,
    [Unit] int NOT NULL,
    [Quantity] int NOT NULL,
    [ReorderThreshold] int NOT NULL,
    [ReorderQuantity] int NOT NULL,
    [Yield] decimal(3,2) NOT NULL,
    [EqvCup] decimal(6,2) NOT NULL,
    [EqvPounds] decimal(6,2) NOT NULL,
    [EqvUnits] decimal(4,2) NOT NULL,
    CONSTRAINT [PK_InventoryItems] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [KindOfMenuItems] (
    [Id] int NOT NULL IDENTITY,
    CONSTRAINT [PK_KindOfMenuItems] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Orders] (
    [Id] int NOT NULL IDENTITY,
    [CustomerId] int NULL,
    [EmployerId] int NULL,
    [OrderStatus] int NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Orders_Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Orders_Employees_EmployerId] FOREIGN KEY ([EmployerId]) REFERENCES [Employees] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Menus] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [DefaultMenu] bit NOT NULL,
    [EventId] int NULL,
    CONSTRAINT [PK_Menus] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Menus_Events_EventId] FOREIGN KEY ([EventId]) REFERENCES [Events] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [OrderItems] (
    [Id] int NOT NULL IDENTITY,
    [OrderItemStatus] int NOT NULL,
    [OrderId] int NULL,
    [OrderItemType] nvarchar(max) NOT NULL,
    [RelatedId] int NULL,
    [OnTheSide] bit NULL,
    [AddToCost] bit NULL,
    [Quantity] int NULL,
    CONSTRAINT [PK_OrderItems] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_OrderItems_OrderItems_RelatedId] FOREIGN KEY ([RelatedId]) REFERENCES [OrderItems] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_OrderItems_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [MenuCategories] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    [Category] nvarchar(max) NULL,
    [MenuId] int NULL,
    CONSTRAINT [PK_MenuCategories] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_MenuCategories_Menus_MenuId] FOREIGN KEY ([MenuId]) REFERENCES [Menus] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [IngredientItems] (
    [Id] int NOT NULL IDENTITY,
    [InventoryItemId] int NULL,
    [Amount] decimal(4,2) NOT NULL,
    [Unit] int NOT NULL,
    [State] int NOT NULL,
    [InventoryUnitCount] decimal(3,2) NOT NULL,
    [Cost] float NOT NULL,
    [AlaCarteFoodItemId] int NULL,
    [BeverageFoodItemId] int NULL,
    CONSTRAINT [PK_IngredientItems] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_IngredientItems_InventoryItems_InventoryItemId] FOREIGN KEY ([InventoryItemId]) REFERENCES [InventoryItems] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [FoodItems] (
    [Id] int NOT NULL IDENTITY,
    [FoodItemType] nvarchar(max) NOT NULL,
    [IngredientItemId] int NULL,
    CONSTRAINT [PK_FoodItems] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_FoodItems_IngredientItems_IngredientItemId] FOREIGN KEY ([IngredientItemId]) REFERENCES [IngredientItems] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [MenuItems] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    [Category] nvarchar(max) NULL,
    [Cost] float NOT NULL,
    [FoodItemId] int NULL,
    [type] int NOT NULL,
    [MenuCategoryId] int NULL,
    CONSTRAINT [PK_MenuItems] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_MenuItems_FoodItems_FoodItemId] FOREIGN KEY ([FoodItemId]) REFERENCES [FoodItems] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_MenuItems_MenuCategories_MenuCategoryId] FOREIGN KEY ([MenuCategoryId]) REFERENCES [MenuCategories] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [OptionalMenuItems] (
    [Id] int NOT NULL IDENTITY,
    [MenuCategoryId] int NULL,
    [MenuItemId] int NULL,
    CONSTRAINT [PK_OptionalMenuItems] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_OptionalMenuItems_MenuCategories_MenuCategoryId] FOREIGN KEY ([MenuCategoryId]) REFERENCES [MenuCategories] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_OptionalMenuItems_MenuItems_MenuItemId] FOREIGN KEY ([MenuItemId]) REFERENCES [MenuItems] ([Id]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_FoodItems_IngredientItemId] ON [FoodItems] ([IngredientItemId]);
GO

CREATE INDEX [IX_IngredientItems_AlaCarteFoodItemId] ON [IngredientItems] ([AlaCarteFoodItemId]);
GO

CREATE INDEX [IX_IngredientItems_BeverageFoodItemId] ON [IngredientItems] ([BeverageFoodItemId]);
GO

CREATE INDEX [IX_IngredientItems_InventoryItemId] ON [IngredientItems] ([InventoryItemId]);
GO

CREATE INDEX [IX_MenuCategories_MenuId] ON [MenuCategories] ([MenuId]);
GO

CREATE INDEX [IX_MenuItems_FoodItemId] ON [MenuItems] ([FoodItemId]);
GO

CREATE INDEX [IX_MenuItems_MenuCategoryId] ON [MenuItems] ([MenuCategoryId]);
GO

CREATE INDEX [IX_Menus_EventId] ON [Menus] ([EventId]);
GO

CREATE INDEX [IX_OptionalMenuItems_MenuCategoryId] ON [OptionalMenuItems] ([MenuCategoryId]);
GO

CREATE INDEX [IX_OptionalMenuItems_MenuItemId] ON [OptionalMenuItems] ([MenuItemId]);
GO

CREATE INDEX [IX_OrderItems_OrderId] ON [OrderItems] ([OrderId]);
GO

CREATE INDEX [IX_OrderItems_RelatedId] ON [OrderItems] ([RelatedId]);
GO

CREATE INDEX [IX_Orders_CustomerId] ON [Orders] ([CustomerId]);
GO

CREATE INDEX [IX_Orders_EmployerId] ON [Orders] ([EmployerId]);
GO

ALTER TABLE [IngredientItems] ADD CONSTRAINT [FK_IngredientItems_FoodItems_AlaCarteFoodItemId] FOREIGN KEY ([AlaCarteFoodItemId]) REFERENCES [FoodItems] ([Id]) ON DELETE NO ACTION;
GO

ALTER TABLE [IngredientItems] ADD CONSTRAINT [FK_IngredientItems_FoodItems_BeverageFoodItemId] FOREIGN KEY ([BeverageFoodItemId]) REFERENCES [FoodItems] ([Id]) ON DELETE NO ACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210621192258_RecipeAPI1.Models.RecipeContext', N'5.0.7');
GO

COMMIT;
GO

