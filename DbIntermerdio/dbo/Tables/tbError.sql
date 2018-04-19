CREATE TABLE [dbo].[tbError] (
    [idError]         INT           IDENTITY (1, 1) NOT NULL,
    [idTipoDocumento] INT           NOT NULL,
    [idDocumento]     INT           NOT NULL,
    [Mensaje]         VARCHAR (255) NOT NULL,
    CONSTRAINT [PK_tbError] PRIMARY KEY CLUSTERED ([idError] ASC)
);

