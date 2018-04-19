CREATE TABLE [dbo].[tbTipoDocumento] (
    [idTipoDocumento] INT           IDENTITY (1, 1) NOT NULL,
    [idObjectoSap]    INT           NOT NULL,
    [nombre]          VARCHAR (50)  NOT NULL,
    [descripcion]     VARCHAR (255) NOT NULL,
    CONSTRAINT [PK_tbTipoDocumento] PRIMARY KEY CLUSTERED ([idTipoDocumento] ASC)
);

