CREATE TABLE [dbo].[tbSolicitudCompra] (
    [idSolicitudCompra] INT             IDENTITY (1, 1) NOT NULL,
    [serie]             VARCHAR (10)    NOT NULL,
    [tipo]              CHAR (1)        NOT NULL,
    [fechaContable]     DATETIME        NOT NULL,
    [fechaNecesita]     DATETIME        NOT NULL,
    [fechaCreacion]     DATETIME        NOT NULL,
    [comentario]        VARCHAR (255)   NOT NULL,
    [total]             DECIMAL (19, 6) NOT NULL,
    [usuario]           VARCHAR (20)    NOT NULL,
    CONSTRAINT [PK_tbSolicitudCompra] PRIMARY KEY CLUSTERED ([idSolicitudCompra] ASC)
);

