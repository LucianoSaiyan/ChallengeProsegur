CREATE TABLE [dbo].[ItemPedido] (
    [Id]                INT             IDENTITY (1, 1) NOT NULL,
    [NombreProducto]    NVARCHAR (MAX)  NOT NULL,
    [Descripcion]       NVARCHAR (MAX)  NOT NULL,
    [Cantidad]          INT             NOT NULL,
    [TiempoRealizacion] INT             NOT NULL,
    [Precio]            DECIMAL (18, 2) NOT NULL,
    [Impuestos]         DECIMAL (18, 2) NOT NULL,
    [PedidoId]          INT             NOT NULL,
    [ProductoId]        INT             NOT NULL,
    CONSTRAINT [PK_ItemPedido] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ItemPedido_Pedido_PedidoId] FOREIGN KEY ([PedidoId]) REFERENCES [dbo].[Pedido] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ItemPedido_Productos_ProductoId] FOREIGN KEY ([ProductoId]) REFERENCES [dbo].[Productos] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_ItemPedido_ProductoId]
    ON [dbo].[ItemPedido]([ProductoId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ItemPedido_PedidoId]
    ON [dbo].[ItemPedido]([PedidoId] ASC);

