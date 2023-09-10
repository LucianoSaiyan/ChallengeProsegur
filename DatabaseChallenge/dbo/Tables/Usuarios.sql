CREATE TABLE [dbo].[Usuarios] (
    [Id]                  INT            IDENTITY (1, 1) NOT NULL,
    [Nombre]              NVARCHAR (MAX) NOT NULL,
    [InformacionContacto] NVARCHAR (MAX) NOT NULL,
    [Direccion]           NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED ([Id] ASC)
);

