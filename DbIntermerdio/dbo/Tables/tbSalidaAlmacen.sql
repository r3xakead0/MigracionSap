CREATE TABLE [dbo].[tbSalidaAlmacen] (
    [idSalidaAlmacen] INT             IDENTITY (1, 1) NOT NULL,
    [idEmpresa]       INT             NOT NULL,
    [idTipoDocumento] INT             NOT NULL,
    [serie]           VARCHAR (10)    NOT NULL,
    [fechaContable]   DATETIME        NOT NULL,
    [comentario]      VARCHAR (255)   NOT NULL,
    [fechaCreacion]   DATETIME        NOT NULL,
    [total]           DECIMAL (19, 6) NOT NULL,
    [usuario]         VARCHAR (20)    NOT NULL,
    [codSap]          INT             NULL,
    CONSTRAINT [PK_tbSalidaAlmacen] PRIMARY KEY CLUSTERED ([idSalidaAlmacen] ASC),
    CONSTRAINT [FK_tbSalidaAlmacen_tbTipoDocumento] FOREIGN KEY ([idTipoDocumento]) REFERENCES [dbo].[tbTipoDocumento] ([idTipoDocumento])
);



