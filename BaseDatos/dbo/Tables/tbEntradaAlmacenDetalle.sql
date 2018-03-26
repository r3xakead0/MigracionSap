CREATE TABLE [dbo].[tbEntradaAlmacenDetalle] (
    [idEntradaAlmacenDetalle] INT             IDENTITY (1, 1) NOT NULL,
    [idEntradaAlmacen]        INT             NOT NULL,
    [nroLinea]                INT             NOT NULL,
    [codArticulo]             VARCHAR (20)    NOT NULL,
    [dscArticulo]             VARCHAR (100)   NOT NULL,
    [cantidad]                DECIMAL (19, 6) NOT NULL,
    [codAlmacen]              VARCHAR (10)    NULL,
    [codImpuesto]             VARCHAR (10)    NULL,
    [nroCuentaContable]       VARCHAR (15)    NULL,
    [codProyecto]             VARCHAR (10)    NULL,
    [codCentroCosto]          VARCHAR (10)    NULL,
    CONSTRAINT [PK_tbEntradaAlmacenDetalle_1] PRIMARY KEY CLUSTERED ([idEntradaAlmacenDetalle] ASC),
    CONSTRAINT [FK_tbEntradaAlmacenDetalle_tbEntradaAlmacen] FOREIGN KEY ([idEntradaAlmacen]) REFERENCES [dbo].[tbEntradaAlmacen] ([idEntradaAlmacen])
);

