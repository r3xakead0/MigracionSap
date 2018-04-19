CREATE TABLE [dbo].[tbEmpresa] (
    [idEmpresa]   INT           NOT NULL,
    [nombre]      VARCHAR (50)  NOT NULL,
    [descripcion] VARCHAR (255) NULL,
    CONSTRAINT [PK_tbEmpresa] PRIMARY KEY CLUSTERED ([idEmpresa] ASC)
);

