CREATE TABLE [dbo].[Pedido] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [FechaCreacion] DATETIME2 (7)  NOT NULL,
    [Estado]        NVARCHAR (MAX) NOT NULL,
    [UsuarioId]     INT            NOT NULL,
    CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Pedido_Usuarios_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [dbo].[Usuarios] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Pedido_UsuarioId]
    ON [dbo].[Pedido]([UsuarioId] ASC);

