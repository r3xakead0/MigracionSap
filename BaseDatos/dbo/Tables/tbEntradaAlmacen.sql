CREATE TABLE [dbo].[tbEntradaAlmacen] (
    [idEntradaAlmacen] INT             IDENTITY (1, 1) NOT NULL,
    [serie]            VARCHAR (10)    NOT NULL,
    [fechaContable]    DATETIME        NOT NULL,
    [comentario]       VARCHAR (255)   NOT NULL,
    [fechaCreacion]    DATETIME        NOT NULL,
    [total]            DECIMAL (19, 6) NOT NULL,
    [usuario]          VARCHAR (20)    NOT NULL,
    CONSTRAINT [PK_tbEntradaAlmacen] PRIMARY KEY CLUSTERED ([idEntradaAlmacen] ASC)
);

