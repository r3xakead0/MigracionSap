CREATE TABLE [dbo].[tbConfiguracion] (
    [idConfiguracion] INT          IDENTITY (1, 1) NOT NULL,
    [idEmpresa]       INT          NOT NULL,
    [servidor]        VARCHAR (50) NOT NULL,
    [baseDatos]       VARCHAR (50) NOT NULL,
    [tipoBD]          INT          NOT NULL,
    [usuarioBD]       VARCHAR (50) NOT NULL,
    [claveBD]         VARCHAR (50) NOT NULL,
    [licenciaSAP]     VARCHAR (50) NOT NULL,
    [usuarioSAP]      VARCHAR (20) NOT NULL,
    [claveSAP]        VARCHAR (20) NOT NULL,
    CONSTRAINT [PK_tbConfiguracion] PRIMARY KEY CLUSTERED ([idConfiguracion] ASC),
    CONSTRAINT [FK_tbConfiguracion_tbEmpresa] FOREIGN KEY ([idEmpresa]) REFERENCES [dbo].[tbEmpresa] ([idEmpresa])
);

