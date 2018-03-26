CREATE TABLE [dbo].[tbSolicitudCompraDetalle] (
    [idSolicitudCompraDetalle] INT             IDENTITY (1, 1) NOT NULL,
    [idSolicitudCompra]        INT             NOT NULL,
    [nroLinea]                 INT             NOT NULL,
    [codigo]                   VARCHAR (20)    NOT NULL,
    [descripcion]              VARCHAR (100)   NOT NULL,
    [cantidad]                 DECIMAL (19, 6) NULL,
    [codAlmacen]               VARCHAR (10)    NULL,
    [codCentroCosto]           VARCHAR (10)    NOT NULL,
    [codProveedor]             VARCHAR (20)    NULL,
    CONSTRAINT [PK_tbSolicitudCompraDetalle] PRIMARY KEY CLUSTERED ([idSolicitudCompraDetalle] ASC),
    CONSTRAINT [FK_tbSolicitudCompraDetalle_tbSolicitudCompra] FOREIGN KEY ([idSolicitudCompra]) REFERENCES [dbo].[tbSolicitudCompra] ([idSolicitudCompra])
);

