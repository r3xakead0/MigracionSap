CREATE TABLE [dbo].[tbSalidaAlmacenDetalle] (
    [idSalidaAlmacenDetalle] INT             IDENTITY (1, 1) NOT NULL,
    [idSalidaAlmacen]        INT             NOT NULL,
    [nroLinea]               INT             NOT NULL,
    [codArticulo]            VARCHAR (20)    NOT NULL,
    [dscArticulo]            VARCHAR (100)   NOT NULL,
    [cantidad]               DECIMAL (19, 6) NOT NULL,
    [codAlmacen]             VARCHAR (10)    NULL,
    [codImpuesto]            VARCHAR (10)    NULL,
    [nroCuentaContable]      VARCHAR (15)    NULL,
    [codProyecto]            VARCHAR (10)    NULL,
    [codCentroCosto]         VARCHAR (10)    NULL,
    CONSTRAINT [PK_tbSalidaAlmacenDetalle_1] PRIMARY KEY CLUSTERED ([idSalidaAlmacenDetalle] ASC),
    CONSTRAINT [FK_tbSalidaAlmacenDetalle_tbSalidaAlmacen] FOREIGN KEY ([idSalidaAlmacen]) REFERENCES [dbo].[tbSalidaAlmacen] ([idSalidaAlmacen])
);

