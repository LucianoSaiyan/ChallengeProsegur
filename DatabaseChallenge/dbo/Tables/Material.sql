CREATE TABLE [dbo].[Material] (
    [Id]                 INT            IDENTITY (1, 1) NOT NULL,
    [Nombre]             NVARCHAR (MAX) NOT NULL,
    [CantidadDisponible] INT            NOT NULL,
    [ProductoId]         INT            NOT NULL,
    CONSTRAINT [PK_Material] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Material_Productos_ProductoId] FOREIGN KEY ([ProductoId]) REFERENCES [dbo].[Productos] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Material_ProductoId]
    ON [dbo].[Material]([ProductoId] ASC);

