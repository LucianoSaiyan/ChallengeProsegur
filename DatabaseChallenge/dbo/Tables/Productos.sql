CREATE TABLE [dbo].[Productos] (
    [Id]                INT             IDENTITY (1, 1) NOT NULL,
    [Nombre]            NVARCHAR (MAX)  NOT NULL,
    [Descripcion]       NVARCHAR (MAX)  NOT NULL,
    [TiempoRealizacion] INT             NOT NULL,
    [PrecioBase]        DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED ([Id] ASC)
);

